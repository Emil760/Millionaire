using Millioner.Utilities;
using Millioner.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace Millioner.ViewModels
{
    class MainViewModel
    {
        private Window window;

        public MainViewModel(Window window)
        {
            this.window = window;

            LoginCommand = new Command(Login);
            EditCommand = new Command(Edit);
            ExitCommand = new Command(Exit);
        }

        public ICommand LoginCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand ExitCommand { get; }

        public void Login(object param)
        {
            LoginWindow window = new LoginWindow();
            window.Closed += FormClosed;
            window.Show();
            this.window.Hide();
        }

        public void Edit(object param)
        {
            AdminWindow window = new AdminWindow();
            window.Closed += FormClosed;
            window.Show();
            this.window.Hide();
        }

        public void Exit(object param)
        {
            window.Close();
        }

        public void FormClosed(object param, EventArgs e) => window.Show();

    }
}
