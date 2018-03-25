using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using FatClient.IntroductionService;

namespace FatClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PopupWindow popupWindow { get; set; }
        private string Mac { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    Mac = nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
        }

        /// <summary>
        /// Single enablement managing center of a button.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="enabled"></param>
        public void SetButtonEnabled(Button button, bool enabled)
        {
            button.IsEnabled = enabled;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            popupWindow = new PopupWindow(this);
            Button button = sender as Button;
            SetButtonEnabled(button, false);
            popupWindow.Show();

            IntroductionServiceClient client = new IntroductionServiceClient();
            bool connected = await client.IntroduceAsync(Mac);
            if (connected)
            {
                popupWindow.Hide();
                SetButtonEnabled(button, true);
            }
            else
            {
                //TextBlock textBlock = popupWindow.FindName("Message") as TextBlock;
                //textBlock.Text = "Подключение не успешно";
                popupWindow.Message.Text = "Подключение не успешно";                
            }
        }
    }
}
