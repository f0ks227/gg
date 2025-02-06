using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata;
namespace BD_SQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string conStr = @"Data Source=(localdb)\gg; Initial Catalog=fastcat; Integrated Security=true; Trusted_Connection=True; TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * from Customers", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                Output.Clear();
                if (reader.HasRows)
                {
                    // Перебираем строки
                    while (reader.Read())
                    {
                        // Перебираем все столбцы в текущей строке
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            // Добавляем имя столбца и его значение
                            Output.Text += reader.GetName(i) + ": " + reader.GetValue(i).ToString() + "\t";
                        }
                        // Добавляем перенос строки после каждой строки данных
                        Output.Text += Environment.NewLine;
                    }
                }
                else
                {
                    MessageBox.Show("íè÷å íåò");
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (FastcatContext db = new FastcatContext())
            {
                if (db.Customers.ToList().Where(x => x.FullName == userName.Text && x.PasswordHash == userPass.Password).Count() != 0) {

                    Window3 window3 = new Window3();
                    window3.Show();
                    
                }
                else
                {
                    MessageBox.Show("NO no no");
                }
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
            {

            }

            private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
            {

            }
        }
    } 