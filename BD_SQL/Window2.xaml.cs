using Microsoft.Data.SqlClient;
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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window

    {
        private string conStr = @"Data Source=(localdb)\gg; Initial Catalog=fastcat; Integrated Security=true; Trusted_Connection=True; TrustServerCertificate=True;";
        public Window2()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем значения из текстовых полей
            string productName = textBoxProductName.Text;
            string description = textBoxDescription.Text;
            decimal price;
            int stockQuantity;

            // Проверка конвертации price и stockQuantity
            if (!decimal.TryParse(textBoxPrice.Text, out price))
            {
                MessageBox.Show("Введите корректное значение для цены.");
                return;
            }

            if (!int.TryParse(textBoxStockQuantity.Text, out stockQuantity))
            {
                MessageBox.Show("Введите корректное количество на складе.");
                return;
            }

            // Запрос на вставку данных в таблицу Products
            string query = "INSERT INTO Products (ProductName, Description, Price, StockQuantity) VALUES (@productName, @description, @price, @stockQuantity)";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@productName", productName);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@stockQuantity", stockQuantity);

                // Выполнение команды
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно добавлены!");
            }
        }
    
    }
}