using DataBinding.Collection.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataBinding.Collection.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _nombre = string.Empty;
        public string Nombre
        {
            get => _nombre;
            set
            {
                if(_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        public ObservableCollection<Persona> Personas {  get; set; }

        public ICommand AddPersonCommand { get; private set; }

        public MainViewModel()
        {
            Personas = new ObservableCollection<Persona>();
            CargarPersonas();
            AddPersonCommand = new Command(AddPerson);
        }

        private void CargarPersonas()
        {
            Personas.Add(new Persona() { Nombre = "Barry Allen"});
            var batman = new Persona() { Nombre = "Bruce Wayne" };
            Personas.Add(batman);
            Personas.Add(new Persona() { Nombre = "Natasha Romanoff" });
        }

        private void AddPerson()
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var persona = new Persona(){Nombre = this.Nombre};
                Personas.Add(persona);
                Nombre = string.Empty;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
