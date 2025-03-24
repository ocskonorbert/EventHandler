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
            Frame.GoBack();
        }

        private void Cancel_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
