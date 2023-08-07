using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.XtraReports.UI;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   string currentTable;
        string connectionString;
        string nameUser;
        SqlDataAdapter adapter;
        DataTable myTable;

        public MainWindow(string name)
        {
            InitializeComponent();
            MyDataGrid.IsReadOnly = true;
            nameUser = name;

            //connectionString = @"Server=DORICHAU\SQLEXPRESS;Trusted_Connection=Yes;DataBase=Theatre;";
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            Add_bt.Visibility = Visibility.Hidden;
            Delete_bt.Visibility = Visibility.Hidden;
            Save_bt.Visibility = Visibility.Hidden;
            Backup_bt.Visibility = Visibility.Hidden;
            Report_bt.Visibility = Visibility.Hidden;
            Map.Visibility = Visibility.Hidden;
            first_tb.Visibility = Visibility.Hidden;
            second_tb.Visibility = Visibility.Hidden;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Restore_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Add_bt_Click(object sender, RoutedEventArgs e)
        {
            MyDataGrid.IsReadOnly = false;
        }

        private void Delete_bt_Click(object sender, RoutedEventArgs e)
        {
            MyDataGrid.IsReadOnly = true;

            if (MyDataGrid.SelectedItems != null)
            {
                for (int i = 0; i < MyDataGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = MyDataGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
        }

        private void Save_bt_Click(object sender, RoutedEventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(myTable);
            MyDataGrid.IsReadOnly = true;
        }

        private void Employments_bt_Click(object sender, RoutedEventArgs e)
        {
            currentTable = "Actors_Performances";

            Add_bt.Visibility = Visibility.Visible;
            Delete_bt.Visibility = Visibility.Visible;
            Save_bt.Visibility = Visibility.Visible;
            Backup_bt.Visibility = Visibility.Visible;
            Report_bt.Visibility = Visibility.Visible;

            MyDataGrid.Visibility = Visibility.Visible;
            RepView.Visibility = Visibility.Hidden;
            Map.Visibility = Visibility.Hidden;
            first_tb.Visibility = Visibility.Hidden;
            second_tb.Visibility = Visibility.Hidden;

            Search.Text = null;

            Add_bt.IsEnabled = true;
            Delete_bt.IsEnabled = true;
            Save_bt.IsEnabled = true;

            string sql = "SELECT * FROM Actors_Performances";
            myTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(myTable);
            MyDataGrid.ItemsSource = myTable.DefaultView;

            if (connection != null)
                connection.Close();
        }

        private void Users_bt_Click(object sender, RoutedEventArgs e)
        {
            currentTable = "Users";

            MyDataGrid.Visibility = Visibility.Visible;
            RepView.Visibility = Visibility.Hidden;
            Map.Visibility = Visibility.Hidden;
            first_tb.Visibility = Visibility.Hidden;
            second_tb.Visibility = Visibility.Hidden;

            Search.Text = null;
            Add_bt.IsEnabled = false;
            Delete_bt.IsEnabled = false;
            Save_bt.IsEnabled = false;

            MyDataGrid.IsReadOnly = true;
            string sql = "SELECT * FROM Users";
            myTable = new DataTable();
            SqlConnection connection = null;


            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(myTable);
            MyDataGrid.ItemsSource = myTable.DefaultView;

            if (connection != null)
                connection.Close();
        }

        private void Genres_bt_Click(object sender, RoutedEventArgs e)
        {
            currentTable = "Genres";
            Add_bt.Visibility = Visibility.Visible;
            Delete_bt.Visibility = Visibility.Visible;
            Save_bt.Visibility = Visibility.Visible;
            Backup_bt.Visibility = Visibility.Visible;
            Report_bt.Visibility = Visibility.Visible;

            MyDataGrid.Visibility = Visibility.Visible;
            RepView.Visibility = Visibility.Hidden;
            Map.Visibility = Visibility.Hidden;
            first_tb.Visibility = Visibility.Hidden;
            second_tb.Visibility = Visibility.Hidden;

            Search.Text = null;

            Add_bt.IsEnabled = true;
            Delete_bt.IsEnabled = true;
            Save_bt.IsEnabled = true;

            string sql = "SELECT * FROM Genres";
            myTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(myTable);
            MyDataGrid.ItemsSource = myTable.DefaultView;

            if (connection != null)
                connection.Close();
        }

        private void Shows_bt_Click(object sender, RoutedEventArgs e)
        {
            currentTable = "Representations";

            Add_bt.Visibility = Visibility.Visible;
            Delete_bt.Visibility = Visibility.Visible;
            Save_bt.Visibility = Visibility.Visible;
            Backup_bt.Visibility = Visibility.Visible;
            Report_bt.Visibility = Visibility.Visible;

            MyDataGrid.Visibility = Visibility.Visible;
            RepView.Visibility = Visibility.Hidden;
            Map.Visibility = Visibility.Hidden;
            first_tb.Visibility = Visibility.Hidden;
            second_tb.Visibility = Visibility.Hidden;

            Search.Text = null;

            Add_bt.IsEnabled = true;
            Delete_bt.IsEnabled = true;
            Save_bt.IsEnabled = true;

            string sql = "SELECT * FROM Representations";
            myTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(myTable);
            MyDataGrid.ItemsSource = myTable.DefaultView;

            if (connection != null)
                connection.Close();
        }

        private void Ranks_bt_Click(object sender, RoutedEventArgs e)
        {
            currentTable = "Ranks";

            Add_bt.Visibility = Visibility.Visible;
            Delete_bt.Visibility = Visibility.Visible;
            Save_bt.Visibility = Visibility.Visible;
            Backup_bt.Visibility = Visibility.Visible;
            Report_bt.Visibility = Visibility.Visible;

            MyDataGrid.Visibility = Visibility.Visible;
            RepView.Visibility = Visibility.Hidden;
            Map.Visibility = Visibility.Hidden;
            first_tb.Visibility = Visibility.Hidden;
            second_tb.Visibility = Visibility.Hidden;
            Search.Text = null;

            Add_bt.IsEnabled = true;
            Delete_bt.IsEnabled = true;
            Save_bt.IsEnabled = true;

            MyDataGrid.IsReadOnly = true;
            string sql = "SELECT * FROM Ranks";
            myTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(myTable);
            MyDataGrid.ItemsSource = myTable.DefaultView;

            if (connection != null)
                connection.Close();
        }

        private void Actors_bt_Click(object sender, RoutedEventArgs e)
        {
            currentTable = "Actors";

            Add_bt.Visibility = Visibility.Visible;
            Delete_bt.Visibility = Visibility.Visible;
            Save_bt.Visibility = Visibility.Visible;
            Backup_bt.Visibility = Visibility.Visible;
            Report_bt.Visibility = Visibility.Visible;

            MyDataGrid.Visibility = Visibility.Visible;
            RepView.Visibility = Visibility.Hidden;
            Map.Visibility = Visibility.Hidden;
            first_tb.Visibility = Visibility.Hidden;
            second_tb.Visibility = Visibility.Hidden;
            Search.Text = null;

            Add_bt.IsEnabled = true;
            Delete_bt.IsEnabled = true;
            Save_bt.IsEnabled = true;

            string sql = "SELECT * FROM Actors";
            myTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(myTable);
            MyDataGrid.ItemsSource = myTable.DefaultView;

            if (connection != null)
                connection.Close();
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            if (e.PropertyName == "Image_")
            {
                FrameworkElementFactory image = new FrameworkElementFactory(typeof(Image));
                image.SetBinding(Image.SourceProperty, new Binding(e.PropertyName));
                image.SetValue(Image.WidthProperty, 100.0);
                image.SetValue(Image.HeightProperty, 100.0);

                e.Column = new DataGridTemplateColumn
                {
                    CellTemplate = new DataTemplate() { VisualTree = image },
                    Header = e.PropertyName
                };
            }
        }

        private async void CreateBackupButton(object sender, RoutedEventArgs e)
        {
            string FilePath = "";
            bool SaveFileDialog()
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Database backups files (*.bak)|*.bak";
                if (saveFileDialog.ShowDialog() == true)
                {
                    FilePath = saveFileDialog.FileName;
                    System.Console.WriteLine(FilePath);
                    return true;
                }
                return false;
            }

            if (SaveFileDialog())
            {
                SqlConnection connection = null;
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    string query = "BACKUP DATABASE Theatre TO DISK = N'" + FilePath + "' WITH NOFORMAT, NOINIT, NAME = N'Theatre-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        await cmd.ExecuteNonQueryAsync();
                        MessageBox.Show("Успешное создание резервной копиии!\nПуть к файлу резервной копии: " + FilePath, "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private async void RestoreBackupButton_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = "";
            bool OpenFileDialog()
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Database backups files (*.bak)|*.bak";
                if (openFileDialog.ShowDialog() == true)
                {
                    FilePath = openFileDialog.FileName;
                    System.Console.WriteLine(FilePath);
                    return true;
                }
                return false;
            }

            if (OpenFileDialog())
            {
                SqlConnection connection = null;
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    string query = "USE master RESTORE DATABASE Theatre FROM DISK = N'" + FilePath + "' WITH FILE = 1, NOUNLOAD, STATS = 5";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        await
                        cmd.ExecuteNonQueryAsync();
                        MessageBox.Show("Успешное восстановление резервной копиии", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void Report_bt_Click(object sender, RoutedEventArgs e)
        {
            MyDataGrid.Visibility = Visibility.Hidden;
            RepView.Visibility = Visibility.Visible;
            Add_bt.Visibility = Visibility.Hidden;
            Delete_bt.Visibility = Visibility.Hidden;
            Save_bt.Visibility = Visibility.Hidden;
            Map.Visibility = Visibility.Hidden;
            first_tb.Visibility = Visibility.Hidden;
            second_tb.Visibility = Visibility.Hidden;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string searchstring = textBox.Text;
            string sql = "select * from krea";
            switch (currentTable)
            {
                case "Actors_Performances":
                     sql = "SELECT * FROM Actors_Performances Where Role_ Like '" + searchstring + "%'";
                    break;
                case "Actors":
                     sql = "SELECT * FROM Actors Where Last_Name Like '" + searchstring + "%'";
                    break;
                case "Ranks":
                     sql = "SELECT * FROM Ranks Where Title_Rank Like '" + searchstring + "%'";
                    break;
                case "Representations":
                     sql = "SELECT * FROM Representations Where Title_Representation Like '" + searchstring + "%'";
                    break;
                case "Genres":
                    sql = "SELECT * FROM Genres Where Title_Genre Like '" + searchstring + "%'";
                    break;
                case "Users":
                    sql = "SELECT * FROM Users Where Login_ Like '" + searchstring + "%'";
                    break;   
            }
            myTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(myTable);
            MyDataGrid.ItemsSource = myTable.DefaultView;

            if (connection != null)
                connection.Close();
        }

        private void View_bt_Click(object sender, RoutedEventArgs e)
        {
            currentTable = "RepGenres";

            Add_bt.Visibility = Visibility.Visible;
            Delete_bt.Visibility = Visibility.Visible;
            Save_bt.Visibility = Visibility.Visible;
            Backup_bt.Visibility = Visibility.Visible;
            Report_bt.Visibility = Visibility.Visible;

            MyDataGrid.Visibility = Visibility.Visible;
            RepView.Visibility = Visibility.Hidden;
            Map.Visibility = Visibility.Hidden;
            first_tb.Visibility = Visibility.Hidden;
            second_tb.Visibility = Visibility.Hidden;
            Search.Text = null;

            string sql = "SELECT * FROM RepGenres";
            myTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(myTable);
            MyDataGrid.ItemsSource = myTable.DefaultView;

            if (connection != null)
                connection.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            AddName.Text += "Welcome, " + nameUser + "!";
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MyDataGrid.Visibility = Visibility.Hidden;
            Add_bt.Visibility = Visibility.Hidden;
            Delete_bt.Visibility = Visibility.Hidden;
            Save_bt.Visibility = Visibility.Hidden;
            Backup_bt.Visibility = Visibility.Hidden;
            Report_bt.Visibility = Visibility.Hidden;
            Request_bt.Visibility = Visibility.Hidden;

            Map.Visibility = Visibility.Visible;
            first_tb.Visibility = Visibility.Visible;
            second_tb.Visibility = Visibility.Visible;
        }

        private void Request_bt_Click(object sender, RoutedEventArgs e)
        {
            string sql = "select Count(Title_Representation) as CheapShows From Representations where Budget< 100000";
            myTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(myTable);
            MyDataGrid.ItemsSource = myTable.DefaultView;

            if (connection != null)
                connection.Close();
        }
    }
}