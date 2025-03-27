using EventHandler.Model;
using EventHandler.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace EventHandler
{
    public sealed partial class EventSelectionPage : Page
    {
        public EventSelectionViewModel ViewModel { get; set; } = new EventSelectionViewModel();

        public EventSelectionPage()
        {
            this.InitializeComponent();
            this.DataContext = ViewModel;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedEvent = e.ClickedItem as Event;
            if (selectedEvent != null)
            {
                Frame.Navigate(typeof(EditEventPage), selectedEvent);
            }
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.LoadEventsAsync();
            base.OnNavigatedTo(e);
        }
        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddEventPage), ViewModel);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var eventToDelete = button.DataContext as Event;

            if (eventToDelete != null)
            {
                ViewModel.Events.Remove(eventToDelete);
                // Refresh the mock database
                ViewModel.RemoveEventFromStorage(eventToDelete);
            }
        }



    }
}
