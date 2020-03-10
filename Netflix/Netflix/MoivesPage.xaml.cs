using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Netflix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoivesPage : ContentPage
    {
        private MovieService _service = new MovieService();


        private BindableProperty IsSearchingProperty =
            BindableProperty.Create("IsSearching", typeof(bool), typeof(Movie), false);
        public bool IsSearching
        {
            get { return (bool)GetValue(IsSearchingProperty); }
            set { SetValue(IsSearchingProperty, value); }
        }
        public MoivesPage()
        {
            BindingContext = this;
            InitializeComponent();
        }
        async Task FindMovies(string actor)
        {

            try
            {
                IsSearching = true;

                var movies = await _service.FindMoviesByActor(actor);

                moviesListView.ItemsSource = movies;
                moviesListView.IsVisible = movies.Any();
                notFound.IsVisible = !moviesListView.IsVisible;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Could not retrieve the list of movies.", "OK");
            }
            finally
            {
                IsSearching = false;
            }
        }
        async private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null || e.NewTextValue.Length < MovieService.MinSearchLength)
                return;


            await FindMovies(actor: e.NewTextValue);
        }

        async private void OnMovieSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var movie = e.SelectedItem as Movie;

            moviesListView.SelectedItem = null;

            await Navigation.PushAsync(new MovieDetailsPage(movie));
        }
    }
}