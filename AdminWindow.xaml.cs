using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace hachapyrina2._0
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }




        private void admin_Loaded(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=hachapyrina2;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [Пользователи]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Пользователи");
                sda.Fill(dt);
                admin.ItemsSource = dt.DefaultView;
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=hachapyrina2;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand($"INSERT INTO [Пользователи] ([Должность], [Логин], [Пароль]) VALUES ('3', '{login.Text}', '{password.Text}' )", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (admin.SelectedItem != null)
            {
                DataRowView row = (DataRowView)admin.SelectedItem;
                int id = (int)row["код"];
                string deleteQuery = "DELETE FROM [Пользователи] WHERE ID = @код";
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=hachapyrina2;Integrated Security=True"))
                {
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@код", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=hachapyrina2; Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [Пользователи]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Пользователи");
                sda.Fill(dt);
                admin.ItemsSource = dt.DefaultView;
            }
        }

        private void arman_Loaded(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=hachapyrina2;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [Каталог]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Каталог");
                sda.Fill(dt);
                arman.ItemsSource = dt.DefaultView;
            }
        }

        private void add_Click_2(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=hachapyrina2;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand($"INSERT INTO [Каталог] ([Марка], [Модель], [Состояние], [Цена]) VALUES ( '{marka.Text}', '{model.Text}', '{sostoyan.Text}', '{count.Text}')", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void delete_Click_2(object sender, RoutedEventArgs e)
        {
            if (admin.SelectedItem != null)
            {
                DataRowView row = (DataRowView)arman.SelectedItem;
                int id = (int)row["id"];
                string deleteQuery = "DELETE FROM [Каталог] WHERE ID = @код";
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=hachapyrina2;Integrated Security=True"))
                {
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@код", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }


        }

        private void refresh_Click_2(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=hachapyrina2; Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [Каталог]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Каталог");
                sda.Fill(dt);
                arman.ItemsSource = dt.DefaultView;
            }
        }

       
            
    }
}

