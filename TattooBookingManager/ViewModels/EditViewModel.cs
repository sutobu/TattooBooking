using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Data.Entity;
using TattooBookingManager.Data;
using TattooBookingManager.Models;

namespace TattooBookingManager.ViewModels
{
    public class EditViewModel : INotifyPropertyChanged
    {
        private readonly TattooBookingContext _context;
        private readonly bool _isEditMode;

        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Artist> Artists { get; set; }
        public ObservableCollection<TattooStyle> Styles { get; set; }
        public Appointment Appointment { get; set; }

        public ICommand SaveCommand { get; }

        // Публичный конструктор без параметров для XAML
        public EditViewModel()
        {
            _context = new TattooBookingContext();
            LoadCollections();
            Appointment = new Appointment(); // Инициализация по умолчанию
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        // Конструктор с параметром для программного использования
        public EditViewModel(Appointment appointment = null)
        {
            _context = new TattooBookingContext();
            LoadCollections();
            _isEditMode = appointment != null;
            Appointment = appointment != null ? CloneAppointment(appointment) : new Appointment();
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private void LoadCollections()
        {
            using (var context = new TattooBookingContext())
            {
                Clients = new ObservableCollection<Client>(context.Clients.ToList());
                Artists = new ObservableCollection<Artist>(context.Artists.ToList());
                Styles = new ObservableCollection<TattooStyle>(context.TattooStyles.ToList());
            }
        }

        private Appointment CloneAppointment(Appointment source)
        {
            return new Appointment
            {
                AppointmentId = source.AppointmentId,
                ClientId = source.ClientId,
                Client = source.Client,
                ArtistId = source.ArtistId,
                Artist = source.Artist,
                StyleId = source.StyleId,
                Style = source.Style,
                AppointmentDateTime = source.AppointmentDateTime,
                Duration = source.Duration
            };
        }

        private void Save(object parameter)
        {
            using (var context = new TattooBookingContext())
            {
                if (_isEditMode)
                {
                    var existingAppointment = context.Appointments.Find(Appointment.AppointmentId);
                    if (existingAppointment != null)
                    {
                        existingAppointment.ClientId = Appointment.ClientId;
                        existingAppointment.ArtistId = Appointment.ArtistId;
                        existingAppointment.StyleId = Appointment.StyleId;
                        existingAppointment.AppointmentDateTime = Appointment.AppointmentDateTime;
                        existingAppointment.Duration = Appointment.Duration;
                    }
                }
                else
                {
                    context.Appointments.Add(Appointment);
                }

                context.SaveChanges();
            }
            (parameter as Window)?.Close();
        }

        private bool CanSave(object parameter) =>
            Appointment.ClientId > 0 &&
            Appointment.ArtistId > 0 &&
            Appointment.StyleId > 0 &&
            Appointment.Duration > 0 &&
            Appointment.AppointmentDateTime > DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}