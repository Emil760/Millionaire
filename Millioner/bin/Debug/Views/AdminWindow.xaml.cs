using Millioner.ViewModels;
using System.Windows;

namespace Millioner.Views
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            DataContext = new AdminWievModel();
        }
    }
}
