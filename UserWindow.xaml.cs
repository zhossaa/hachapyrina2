﻿using System;
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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=hachapyrina2;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand($"INSERT INTO [Каталог] ([марка], [модель], [код состояния], [цена]) VALUES ( '{marka.Text}', '{model.Text}', '2', '{count.Text}')", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void refresh_click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=hachapyrina2; Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [Каталог]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Каталог");
                sda.Fill(dt);
                user.ItemsSource = dt.DefaultView;
            }
        }

        private void user_Loaded(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=hachapyrina2;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [Каталог]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Каталог");
                sda.Fill(dt);
               user.ItemsSource = dt.DefaultView;
            }
        }
    }
}
