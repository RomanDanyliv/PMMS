using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
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
using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using Color = System.Windows.Media.Color;
using Pen = System.Drawing.Pen;
using Size = System.Windows.Size;

namespace Lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainText.Width= MeasureString(MainText.Text, MainText).Width;
            MainText.BorderThickness = new Thickness(0);
        }

        private DoubleAnimation RotationAnim = null, GrowAnim = null, DeletingAnim = null,FadingAnim=null;
        private DoubleAnimation checkBoxGrow = null;

        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                checkBoxGrow=new DoubleAnimation();
                checkBoxGrow.By = 4;
                checkBoxGrow.Duration = TimeSpan.FromMilliseconds(1000);
                (sender as CheckBox).BeginAnimation(CheckBox.FontSizeProperty,checkBoxGrow);
            }
            else
            {
                checkBoxGrow = new DoubleAnimation();
                checkBoxGrow.Duration = TimeSpan.FromMilliseconds(1000);
                (sender as CheckBox).BeginAnimation(CheckBox.FontSizeProperty, checkBoxGrow);
                checkBoxGrow = null;
            }
            MainText.Text = "";
            if (Rotation.IsChecked == true) MainText.Text += Rotation.Name;
            if (Deleting.IsChecked == true) MainText.Text += Deleting.Name;
            if (Fading.IsChecked == true) MainText.Text += Fading.Name;
            if (Grow.IsChecked == true) MainText.Text += Grow.Name;
            MainText.Width = MeasureString(MainText.Text, MainText).Width;
            MainText.Height = MeasureString(MainText.Text, MainText).Height;
            if ((sender as CheckBox) == Fading)
                if (FadingAnim == null)
                {
                    FadingAnim = new DoubleAnimation();
                    FadingAnim.From = MainText.Opacity;
                    FadingAnim.To = 0.0;
                    FadingAnim.Duration = TimeSpan.FromMilliseconds(1500);
                    FadingAnim.AutoReverse = true;
                    FadingAnim.RepeatBehavior = new RepeatBehavior(1500);
                    MainText.BeginAnimation(TextBox.OpacityProperty, FadingAnim);
                    AnimationChecked();
                }
                else
                {
                    FadingAnim = new DoubleAnimation();
                    FadingAnim.Duration = TimeSpan.FromMilliseconds(500);
                    MainText.BeginAnimation(TextBox.OpacityProperty, FadingAnim);
                    FadingAnim = null;
                    AnimationChecked();
                }
            if ((sender as CheckBox) == Deleting)
                if (DeletingAnim == null)
                {
                    DeletingAnim = new DoubleAnimation();
                    DeletingAnim.From = MeasureString(MainText.Text, MainText).Width;
                    DeletingAnim.To = 0.1;
                    DeletingAnim.Duration = TimeSpan.FromMilliseconds(1000);
                    DeletingAnim.AutoReverse = true;
                    DeletingAnim.RepeatBehavior = new RepeatBehavior(1000);
                    MainText.BeginAnimation(TextBox.WidthProperty, DeletingAnim);
                    AnimationChecked();
                }
                else
                {
                    DeletingAnim = new DoubleAnimation();
                    DeletingAnim.Duration = TimeSpan.FromMilliseconds(500);
                    DeletingAnim.To = MeasureString(MainText.Text, MainText).Width;
                    MainText.BeginAnimation(TextBox.WidthProperty, DeletingAnim);
                    DeletingAnim = null;
                    AnimationChecked();
                }
            if ((sender as CheckBox) == Rotation)
                if (RotationAnim == null)
                {
                    RotationAnim = new DoubleAnimation(0, 360, TimeSpan.FromSeconds(2));
                    RotationAnim.RepeatBehavior = new RepeatBehavior(1000);
                    var rt = (RotateTransform)MainText.RenderTransform;
                    rt.CenterX = MainText.Width / 2;
                    rt.CenterY = MainText.Height / 2;
                    rt.BeginAnimation(RotateTransform.AngleProperty, RotationAnim);
                    AnimationChecked();
                }
                else
                {
                    RotationAnim = new DoubleAnimation();
                    var rt = (RotateTransform)MainText.RenderTransform;
                    rt.BeginAnimation(RotateTransform.AngleProperty, RotationAnim);
                    RotationAnim = null;
                    AnimationChecked();
                }
            if ((sender as CheckBox) == Grow)
                if (GrowAnim == null)
                {
                    GrowAnim = new DoubleAnimation();
                    GrowAnim.From = MainText.FontSize;
                    GrowAnim.To = MainText.FontSize + 10;
                    GrowAnim.Duration = TimeSpan.FromMilliseconds(1500);
                    GrowAnim.AutoReverse = true;
                    GrowAnim.RepeatBehavior = new RepeatBehavior(1500);
                    MainText.BeginAnimation(TextBox.FontSizeProperty, GrowAnim);
                    AnimationChecked();
                }
                else
                {
                    GrowAnim = new DoubleAnimation();
                    GrowAnim.Duration = TimeSpan.FromMilliseconds(500);
                    MainText.BeginAnimation(TextBox.FontSizeProperty, GrowAnim);
                    GrowAnim = null;
                    AnimationChecked();
                }
        }

        private ColorAnimation RedAnim= null;
        private DoubleAnimation ButtonAnim;

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonAnim = new DoubleAnimation();
            ButtonAnim.Duration = TimeSpan.FromMilliseconds(1000);
            ButtonAnim.EasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseOut };
            (sender as Button).BeginAnimation(Button.WidthProperty, ButtonAnim);
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonAnim = new DoubleAnimation();
            ButtonAnim.By = 50;
            ButtonAnim.Duration = TimeSpan.FromMilliseconds(1000);
            ButtonAnim.EasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseInOut };
            (sender as Button).BeginAnimation(Button.WidthProperty, ButtonAnim);
        }

        private Button lastSender=null;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (RedAnim != null)
            {
                RedAnim = new ColorAnimation();
                RedAnim.To = Colors.Black;
                RedAnim.Duration = TimeSpan.FromMilliseconds(500);
                MainText.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, RedAnim);
                RedAnim = null;
                if ((sender as Button)==lastSender)
                    return;
            }
            lastSender = (sender as Button);
            RedAnim =new ColorAnimation();
            RedAnim.From = ((SolidColorBrush)MainText.Foreground).Color;
            if ((sender as Button)==RedButton)
                RedAnim.To = Colors.Red;
            if ((sender as Button) == BlueButton)
                RedAnim.To = Colors.Blue;
            if ((sender as Button) == GreenButton)
                RedAnim.To = Colors.Green;
            RedAnim.Duration = TimeSpan.FromMilliseconds(1500);
            MainText.Foreground=new SolidColorBrush() {Opacity = 1.0f};
            MainText.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, RedAnim);
        }

        private Size MeasureString(string candidate, TextBox textBlock)
        {
            var formattedText = new FormattedText(
                candidate,
                CultureInfo.CurrentUICulture,
                FlowDirection.LeftToRight,
                new Typeface(textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch),
                textBlock.FontSize+10,
                System.Windows.Media.Brushes.Black);
            return new Size(formattedText.Width, formattedText.Height);
        }

        public void AnimationChecked()
        {
            MainText.Width = MeasureString(MainText.Text, MainText).Width;
            MainText.Height = MeasureString(MainText.Text, MainText).Height;
            if (RotationAnim!=null)
            {
                var rt = (RotateTransform)MainText.RenderTransform;
                rt.BeginAnimation(RotateTransform.AngleProperty, RotationAnim);
            }
            if (DeletingAnim!=null)
            {
                DeletingAnim.From = MeasureString(MainText.Text, MainText).Width;
                MainText.BeginAnimation(TextBox.WidthProperty, DeletingAnim);
            }
            if (FadingAnim != null)
            {
                MainText.BeginAnimation(TextBox.OpacityProperty, FadingAnim);
            }
            if (Grow != null)
            {
                MainText.BeginAnimation(TextBox.FontSizeProperty, GrowAnim);
            }
        }
    }
}
