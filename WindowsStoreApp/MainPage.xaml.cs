using Microsoft.AspNet.SignalR.Client.Hubs;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsStoreApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IHubProxy chat;

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var hubConnection =
                new HubConnection("http://localhost:8842/");

            chat = hubConnection.CreateHubProxy("chat");

            chat.On<string>("addMessage", msg =>
            {
                Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
                {
                    lbMessages.Items.Add(msg);
                });
            });

            await hubConnection.Start();
        }

        private async void bnSend_Click(object sender, RoutedEventArgs e)
        {
            await chat.Invoke<string>("sendMessage", tbMessage.Text);
        }
    }
}
