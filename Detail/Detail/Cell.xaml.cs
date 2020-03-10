using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExXamarin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Detail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cell : ContentPage
    {
        List<contacts> Getcontacs()
        {
            return new List<contacts>
               {
                   new contacts{Name="Hani",Imageurl="https://vfan-phinf.pstatic.net/20191106_112/1572972804249tfSB2_JPEG/hani.jpg?type=e1280"},
                new contacts{Name="Tzuyu",Imageurl="https://cdnmedia.thethaovanhoa.vn/Upload/BLtvcXjb72tSqs1jiHr8g/files/2019/12/Tzuyu-fangirl-a.jpg"}
               };

        }



        private void handler_re(object sender, EventArgs e)
        {
            listview.ItemsSource = Getcontacs();
            listview.EndRefresh();
        }
        public Cell()
        {
            InitializeComponent();
            listview.ItemsSource = Getcontacs();
        }

        private void handle_textchange(object sender, TextChangedEventArgs e)
        {

        }

        async private void selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var contacss = e.SelectedItem as contacts;
            await Navigation.PushAsync(new ContacdetailPage(contacss));
            listview.SelectedItem = null;
        }
    }
}