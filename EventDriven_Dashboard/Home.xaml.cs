using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EventDriven_Dashboard
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private DispatcherTimer timer;
        TimeSpan nowTime = DateTime.Now.TimeOfDay;
        TimeSpan start = new TimeSpan(6, 0, 0);  // 9:00 AM
        TimeSpan end = new TimeSpan(18, 0, 0);

        public Home()
        {
            InitializeComponent();
            StartClock();
            CurrentStyle.Content = $"It is currently {DateTime.Now.ToString("hh:mm tt")}";
        }

        private void StartClock()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentStyle.Content = $"It is currently {DateTime.Now.ToString("hh:mm tt")}";
            ChangeIMG();
        }

        private void ChangeIMG()
        {
            if (nowTime > start && nowTime < end)
            {
                ImageBrush brush = new ImageBrush();
                brush.Opacity = 0.5;
                brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/morning.jpg", UriKind.Absolute));
                BG.Background = brush;
            }
            else
            {
                ImageBrush brush = new ImageBrush();
                brush.Opacity = 0.5;
                brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/night.jpg", UriKind.Absolute));
                BG.Background = brush;
            }
        }

        private void LoadBG(object sender, RoutedEventArgs e)
        {
            ChangeIMG();
        }
    }
}
