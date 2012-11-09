using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace KanbanBoard
{
    public partial class LoginForm : ChildWindow
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            LoginOperation loginOp = WebContext.Current.Authentication.Login(
           new LoginParameters(UsernameTextBox.Text, PasswordTextBox.Password));
            loginOp.Completed += (s2, e2) =>
            {
                if (loginOp.HasError)
                {
                    errorTextBlock.Text = loginOp.Error.Message;
                    loginOp.MarkErrorAsHandled();
                    return;
                }
                else if (!loginOp.LoginSuccess)
                {
                    errorTextBlock.Text = "Login failed.";
                    return;
                }
                else
                {
                    errorTextBlock.Text = string.Empty;
                    DialogResult = true;
                }
            };
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

