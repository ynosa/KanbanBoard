
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
        // To support paging you will need to add ordering to the 'BoardColumns' query.
        public IQueryable<BoardColumn> GetBoardColumns()
        {
            return this.ObjectContext.BoardColumns;
        }

        public void InsertBoardColumn(BoardColumn boardColumn)
        {
            if ((boardColumn.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(boardColumn, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BoardColumns.AddObject(boardColumn);
            }
        }

        public void UpdateBoardColumn(BoardColumn currentBoardColumn)
        {
            this.ObjectContext.BoardColumns.AttachAsModified(currentBoardColumn, this.ChangeSet.GetOriginal(currentBoardColumn));
        }

        public void DeleteBoardColumn(BoardColumn boardColumn)
        {
            if ((boardColumn.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(boardColumn, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.BoardColumns.Attach(boardColumn);
                this.ObjectContext.BoardColumns.DeleteObject(boardColumn);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Tasks' query.
        public IQueryable<Task> GetTasks()
        {
            return this.ObjectContext.Tasks;
        }

        public void InsertTask(Task task)
        {
            if ((task.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(task, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Tasks.AddObject(task);
            }
        }

        public void UpdateTask(Task currentTask)
        {
            this.ObjectContext.Tasks.AttachAsModified(currentTask, this.ChangeSet.GetOriginal(currentTask));
        }

        public void DeleteTask(Task task)
        {
            if ((task.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(task, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Tasks.Attach(task);
                this.ObjectContext.Tasks.DeleteObject(task);
            }
        }
    }
}


