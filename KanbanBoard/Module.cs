using KanbanBoard.Controller;
using KanbanBoard.Events;
using KanbanBoard.Interfaces;
using KanbanBoard.Views;
using KanbanBoard.Views.ChildWindows;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace KanbanBoard
{
    public class Module : IModule
    {
        IUnityContainer container;
        IEventAggregator eventAggregator;

        public Module(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this.container = container;
            this.eventAggregator = eventAggregator;
        }

        public void Initialize()
        {
            container.RegisterType<object, StatusView>("StatusView");
            container.RegisterType<object, LoginView>("LoginView");
            container.RegisterType<object, BoardsView>("BoardsView");
            container.RegisterType<object, ErrorView>("ErrorView");
            container.RegisterType<object, BoardChildWindow>("BoardChildWindow");
            container.RegisterType<object, SelectedBoardView>("SelectedBoardView");
            container.RegisterType<ILoginController, LoginController>();

            container.Resolve<ILoginController>();
            container.Resolve<ApplicationController>();
            
            // Raise event
            eventAggregator.GetEvent<AuthenticationEvent>().Publish(0);
        }
    }
}