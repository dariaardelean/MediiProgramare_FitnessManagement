using FitnessManagement.MAUI.Models;
using FitnessManagement.MAUI.Services;

namespace FitnessManagement.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly FitnessClassService _service;

        public MainPage()
        {
            InitializeComponent();
            _service = new FitnessClassService();
            LoadClasses();
        }

        private async void LoadClasses()
        {
            var classes = await _service.GetFitnessClassesAsync();
            ClassesCollection.ItemsSource = classes;
        }

        private async void OnClassTapped(object sender, EventArgs e)
        {
            var tapped = (TappedEventArgs)e;
            var selectedClass = tapped.Parameter as FitnessClass;

            if (selectedClass == null)
                return;

            BookingService.Bookings.Add(new Booking
            {
                FitnessClassID = selectedClass.ID,
                ClassName = selectedClass.Name,
                TrainerName = selectedClass.TrainerName,
                BookingDate = selectedClass.ScheduledDate
            });

            await DisplayAlert(
                "Programare reușită ✅",
                $"Te-ai programat la:\n{selectedClass.Name}",
                "OK"
            );
        }

        private async void OnMyBookingsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MyBookingsPage));
        }
    }
}