using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel userViewModel) {
            _viewModel = userViewModel;
        }

        public void Display()
        {
            Console.WriteLine($"User: {_viewModel.Name}\nRole: {_viewModel.Role}");
        }
    }
}
