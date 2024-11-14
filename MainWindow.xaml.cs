using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AsyncWpfApp
{
    public partial class MainWindow : Window
    {
        private bool isRunning = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning) return;

            isRunning = true;
            btnStart.IsEnabled = false;

            DateTime startTime = DateTime.Now;
            lblTime.Content = $"Start Time: {startTime:HH:mm:ss}";
            lblResult.Content = "";

            await SlowWork();

            DateTime endTime = DateTime.Now;
            lblTime.Content += $"\nEnd Time: {endTime:HH:mm:ss}";

            isRunning = false;
            btnStart.IsEnabled = true;
        }

        private async Task SlowWork()
        {
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                int number = random.Next(1, 101);
                lblResult.Content = $"Generated Number: {number}";

                
                await Task.Delay(random.Next(100, 201));
            }
        }
    }
}
