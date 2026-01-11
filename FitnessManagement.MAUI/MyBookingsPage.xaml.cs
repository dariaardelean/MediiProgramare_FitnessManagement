using FitnessManagement.MAUI.Models;
using FitnessManagement.MAUI.Services;

namespace FitnessManagement.MAUI;

public partial class MyBookingsPage : ContentPage
{
    private Booking _selectedBooking;
	public MyBookingsPage()
	{
		InitializeComponent();
        LoadBookings();
    }
    private void LoadBookings()
    {
        BookingsCollection.ItemsSource = null;
        BookingsCollection.ItemsSource = BookingService.Bookings;
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var booking = button?.CommandParameter as Booking;

        if (booking == null)
            return;

        BookingService.Bookings.Remove(booking);
        LoadBookings();
    }
    private void OnBookingTapped(object sender, EventArgs e)
    {
        var tapped = (TappedEventArgs)e;
        var booking = tapped.Parameter as Booking;

        if (booking == null)
            return;

        // salvăm booking-ul selectat
        _selectedBooking = booking;

        // afișăm data lui în DatePicker
        EditDatePicker.Date = booking.BookingDate;

        DisplayAlert(
            "Edit",
            "Selectează o nouă dată și apasă Update Booking",
            "OK"
        );
    }

    private async void OnUpdateClicked(object sender, EventArgs e)
    {
        if (_selectedBooking == null)
        {
            await DisplayAlert("Eroare", "Selectează o programare mai întâi", "OK");
            return;
        }

        _selectedBooking.BookingDate =
            EditDatePicker.Date + EditTimePicker.Time;

        LoadBookings();

        await DisplayAlert("Succes", "Programarea a fost actualizată", "OK");
    }
}