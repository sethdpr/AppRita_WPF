using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
using static AppRita_WPF.MainWindow;

namespace AppRita_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadCustomers();
        }

        public class Customer
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; } //Toch een kleine garantie dat mensen niet weggaan zonder te betalen

            public ICollection<Order> Orders { get; set; }
        }

        public class Order
        {
            [Key]
            public int Id { get; set; }
            public string OrderName { get; set; }
            public int CustomerId { get; set; }
            public Customer Customer { get; set; }
            public DateTime OrderDate { get; set; }
            [NotMapped]
            public decimal TotalPrice
            {
                get
                {
                    return OrderProducts?.Sum(op => op.Quantity * op.Price) ?? 0;
                }
            }

            public ICollection<OrderProduct> OrderProducts { get; set; }

            public override string ToString()
            {
                return $"{OrderName} - {OrderDate.ToShortDateString()}";
            }
        }

        public class OrderProduct
        {
            [Key]
            public int Id { get; set; }
            public Order Order { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }

        public class CafeContext : DbContext
        {
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<OrderProduct> OrderProducts { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CafeDB;Trusted_Connection=True;");
            }
        }
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();

            if (addCustomerWindow.ShowDialog() == true)
            {
                using (var context = new CafeContext())
                {
                    var newCustomer = new Customer
                    {
                        Name = addCustomerWindow.CustomerName,
                        PhoneNumber = addCustomerWindow.CustomerPhone
                    };

                    context.Customers.Add(newCustomer);
                    context.SaveChanges();

                    LoadCustomers();

                    MessageBox.Show("Klant succesvol toegevoegd!");
                }
            }
        }
        private void LoadCustomers()
        {
            using (var context = new CafeContext())
            {
                var customers = context.Customers.ToList();
                CustomerListBox.ItemsSource = customers;
            }
        }
        private void CustomerListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CustomerListBox.SelectedItem is Customer selectedCustomer)
            {
                CustomerWindow customerWindow = new CustomerWindow(selectedCustomer);
                customerWindow.Show();
            }
        }
        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerListBox.SelectedItem is Customer selectedCustomer)
            {
                using (var context = new CafeContext())
                {
                    context.Customers.Remove(selectedCustomer);
                    context.SaveChanges();
                    LoadCustomers();
                }
            }
            else
            {
                MessageBox.Show("Selecteer een klant om te verwijderen.");
            }
        }
    }
}