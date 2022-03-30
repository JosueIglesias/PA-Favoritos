using Contactos.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Contactos.ViewModel
{
    public class ContactoViewModel : BaseViewModel
    {
        #region Propiedades
        public ObservableCollection<Contacto> Contactos { get; set; }
        #endregion
        private Contacto contacto;
        public Contacto Contacto
        {
            get { return contacto; }
            set {  contacto = value; OnPropertyChanged(); }
        }

        public ICommand cmdContactoDetalle { get; set; }
        public ICommand cmdContactoElimina { get; set; }
        public ICommand cmdContactoEdita { get; set; }
        public ICommand cmdContactoCancelar { get; set; }
        public ICommand cmdContactoGrabar { get; set; }
        public ICommand cmdContactoAgrega { get; set; }
        public ICommand cmdContactoAgregaTelefono { get; set; }
        public ICommand cmdContactoEliminaTelefono { get; set; }
        public ContactoViewModel()
        {
            Contactos = new ObservableCollection<Contacto>();
            Contactos.Add(new Contacto()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = "Josue",
                ApellidoPaterno = "Iglesias",
                ApellidoMaterno = "Alcaraz",
                Organizacion = "Facultad de Telemática",
                Telefonos = new ObservableCollection<Telefono>() {
                    new Telefono{Id= Guid.NewGuid().ToString(), Numero="3141211713" },
                    new Telefono{Id= Guid.NewGuid().ToString(), Numero="3141414144" }
                }
            });
            Contactos.Add(new Contacto()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = "Giancarlo",
                ApellidoPaterno = "Garcia",
                ApellidoMaterno = "Rivera",
                Organizacion = "Facultad de Ingeniería Cvil",
                Telefonos = new ObservableCollection<Telefono>() {
                    new Telefono{Id= Guid.NewGuid().ToString(), Numero="3121111111" },
                    new Telefono{Id= Guid.NewGuid().ToString(), Numero="3122222222" }
                }
            });

            cmdContactoDetalle = new Command<Contacto>(async (x) => await PCmdContactoDetalle(x));
            cmdContactoElimina = new Command<Contacto>(async (x) => await PCmdContactoElimina(x));
            cmdContactoEdita = new Command<Contacto>(async (x) => await PCmdContactoEdita(x));
            cmdContactoCancelar = new Command(async () => await PCmdContactoCancelar());
            cmdContactoGrabar = new Command<Contacto>(async (x) => await PCmdContactoGrabar(x));
            cmdContactoAgrega = new Command(async () => await PCmdContactoAgrega());
            cmdContactoAgregaTelefono = new Command(async () => await PCmdContactoAgregaTelefono());
            cmdContactoEliminaTelefono = new Command<Telefono>(async (x) => await PCmdContactoEliminaTelefono(x));

            async Task PCmdContactoDetalle(Model.Contacto _Contacto)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.ContactoDetalle(_Contacto, this));
            }

            async Task PCmdContactoAgrega()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.ContactoMatto(this));
            }

            async Task PCmdContactoAgregaTelefono()
            {
                if(Contacto.Telefonos == null)
                    Contacto.Telefonos = new ObservableCollection<Telefono>();
                Contacto.Telefonos.Add(new Telefono() { Id = Guid.NewGuid().ToString() });

                await Task.Delay(1000);
            }

            async Task PCmdContactoElimina(Model.Contacto _Contacto)
            {
                int indice = Contactos.IndexOf(_Contacto);
                if (indice >= 0)
                {
                    Contactos.Remove(_Contacto);
                    OnPropertyChanged();
                }

                await Application.Current.MainPage.Navigation.PopAsync();
            }

            async Task PCmdContactoEdita(Model.Contacto _Contacto)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.ContactoMatto(Contacto, this));
            }

            async Task PCmdContactoCancelar()
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            async Task PCmdContactoGrabar(Model.Contacto _Contacto)
            {
                int indice = -1;
                Contacto tmp = Contactos.FirstOrDefault(item => item.Id == _Contacto.Id);

                if (tmp != null)
                {
                    //Editando un contacto
                    indice = Contactos.IndexOf(tmp);
                    Contactos[indice] = _Contacto;

                } 
                else
                {
                    Contactos.Add(_Contacto);
                }

                OnPropertyChanged();
                
                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        
            async Task PCmdContactoEliminaTelefono(Model.Telefono _Telefono)
            {
                Contacto.Telefonos.Remove(_Telefono);
                await Task.Delay(1000);
            }
        }
    }
}
