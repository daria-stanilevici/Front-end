using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string connectionString;
        public string login;
        
        SqlDataAdapter adapter;
        DataTable myTable;
        
        public Login()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String loginUser = Username.Text;
            String passUser = Password.Password;
            login = loginUser;

            string sql = "SELECT * FROM Users WHERE Login_ = @uL AND Password_ = @uP";
            myTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("@uL", SqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", SqlDbType.VarChar).Value = passUser;
                adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(myTable);

                if (myTable.Rows.Count > 0)
                {
                    MainWindow mainWindow = new MainWindow(login);
                    mainWindow.Show();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Username.Text = null;
            Password.Password = null;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Register register = new Register();
            register.Show();
        }
    }
}
