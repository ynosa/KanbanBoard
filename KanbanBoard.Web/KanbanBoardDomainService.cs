
namespace KanbanBoard.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the KanbanBoardDatabaseEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class KanbanBoardDomainService : LinqToEntitiesDomainService<KanbanBoardDatabaseEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Boards' query.
        public IQueryable<Board> GetBoards()
        {
            return this.ObjectContext.Boards;
        }

        public void InsertBoard(Board board)
        {
            if ((board.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(board, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Boards.AddObject(board);
            }
        }

        public void UpdateBoard(Board currentBoard)
        {
            this.ObjectContext.Boards.AttachAsModified(currentBoard, this.ChangeSet.GetOriginal(currentBoard));
        }

        public void DeleteBoard(Board board)
        {
            if ((board.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(board, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Boards.Attach(board);
                this.ObjectContext.Boards.DeleteObject(board);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BoardItems' query.
        public IQueryable<BoardItem> GetBoardItems()
        {
            return this.ObjectContext.BoardItems;
        }

        public void InsertBoardItem(BoardItem boardItem)
        {
            if ((boardItem.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(boardItem, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BoardItems.AddObject(boardItem);
            }
        }

        public void UpdateBoardItem(BoardItem currentBoardItem)
        {
            this.ObjectContext.BoardItems.AttachAsModified(currentBoardItem, this.ChangeSet.GetOriginal(currentBoardItem));
        }

        public void DeleteBoardItem(BoardItem boardItem)
        {
            if ((boardItem.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(boardItem, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.BoardItems.Attach(boardItem);
                this.ObjectContext.BoardItems.DeleteObject(boardItem);
            }
        }
    }
}


