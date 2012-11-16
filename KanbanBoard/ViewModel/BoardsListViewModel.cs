﻿
using KanbanBoard.Helpers;
using KanbanBoard.Views.ChildWindows;
using KanbanBoard.Web;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.ServiceModel.DomainServices.Client;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System;
namespace KanbanBoard.ViewModel
{
    using KanbanBoard.Events;

    using Microsoft.Practices.Prism.Events;

    public class BoardsListViewModel : BaseViewModel
    {
        private const string BOARD_VIEW = "BoardView";
        private const string BOARD_PARAMS_TEMPLATE = "BOARD_ID:{0}";


        private readonly IUnityContainer container;
        private readonly InteractionRequest<Confirmation> confirmDelete;
        private readonly InteractionRequest<Confirmation> boardDialog;
        private readonly ViewOrchestrator viewOrchestrator;

        public DelegateCommand AddBoardCommand { get; set; }
        public DelegateCommand<Board> RemoveBoardCommand { get; private set; }
        public DelegateCommand<Board> EditBoardCommand { get; private set; }
        public DelegateCommand SelectBoardCommand { get; private set; }
        public DelegateCommand <Board> ManageBoardCommand { get; private set; }
        private KanbanBoardDomainContext kanbanBoardDomainContext = new KanbanBoardDomainContext();

        private IEventAggregator eventAggregator;

        public InteractionRequest<Confirmation> ConfirmDelete
        {
            get { return confirmDelete; }
        }
        public InteractionRequest<Confirmation> BoardDialog
        {
            get { return boardDialog; }
        }

        public EntitySet<Board> BoardsList
        {
            get
            {
                return kanbanBoardDomainContext.Boards;
            }
        }

        public BoardsListViewModel(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this.container = container;
            this.eventAggregator = eventAggregator;

            confirmDelete = new InteractionRequest<Confirmation>();
            boardDialog = new InteractionRequest<Confirmation>();

            kanbanBoardDomainContext.Load(kanbanBoardDomainContext.GetBoardsQuery());

            AddBoardCommand = new DelegateCommand(this.AddBoard);
            EditBoardCommand = new DelegateCommand<Board>(this.EditBoard);            
            RemoveBoardCommand = new DelegateCommand<Board>(this.RemoveBoard);
            ManageBoardCommand = new DelegateCommand<Board>(this.ManageBoard);

            SelectBoardCommand = new DelegateCommand(() => SelectBoard());

        }

        private void AddBoard()
        {
            var dialog = this.container.Resolve<BoardChildWindow>();

            dialog.Title = "Add new board"; // Don't forget about title!
            dialog.Closed += (s, e) =>
            {
                if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                {
                    // ToDo : Add implementation when board title isn't empty.
                    // Board name get from dialog.BoardName property!
                    Board board = new Board() { BoardName = dialog.BoardName, UserName = WebContextBase.Current.Authentication.User.Identity.Name, Id = Guid.NewGuid() };
                    //kanbanBoardDomainContext.BoardItems.Add(new BoardItem() { Board = board, Name = "item1", Id = 1 });
                    //kanbanBoardDomainContext.

                    kanbanBoardDomainContext.Boards.Add(board);
                    kanbanBoardDomainContext.SubmitChanges();
                }
            };
            dialog.Show();
        }

        private void EditBoard(Board board)
        {
            var dialog = this.container.Resolve<BoardChildWindow>();

            dialog.Title = "Edit board"; // Don't forget about title!
            dialog.BoardName = board.BoardName;
            dialog.Closed += (s, e) =>
            {
                if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                {
                    board.BoardName = dialog.BoardName;
                    kanbanBoardDomainContext.SubmitChanges();
                    NotifyPropertyChanged("BoardsList");
                }
            };
            dialog.Show();
        }

        private void ManageBoard(Board board)
        {
            this.eventAggregator.GetEvent<BoardSelectedEvent>().Publish(board);
        }

        private void RemoveBoard(Board board)
        {
            confirmDelete.Raise(new Confirmation()
            {
                Content = "Are you sure you want to remove this record?",
                Title = "Confirm remove",
            }, confirmation =>
            {
                if (confirmation.Confirmed)
                {
                    kanbanBoardDomainContext.Boards.Remove(board);
                    kanbanBoardDomainContext.SubmitChanges();
                    NotifyPropertyChanged("BoardsList");
                }
            });

        }

        private void SelectBoard()
        {
        }
    }
}