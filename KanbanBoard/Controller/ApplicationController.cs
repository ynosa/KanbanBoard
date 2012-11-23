
using KanbanBoard.Helpers;
namespace KanbanBoard.Controller
{
    using System;

    using KanbanBoard.Events;
    using KanbanBoard.ViewModel;
    using KanbanBoard.Web;

    using Microsoft.Practices.Prism.Events;

    public class ApplicationController 
    {
        private readonly ViewOrchestrator viewOrchestrator;

        private IEventAggregator eventAggregator;

        public ApplicationController(ViewOrchestrator orchestrator, IEventAggregator aggregator)
        {
            this.viewOrchestrator = orchestrator;
            this.eventAggregator = aggregator;
            this.RegisterSubcriptions();
        }

        private void RegisterSubcriptions()
        {
            this.eventAggregator.GetEvent<BoardSelectedEvent>().Subscribe(this.OnBoardSelectedForManaging, true);
            this.eventAggregator.GetEvent<ShowBoardsEvent>().Subscribe(this.OnBoardsSelectedForManaging, true);
        }

        public void OnBoardSelectedForManaging(Board board)
        {
            viewOrchestrator.ChangeView(RegionNames.MAIN_REGION, ViewNames.SelectedBoardView,
                string.Format(viewOrchestrator.ParametrTemplate, BoardViewModel.BoardIdParam, board.Id),
                string.Format(viewOrchestrator.ParametrTemplate, BoardViewModel.BoardNameParam, board.BoardName));
        }

        public void OnBoardsSelectedForManaging(int i)
        {
            viewOrchestrator.ChangeView(RegionNames.MAIN_REGION, ViewNames.BoardsListView);
        }
    }
}
