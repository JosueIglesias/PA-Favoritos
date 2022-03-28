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
    public partial class ContactoMatto : ContentPage
    {
        public ContactoMatto(ContactoViewModel vm)
        {
            //Contacto nuevo
            InitializeComponent();
            vm.Contacto = new Model.Contacto() { Id = Guid.NewGuid().ToString() };
            vm.Contacto.Telefonos = new System.Collections.ObjectModel.ObservableCollection<Model.Telefono>();
            BindingContext = vm;
            Title = "NUEVO CONTACTO";
        }
        public ContactoMatto(Model.Contacto contacto, ContactoViewModel vm)
        {
            //Contacto existente
            InitializeComponent();
            vm.Contacto = new Model.Contacto();
            vm.Contacto = contacto;
            BindingContext = vm;
            Title = "EDITA CONTACTO";
        }
    }
}