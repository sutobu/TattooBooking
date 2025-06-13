using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using TattooBookingManager.Data;
using TattooBookingManager.Models;

namespace TattooBookingManager.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly TattooBookingContext _context;
        private Appointment _selectedAppointment;

        public ObservableCollection<Appointment> Appointments { get; set; }
        public Appointment SelectedAppointment
        {
            get => _selectedAppointment;
            set
            {
                _selectedAppointment = value;
                OnPropertyChanged(nameof(SelectedAppointment));
            }
        }

        public ICommand OpenEditWindowCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainViewModel()
        {
            var options = new DbContextOptionsBuilder<TattooBookingContext>()
                .UseSqlite("Data Source=tattoo_booking.db")
                .Options;
            _context = new TattooBookingContext(options);
            LoadAppointments();
            OpenEditWindowCommand = new RelayCommand(OpenEditWindow);
            EditCommand = new RelayCommand(EditAppointment, CanEditOrDelete);
            DeleteCommand = new RelayCommand(DeleteAppointment, CanEditOrDelete);
        }

        private void LoadAppointments()
        {
            Appointments = new ObservableCollection<Appointment>(
                _context.Appointments
                    .Include(a => a.Client)
                    .Include(a => a.Artist)
                    .Include(a => a.Style)
                    .ToList()
            );
            OnPropertyChanged(nameof(Appointments));
        }

        private void OpenEditWindow(object parameter)
        {
            var editWindow = new EditWindow();
            editWindow.ShowDialog();
            LoadAppointments();
        }

        private void EditAppointment(object parameter)
        {
            if (SelectedAppointment != null)
            {
                var editViewModel = new EditViewModel(SelectedAppointment);
                var editWindow = new EditWindow { DataContext = editViewModel };
                editWindow.ShowDialog();
                LoadAppointments();
            }
        }

        private void DeleteAppointment(object parameter)
        {
            if (SelectedAppointment != null &&
                MessageBox.Show("Are you sure you want to delete this appointment?",
                    "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _context.Appointments.Remove(SelectedAppointment);
                _context.SaveChanges();
                LoadAppointments();
            }
        }

        private bool CanEditOrDelete(object parameter) => SelectedAppointment != null;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
    }
}