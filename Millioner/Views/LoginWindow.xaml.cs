namespace Millioner.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : System.Windows.Window
    {
        public LoginWindow()                            
        {
            InitializeComponent();
            DataContext = new ViewModels.LoginViewModel(this);
        }
    }
}
