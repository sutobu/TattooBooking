using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using TattooBookingManager.Data;
using TattooBookingManager.Models;


namespace TattooBookingManager.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly TattooBookingContext _context;
        public ObservableCollection<Appointment> Appointments { get; set; }
        public ICommand OpenEditWindowCommand { get; }

        public MainViewModel()
        {
            _context = new TattooBookingContext();
            LoadAppointments();
            OpenEditWindowCommand = new RelayCommand(OpenEditWindow);
        }

        private void LoadAppointments()
        {
            Appointments = new ObservableCollection<Appointment>(
                _context.Appointments
                    .Include(a => a.Client)
                    .Include(a => a.Artist)
                    .Include(a => a.Style)
            );
            OnPropertyChanged(nameof(Appointments));
        }

        private void OpenEditWindow(object parameter)
        {
            var editWindow = new EditWindow();
            editWindow.ShowDialog();
            LoadAppointments();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}