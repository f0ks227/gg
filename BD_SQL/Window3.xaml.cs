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
                    UserControl1 UserControl1 = new UserControl1();
                    UserControl1.FullName.Text = user.FullName;
                    UserControl1.Email.Text = user.Email;
                    UserControl1.PhoneNumber.Text = user.PhoneNumber;
                    UserControl1.Address.Text = user.Address;
                    UserControl1.PasswordHash.Text = user.PasswordHash;
                    var appDir = Environment.CurrentDirectory;
                    string? path = user.Picture ?? null;
                    if (path != null)
                        UserControl1.Picture.Source = new BitmapImage(new Uri(appDir + @"\Pictires\" + path));

                    UserPanel.Children.Add(UserControl1);
                }
            }
        }
    }
}
