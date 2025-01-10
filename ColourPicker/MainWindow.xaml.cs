using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColourPicker
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

        private void UpdateBackground()
        {
            byte r = (byte)RSlider.Value;
            byte g = (byte)GSlider.Value;
            byte b = (byte)BSlider.Value;

            ColorPreview.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
            HexTextBox.Text = $"#{r:X2}{g:X2}{b:X2}";

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<Double> e)
        {
            UpdateBackground();
        }

        private void CopyToClipboard(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(HexTextBox.Text);
            MessageBox.Show("Copied " + HexTextBox.Text + " To Clipboard!");
        }

        private void RandomColour(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            byte RandomR = (byte)random.Next(0, 255);
            byte RandomG = (byte)random.Next(0,255);
            byte RandomB = (byte)random.Next(0, 255);

            RSlider.Value = RandomR;
            GSlider.Value = RandomG;
            BSlider.Value = RandomB;

            UpdateBackground();
            HexTextBox.Text = $"#{RandomR:X2}{RandomG:X2}{RandomB:X2}";
        }
    }
}