
using KanbanBoard.Helpers;
namespace KanbanBoard.Controller
{
    public class ApplicationController 
    {
        private readonly ViewOrchestrator viewOrchestrator;

        public ApplicationController(ViewOrchestrator orchestrator)
        {
            this.viewOrchestrator = orchestrator;
        }
       
    }
}
