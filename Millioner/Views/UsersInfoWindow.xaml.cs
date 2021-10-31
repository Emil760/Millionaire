namespace Millioner.Views
{
    /// <summary>
    /// Interaction logic for UsersInfoWindow.xaml
    /// </summary>
    public partial class UsersInfoWindow : System.Windows.Window
    {
        public UsersInfoWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.UsersInfoViewModel();
        }
    }
}
