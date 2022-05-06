using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Password_Generator.View
{
    /// <summary>
    /// Interaktionslogik für ToggleButton.xaml
    /// </summary>
    public partial class ToggleButton : UserControl
    {

        //Thickness LeftSide = new Thickness(-39, 0, 0, 0);
        //Thickness RightSide = new Thickness(0, 0, -39, 0);
        //private readonly SolidColorBrush Off = new SolidColorBrush(Color.FromRgb(101, 81, 126));
       // private readonly SolidColorBrush On = new SolidColorBrush(Color.FromRgb(130, 190, 125));



        public static readonly DependencyProperty ToggledProperty = DependencyProperty.Register
            ("Toggled", typeof(bool), typeof(ToggleButton), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, ToggleChangedCallback));




        private void ToggleChangedCallback(bool value)
        {
            //...
        }

        private static void ToggleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ToggleButton)d).ToggleChangedCallback((bool)e.NewValue);
        }



        public bool Toggled
        {
            get => (bool)GetValue(ToggledProperty);
            set => SetValue(ToggledProperty, value);
        }



        public ToggleButton()
        {
            InitializeComponent();

        }


        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Toggled && IsEnabled)
                ToggleOn();
            else
                ToggleOff();
        }

        private void ToggleOff()
        {
           // Back.Fill = Off;
            Toggled = false;
            //Dot.Margin = LeftSide;
            //txtOff.IsEnabled = true;
        }
        private void ToggleOn()
        {
            //Back.Fill = On;
            Toggled = true;
            //Dot.Margin = RightSide;
            //txtOff.IsEnabled = false;
        }

        
    }
}
