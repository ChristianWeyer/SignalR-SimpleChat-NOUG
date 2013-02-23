using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Windows.Forms;

namespace WindowsFormsClient
{
    public partial class MainForm : Form
    {
        private IHubProxy chat;

        public MainForm()
        {
            InitializeComponent();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            var hubConnection =
                new HubConnection("http://localhost:8842/");
        
            chat = hubConnection.CreateHubProxy("chat");
            
            chat.On<string>("addMessage", msg =>
            {
                listBox1.Invoke(new Action(() => listBox1.Items.Add(msg)));
            });

            hubConnection.Start().Wait();
        }

        private void send_Click(object sender, EventArgs e)
        {
            chat.Invoke<string>("sendMessage", textBox1.Text);
        }
    }
}
