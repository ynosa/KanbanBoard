using Microsoft.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace KanbanBoard.Behaviors
{
    public class DragAndDropBehavior : Behavior<ListBoxDragDropTarget>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.AllowDrop = true;
            this.AssociatedObject.DragEnter += AssociatedObject_DragEnter;
            this.AssociatedObject.DragLeave += AssociatedObject_DragLeave;
            this.AssociatedObject.DragOver += AssociatedObject_DragOver;
        }

        void AssociatedObject_DragOver(object sender, DragEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void AssociatedObject_DragLeave(object sender, DragEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void AssociatedObject_DragEnter(object sender, DragEventArgs e)
        {
            //throw new NotImplementedException();
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.DragEnter -= AssociatedObject_DragEnter;
            this.AssociatedObject.DragLeave -= AssociatedObject_DragLeave;
            this.AssociatedObject.DragOver -= AssociatedObject_DragOver;
        }
    }
}
