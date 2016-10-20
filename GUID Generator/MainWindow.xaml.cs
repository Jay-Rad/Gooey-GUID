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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUID_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textGUID.Text = Guid.NewGuid().ToString();
        }

        private void buttonCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textGUID.Text);
            var tt = new ToolTip();
            tt.PlacementTarget = textGUID;
            tt.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            tt.Content = "GUID copied to clipboard!";
            tt.IsOpen = true;
            var sb = new Storyboard();
            var da = new DoubleAnimation() { To = 0, BeginTime = TimeSpan.FromSeconds(2), Duration = TimeSpan.FromSeconds(2) };
            Storyboard.SetTarget(da, tt);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));
            sb.Children.Add(da);
            sb.Completed += (sen, arg) => { tt.IsOpen = false; };
            sb.Begin();
        }

        private void buttonNew_Click(object sender, RoutedEventArgs e)
        {
            textGUID.Text = Guid.NewGuid().ToString();
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
