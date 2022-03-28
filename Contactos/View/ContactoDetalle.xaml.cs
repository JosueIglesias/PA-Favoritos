using Contactos.ViewModel;
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
    public partial class ContactoDetalle : ContentPage
    {
        public ContactoDetalle(Model.Contacto contacto, ContactoViewModel vm)
        {
            InitializeComponent();
            vm.Contacto = new Model.Contacto();
            vm.Contacto = contacto;
            this.BindingContext = vm;
        }
    }
}