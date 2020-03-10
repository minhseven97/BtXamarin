using ExXamarin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Detail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContacdetailPage : ContentPage
    {
        public ContacdetailPage(contacts contactss)
        {
            if (contactss == null)
                throw new ArgumentException();
            BindingContext = contactss;
            InitializeComponent();
        }
    }
}