using System;

using Welcome.Model;
using Welcome.ViewModel;
using Welcome.View;
using Welcome.Others;
using WelcomeExtended.Others;
using WelcomeExtended.Helpers;

namespace WelcomeExtended
{
    class Program
    {
        static void Main()
        {
            try
            {
                User newUser = new User("Stiliyan", "123", UserRolesEnum.ADMIN);
                UserViewModel userViewModel = new UserViewModel(newUser);

                UserView userView = new UserView(userViewModel);
                userView.Display();

                userView.DisplayError();
            }
            catch (Exception ex)
            {
                var logger = LoggerHelper.GetLogger("MainLogger");
                var log = new ActionOnError(Delegates.Log);
                log(ex.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}

