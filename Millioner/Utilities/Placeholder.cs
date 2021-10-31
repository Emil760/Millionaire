using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Millioner.Utilities
{
    public class Placeholder : TextBox
    {
        static readonly DependencyProperty PlaceholderIsActivatedProperty;
        static readonly DependencyProperty PlaceholderTextProperty;
        static readonly DependencyProperty PlaceholderForegroundProperty;
        static readonly DependencyProperty PlaceholderFontFamilyProperty;
        static readonly DependencyProperty PlaceholderFontSizeProperty;
        static readonly DependencyProperty PlaceholderFontWeightProperty;
        static readonly DependencyProperty PlaceholderFontStyleProperty;

        private Brush base_foreground;
        private FontFamily base_font_family;
        private double base_font_size;
        private FontWeight base_font_weight;
        private FontStyle base_font_style;

        static Placeholder()
        {
            PlaceholderIsActivatedProperty = DependencyProperty.Register("PlaceholderIsActivated", typeof(bool), typeof(Placeholder), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

            PlaceholderTextProperty = DependencyProperty.Register("PlaceholderText", typeof(string), typeof(Placeholder), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

            PlaceholderForegroundProperty = DependencyProperty.Register("PlaceholderForeground", typeof(Brush), typeof(Placeholder), new FrameworkPropertyMetadata(Brushes.Gray, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

            PlaceholderFontFamilyProperty = DependencyProperty.Register("PlaceholderFontFamily", typeof(FontFamily), typeof(Placeholder), new FrameworkPropertyMetadata(new FontFamily("Sergio UI"), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

            PlaceholderFontSizeProperty = DependencyProperty.Register("PlaceholderFontSize", typeof(double), typeof(Placeholder), new FrameworkPropertyMetadata(12.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

            PlaceholderFontWeightProperty = DependencyProperty.Register("PlaceholderFontWeight", typeof(FontWeight), typeof(Placeholder), new FrameworkPropertyMetadata(FontWeights.Normal, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

            PlaceholderFontStyleProperty = DependencyProperty.Register("PlaceholderFontStyle", typeof(FontStyle), typeof(Placeholder), new FrameworkPropertyMetadata(FontStyles.Normal, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        }

        public Placeholder() : base()
        {
          
        }

        public bool PlaceholderIsActivated
        {
            get => (bool)GetValue(PlaceholderIsActivatedProperty);
            private set => SetValue(PlaceholderIsActivatedProperty, value);
        }
        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }
        public Brush PlaceholderForeground
        {
            get => (Brush)GetValue(PlaceholderForegroundProperty);
            set => SetValue(PlaceholderForegroundProperty, value);
        }
        public FontFamily PlaceholderFontFamily
        {
            get => (FontFamily)GetValue(PlaceholderFontFamilyProperty);
            set => SetValue(PlaceholderFontFamilyProperty, value);
        }
        public double PlaceholderFontSize
        {
            get => (double)GetValue(PlaceholderFontSizeProperty);
            set => SetValue(PlaceholderFontSizeProperty, value);
        }
        public FontWeight PlaceholderFontWeight
        {
            get => (FontWeight)GetValue(PlaceholderFontWeightProperty);
            set => SetValue(PlaceholderFontWeightProperty, value);
        }
        public FontStyle PlaceholderFontStyle
        {
            get => (FontStyle)GetValue(PlaceholderFontStyleProperty);
            set => SetValue(PlaceholderFontStyleProperty, value);
        }

        public void ShowPlaceholder(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Text))
            {
                PlaceholderIsActivated = true;
                Text = PlaceholderText;
                Foreground = PlaceholderForeground;
                FontFamily = PlaceholderFontFamily;
                FontSize = PlaceholderFontSize;
                FontWeight = PlaceholderFontWeight;
                FontStyle = PlaceholderFontStyle;
            }
        }

        public void HidePlaceholder(object sender, EventArgs e)
        {
            if (PlaceholderIsActivated)
            {
                PlaceholderIsActivated = false;
                Text = null;
                Foreground = base_foreground;
                FontFamily = base_font_family;
                FontSize = base_font_size;
                FontWeight = base_font_weight;
                FontStyle = base_font_style;
            }
        }

        private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue && String.IsNullOrEmpty(Text))
            {
                PlaceholderIsActivated = true;
                Text = PlaceholderText;
                Foreground = PlaceholderForeground;
                FontFamily = PlaceholderFontFamily;
                FontSize = PlaceholderFontSize;
                FontWeight = PlaceholderFontWeight;
                FontStyle = PlaceholderFontStyle;
            }
            else
            {
                PlaceholderIsActivated = false;
                Foreground = base_foreground;
                FontFamily = base_font_family;
                FontSize = base_font_size;
                FontWeight = base_font_weight;
                FontStyle = base_font_style;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            base_foreground = Foreground;
            base_font_size = FontSize;
            base_font_family = FontFamily;
            base_font_weight = FontWeight;
            base_font_style = FontStyle;

            GotFocus += HidePlaceholder;
            LostFocus += ShowPlaceholder;
            IsEnabledChanged += OnIsEnabledChanged;

            if (String.IsNullOrEmpty(Text) && IsEnabled)
            {
                PlaceholderIsActivated = true;
                Text = PlaceholderText;
                Foreground = PlaceholderForeground;
                FontFamily = PlaceholderFontFamily;
                FontSize = PlaceholderFontSize;
                FontWeight = PlaceholderFontWeight;
                FontStyle = PlaceholderFontStyle;
            }
        }
    }
}
