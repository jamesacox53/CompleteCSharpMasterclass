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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Section_14___Using_Databases
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                ConnectToDatabase();
            }
            catch (Exception)
            {
                return;
            }

            ShowZoos();
            ShowAllAnimals();
        }

        private void ConnectToDatabase()
        {
            string passwordComponent = ";Password=InsertPasswordHere";

            string connectComponent = "Data Source=LAPTOP-LG6PN2GE\\JAMESMSSQLSERVER;Initial Catalog=CSharpMasterclassDB;User ID=sa";

            string connectionString = connectComponent + passwordComponent;

            sqlConnection = new SqlConnection(connectionString);
        }

        private void ShowZoos() 
        {
            SqlDataAdapter sqlData;
            try
            {
                sqlData = QueryZooTable();

                ShowZoosInWPFList(sqlData);
            }
            catch (Exception)
            {
        
            }
        }

        private SqlDataAdapter QueryZooTable ()
        {
            string query = "select * from Zoo";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            return sqlDataAdapter;
        }

        private void ShowZoosInWPFList(SqlDataAdapter sqlData) 
        {
            using (sqlData)
            {
                DataTable zooTable = new DataTable();

                sqlData.Fill(zooTable);

                ListZoos.DisplayMemberPath = "Location";
                ListZoos.SelectedValuePath = "Id";
                ListZoos.ItemsSource = zooTable.DefaultView;
            }
        }

        private void ListAllAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedAnimalInTextBox();
        }

        private void ListZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowAssociatedAnimals();
            ShowSelectedZooInTextBox();
        }

        private void ShowAssociatedAnimals()
        {
            SqlDataAdapter sqlData;
            try
            {
                sqlData = QueryZooAnimalTable();

                ShowZooAnimalsInWPFList(sqlData);
            }
            catch (Exception)
            {
              
            }
        }

        private SqlDataAdapter QueryZooAnimalTable()
        {
            string query = "select * " +
                           "from Animal a inner join ZooAnimal za " +
                           "on a.Id = za.AnimalId " +
                           "where za.ZooId = @ZooId";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);
            
            return sqlDataAdapter;
        }

        private void ShowZooAnimalsInWPFList(SqlDataAdapter sqlData)
        {
            using (sqlData)
            {
                DataTable animalTable = new DataTable();

                sqlData.Fill(animalTable);

                ListAssociatedAnimals.DisplayMemberPath = "Name";
                ListAssociatedAnimals.SelectedValuePath = "Id";
                ListAssociatedAnimals.ItemsSource = animalTable.DefaultView;
            }
        }

        private void ShowAllAnimals()
        {
            SqlDataAdapter sqlData;
            try
            {
                sqlData = QueryAnimalTable();

                ShowAnimalsInWPFList(sqlData);
            }
            catch (Exception)
            {
              
            } 
        }

        private SqlDataAdapter QueryAnimalTable()
        {
            string query = "select * from Animal";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            return sqlDataAdapter;
        }

        private void ShowAnimalsInWPFList(SqlDataAdapter sqlData)
        {
            using (sqlData)
            {
                DataTable animalTable = new DataTable();

                sqlData.Fill(animalTable);

                ListAllAnimals.DisplayMemberPath = "Name";
                ListAllAnimals.SelectedValuePath = "Id";
                ListAllAnimals.ItemsSource = animalTable.DefaultView;
            }
        }

        private void DeleteZoo_Click(object sender, RoutedEventArgs e)
        {  
            try
            {
                string query = "delete from Zoo where id = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);

                sqlCommand.ExecuteScalar();

            } catch (Exception)
            {

            } finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void AddZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Zoo values (@Location)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", myTextBox.Text);

                sqlCommand.ExecuteScalar();

            }
            catch (Exception)
            {

            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void AddAnimalToZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into ZooAnimal values (@ZooId, @AnimalId)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@AnimalId", ListAllAnimals.SelectedValue);

                sqlCommand.ExecuteScalar();

            }
            catch (Exception)
            {

            }
            finally
            {
                sqlConnection.Close();
                ShowAssociatedAnimals();
            }
        }

        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Animal where id = @AnimalId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", ListAllAnimals.SelectedValue);

                sqlCommand.ExecuteScalar();

            }
            catch (Exception)
            {

            }
            finally
            {
                sqlConnection.Close();
                ShowAllAnimals();
            }
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Animal values (@Name)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);

                sqlCommand.ExecuteScalar();

            }
            catch (Exception)
            {

            }
            finally
            {
                sqlConnection.Close();
                ShowAllAnimals();
            }
        }

        private void ShowSelectedZooInTextBox()
        {
            SqlDataAdapter sqlData;
            try
            {
                sqlData = QueryZooTableForTextBox();

                ShowDataInTextBox(sqlData, "Location");
            }
            catch (Exception)
            {

            }
        }

        private SqlDataAdapter QueryZooTableForTextBox()
        {
            string query = "select Location from Zoo where Id = @ZooId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);

            return sqlDataAdapter;
        }

        private void ShowDataInTextBox(SqlDataAdapter sqlData, String columnName)
        {
            using (sqlData)
            {
                DataTable dataTable = new DataTable();

                sqlData.Fill(dataTable);

                myTextBox.Text = dataTable.Rows[0][columnName].ToString();
            }
        }

        private void ShowSelectedAnimalInTextBox()
        {
            SqlDataAdapter sqlData;
            try
            {
                sqlData = QueryAnimalTableForTextBox();

                ShowDataInTextBox(sqlData, "Name");
            }
            catch (Exception)
            {

            }
        }

        private SqlDataAdapter QueryAnimalTableForTextBox()
        {
            string query = "select Name from Animal where Id = @AnimalId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            sqlCommand.Parameters.AddWithValue("@AnimalId", ListAllAnimals.SelectedValue);

            return sqlDataAdapter;
        }

        private void UpdateZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "update Zoo Set Location = @Location where Id = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open(); 
                sqlCommand.Parameters.AddWithValue("@Location", myTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);

                sqlCommand.ExecuteScalar();

            }
            catch (Exception)
            {

            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void UpdateAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "update Animal Set Name = @Name where Id = @AnimalId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@AnimalId", ListAllAnimals.SelectedValue);

                sqlCommand.ExecuteScalar();

            }
            catch (Exception)
            {

            }
            finally
            {
                sqlConnection.Close();
                ShowAllAnimals();
            }
        }

    }
}
