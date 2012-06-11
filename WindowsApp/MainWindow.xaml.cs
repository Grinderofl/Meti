using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Samples;
using WindowsApp.localhost;

namespace WindowsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AuthService service;
        public MainWindow()
        {
            InitializeComponent();
            FancyBalloon  balloon = new FancyBalloon();
            balloon.BalloonText = "TODO Due!";
            balloon.TodoTextItem.Text = "Here is the todo text";
            //NotifyIcon.ShowCustomBalloon(balloon, PopupAnimation.Scroll, 10000);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(Password.Text))
            {
                MessageBox.Show("Username and password are required.");
                return;
            }
            
            service = new AuthService();
            //service.Discover();
            service.InitializeLifetimeService();
            service.RegisterCompleted += ServiceOnAuthenticateCompleted;
            service.RegisterAsync(new User() {Name = UserName.Text, Password = Password.Text});

        }

        private void ServiceOnAuthenticateCompleted(object sender, RegisterCompletedEventArgs registerCompletedEventArgs)
        {
            if (registerCompletedEventArgs.RegisterResult == RegisterStatus.Success)
                MessageBox.Show("Apparently registration successful!");
            else
            {
                MessageBox.Show("Registration NOT successful... apparently");
            }
            service.Dispose();
        }
    }
}
