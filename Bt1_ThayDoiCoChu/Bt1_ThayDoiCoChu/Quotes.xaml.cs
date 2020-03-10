using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bt1_ThayDoiCoChu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Quotes : ContentPage
    {
        private int _index = 0;
        private string[] _quotes = new string[]
        {
            "Anh cô đơn giữa tinh không này","Muôn con sóng cuốn xô vào đây","Em cô đơn giữa mênh mông người","Và ta cô đơn đã hai triệu năm"
        };
        public Quotes()
        {
            InitializeComponent();
            current.Text = _quotes[_index];
           
        }



        private void Handle_Clicked(object sender, EventArgs e)
        {
            _index++;
            if (_index >= _quotes.Length)
            {
                _index = 0;
            }
            current.Text = _quotes[_index];
        }
    }
}