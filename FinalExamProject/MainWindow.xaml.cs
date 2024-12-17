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

namespace FinalExamProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Creating a employee object for employee class
        private Employee employee = new Employee();
        public MainWindow()
        {
            InitializeComponent();
            InitializeEmployees();
        }


        // This will be called on the instantiation on the load of the application which fills the data in the datagrid
        private void InitializeEmployees()
        {
            try
            {

                // Fetch the values from the employee table using employee class and assigns to datagrid items
                employeeGrid.ItemsSource = employee.getAllEmployees().DefaultView;
                if (employeeGrid.Items.Count == 0)
                {
                    MessageBox.Show("Please insert records to view the table content");
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Exception: {ex.Message}", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // This method is used to search employees by name with entered value
        private void search_Click(object sender, RoutedEventArgs e)
        {
            searchData();
        }


        // This method is used to clear the search filed and retrives all the employee records
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            searchField.Text = string.Empty;
            searchData();
        }


        // This method is reusable and is used to get data based on serach value
        private void searchData()
        {
            try
            {
                string searchText = searchField.Text;

                // Retrives the data from the employee class based on the search criteria and updates the datagrid items based on the results
                employeeGrid.ItemsSource = employee.searchEmployeeByEmployeeName(searchText).DefaultView;

                // If the search records not matches it indicates user that there are no records with search criteria
                if (employeeGrid.Items.Count == 0)
                {
                    MessageBox.Show("No Records found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}