using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contactos.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contacto : ContentPage
    {
        public Contacto()
        {
            InitializeComponent();
            
        }

        public async void FavoritoSeleccionado(object sender, EventArgs e)
        {
            var imageSender = (Image)sender;
            if (imageSender.ClassId == "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/Noun_Project_Star_icon_370530_cc.svg/1045px-Noun_Project_Star_icon_370530_cc.svg.png")
            {
                imageSender.Source = "https://cdn0.iconfinder.com/data/icons/small-n-flat/24/678064-star-512.png";
                imageSender.ClassId = "https://cdn0.iconfinder.com/data/icons/small-n-flat/24/678064-star-512.png";
                imageSender.Opacity = 1;
            } else
            {
                imageSender.Source = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/Noun_Project_Star_icon_370530_cc.svg/1045px-Noun_Project_Star_icon_370530_cc.svg.png";
                imageSender.ClassId = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/Noun_Project_Star_icon_370530_cc.svg/1045px-Noun_Project_Star_icon_370530_cc.svg.png";
                imageSender.Opacity = 0.3;
            }
        }
    }
}