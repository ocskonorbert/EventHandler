using EventHandler.Model;
using EventHandler.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EventHandler
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddEventPage : Page
    {
        private EventSelectionViewModel _viewModel;

        public AddEventPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _viewModel = e.Parameter as EventSelectionViewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Text = ""; // töröljük a korábbi hibaüzenetet

            string name = NameBox.Text?.Trim();
            string location = LocationBox.Text?.Trim();
            string country = CountryBox.Text?.Trim();
            string capacityText = CapacityBox.Text?.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                ErrorTextBlock.Text = "A név megadása kötelező.";
                return;
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                ErrorTextBlock.Text = "A helyszín megadása kötelező.";
                return;
            }

            if (location.Length > 100)
            {
                ErrorTextBlock.Text = "A helyszín maximum 100 karakter lehet.";
                return;
            }

            int? capacity = null;
            if (!string.IsNullOrWhiteSpace(capacityText))
            {
                if (!int.TryParse(capacityText, out int cap) || cap <= 0)
                {
                    ErrorTextBlock.Text = "A kapacitásnak pozitív számnak kell lennie.";
                    return;
                }
                capacity = cap;
            }

            var newEvent = new Event
            {
                Name = name,
                Location = location,
                Country = country,
                Capacity = capacity
            };

            _viewModel?.AddEvent(newEvent);
            Frame.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }

}
