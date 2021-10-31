using System.Windows;

namespace Millioner.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = new Millioner.ViewModels.RegisterViewModel(this);
        }
    }
}
