using Microsoft.Practices.Prism.Regions;

namespace KanbanBoard.ViewModel
{
    public class ErrorViewModel:BaseViewModel
    {
        public string ErrorType { get; set; }
        public string Message { get; set; }

        public ErrorViewModel(IRegionManager manager)
            : base(manager)
        {

        }
    }
}
