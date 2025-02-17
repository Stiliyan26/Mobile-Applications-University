using System;
using Welcome.Model;
using Welcome.ViewModel;
using Welcome.View;
using Welcome.Others;

namespace Welcome
{
    class Program
    {
        static void Main()
        {
            User newUser = new User("Stiliyan", "123", UserRolesEnum.ADMIN);
            UserViewModel userViewModel = new UserViewModel(newUser);

            UserView userView = new UserView(userViewModel);
            userView.Display();
        }
    }
}

