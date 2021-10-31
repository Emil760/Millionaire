using Millioner.Utilities;
using Millioner.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace Millioner.ViewModels
{
    class LoginViewModel : ObserableObject
    {
        private Window window;
        private string user_login;
        private string user_password;
        private Visibility user_check_visibility;

        public LoginViewModel(Window window)
        {
            this.window = window;

            LoginCommand = new Command(Login);
            RegisterCommand = new Command(Register);
            UserCheckVisibility = Visibility.Hidden;
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public string UserLogin { get => user_login; set => Set(ref user_login, value); }
        public string UserPassword { get => user_password; set => Set(ref user_password, value); }
        public Visibility UserCheckVisibility { get => user_check_visibility; set => Set(ref user_check_visibility, value); }

        private void Login(object param)
        {
            if (!String.IsNullOrWhiteSpace(UserLogin) && !String.IsNullOrWhiteSpace(UserPassword))
            {
                Models.User user = new Models.User(UserLogin, UserPassword);
                if (user.Search(UserLogin, UserPassword))
                {
                    UserCheckVisibility = Visibility.Hidden;
                    UserLogin = null;
                    UserPassword = null;
                    GameWindow window = new GameWindow();
                    window.DataContext = new GameViewModel(window, user);
                    window.Show();
                    window.Closed += WindowClosed;
                    this.window.Dispatcher.Invoke(()=> {
                        this.window.Hide();
                    });
                }
                else
                {
                    UserCheckVisibility = Visibility.Visible;
                }
            }
        }

        private void Register(object param)
        {
            UserLogin = null;
            UserPassword = null;
            RegisterWindow window = new RegisterWindow();
            window.Show();
            window.Closed += WindowClosed;
            this.window.Hide();
        }

        private void WindowClosed(object sender, EventArgs e) => window.Show();
    }
}
