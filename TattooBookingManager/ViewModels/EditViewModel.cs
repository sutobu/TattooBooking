using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using TattooBookingManager.Data;
using TattooBookingManager.Models;

namespace TattooBookingManager.ViewModels
{
    public class EditViewModel : INotifyPropertyChanged
    {
        private readonly TattooBookingContext _context;

        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Artist> Artists { get; set; }
        public ObservableCollection<TattooStyle> Styles { get; set; }

        public Appointment Appointment { get; set; }

        public ICommand SaveCommand { get; }

        public EditViewModel()
        {
            _context = new TattooBookingContext();
            Clients = new ObservableCollection<Client>(_context.Clients);
            Artists = new ObservableCollection<Artist>(_context.Artists);
            Styles = new ObservableCollection<TattooStyle>(_context.TattooStyles);
            Appointment = new Appointment();
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private void Save(object parameter)
        {
            _context.Appointments.Add(Appointment);
            _context.SaveChanges();
            (parameter as Window)?.Close();
        }

        private bool CanSave(object parameter) =>
            Appointment.ClientId > 0 &&
            Appointment.ArtistId > 0 &&
            Appointment.StyleId > 0;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}