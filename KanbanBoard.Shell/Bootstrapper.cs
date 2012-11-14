using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Windows;
using Modularity = Microsoft.Practices.Prism.Modularity;

namespace KanbanBoard.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.TryResolve<ShellView>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.RootVisual = (UIElement)this.Shell;
        }

        protected override Modularity.IModuleCatalog CreateModuleCatalog()
        {
            return Modularity.ModuleCatalog.CreateFromXaml(new Uri("/KanbanBoard.Shell;component/ModuleCatalog.xaml", UriKind.Relative)); ;
        }
    }
}