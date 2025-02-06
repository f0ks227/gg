using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BD_SQL
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

    

        private void UserPane_Loaded(object sender, RoutedEventArgs e)
        {
            using (FastcatContext db = new FastcatContext())
            {
                var customers = db.Customers.ToList();
                foreach (var user in customers)
                {
                    ControlUser userControl = new ControlUser();
                    userControl.FullName.Text = user.FullName;
                    userControl.Email.Text = user.Email;
                    userControl.PhoneNumber.Text = user.PhoneNumber;
                    userControl.Address.Text = user.Address;
                    userControl.PasswordHash.Text = user.PasswordHash;

                    UserPanel.Children.Add(userControl);
                }
            }
        }
    }
}
