using Millioner.Utilities;
using System;
using System.Windows;
using System.Windows.Input;

namespace Millioner.ViewModels
{
    class RegisterViewModel : ObserableObject
    {
        private Window window;

        private string user_login;
        private string user_password;
        private Visibility user_check_visibility;

        public RegisterViewModel(Window window)
        {
            this.window = window;
            RegisterCommand = new Command(Register);
            UserCheckVisibility = Visibility.Hidden;
        }

        public ICommand RegisterCommand { get; }

        public string UserLogin { get => user_login; set => Set(ref user_login, value); }
        public string UserPassword { get => user_password; set => Set(ref user_password, value); }
        public Visibility UserCheckVisibility { get => user_check_visibility; set => Set(ref user_check_visibility, value); }

        private void Register(object param)
        {
            if(!String.IsNullOrWhiteSpace(UserLogin) && !String.IsNullOrWhiteSpace(UserPassword))
            {
                Models.User user = new Models.User(UserLogin, UserPassword);
                if (user.Save())
                {
                    UserLogin = null;
                    UserPassword = null;
                    UserCheckVisibility = Visibility.Hidden;
                    window.Close();
                }
                else
                {
                    UserCheckVisibility = Visibility.Visible;
                }
            }
        }
    }
}
