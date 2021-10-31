using Millioner.Models;
using Millioner.Utilities;
using System.Collections.ObjectModel;

namespace Millioner.ViewModels
{
    class UsersInfoViewModel : ObserableObject
    {
        private User selected_user;
        private ObservableCollection<User> users;

        public UsersInfoViewModel()
        {
            Users = new ObservableCollection<User>(User.GetAllUsers());
        }

        public User SelectedUser { get => selected_user; set => Set(ref selected_user, value); }
        public ObservableCollection<User> Users { get => users; set => Set(ref users, value); }
    }
}
