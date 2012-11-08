
using Microsoft.Practices.Prism.Commands;
namespace KanbanBoard.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public DelegateCommand LoginCommand { get; protected set; }

        public LoginViewModel()
        {

        }
    }
}
