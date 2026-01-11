using FitnessManagement.MAUI.Models;
using FitnessManagement.MAUI.Services;

namespace FitnessManagement.MAUI;

public partial class MyBookingsPage : ContentPage
{
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
}