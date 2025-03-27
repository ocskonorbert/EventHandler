using EventHandler.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace EventHandler
{
    public sealed partial class EditEventPage : Page
    {
        private Event _editableEvent;

        public EditEventPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _editableEvent = e.Parameter as Event;

            if (_editableEvent != null)
            {
                this.DataContext = _editableEvent;
            }

            base.OnNavigatedTo(e);
        }

        private void Save_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Itt történhet mentés, pl. visszaküldeni a ViewModel-nek vagy Service-nek
            ErrorTextBlock.Text = ""; // Delete previous error message

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

            /*Fields are valid, save the modified event*/
            _editableEvent.Name = name;
            _editableEvent.Location = location;
            _editableEvent.Country = country;
            _editableEvent.Capacity = capacity;

            Frame.GoBack();
        }

        private void Cancel_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
