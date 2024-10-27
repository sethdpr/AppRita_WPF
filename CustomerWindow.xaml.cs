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
using static AppRita_WPF.MainWindow;

namespace AppRita_WPF
{
    public partial class CustomerWindow : Window
    {

        private Customer customer;
        public CustomerWindow(Customer customer)
        {
            InitializeComponent();

            this.customer = customer;
            CustomerNameTextBlock.Text = customer.Name;
            CustomerPhoneTextBlock.Text = customer.PhoneNumber;
        }

        private void LoadOrders(int customerId)
        {
            using (var context = new CafeContext())
            {
                var orders = context.Orders
                    .Where(o => o.Id == customerId)
                    .ToList();

                OrderListBox.ItemsSource = orders;
            }
        }

        private void NewOrder_Click(object sender, RoutedEventArgs e)
        {
            NewOrderWindow newOrderWindow = new NewOrderWindow();

            if (newOrderWindow.ShowDialog() == true)
            {
                using (var context = new CafeContext())
                {
                    var newOrder = new Order
                    {
                        Id = customer.Id,
                        OrderName = newOrderWindow.OrderName,
                        OrderDate = DateTime.Now,
                        IsCompleted = false,
                    };

                    context.Orders.Add(newOrder);
                    context.SaveChanges();

                    foreach (var product in newOrderWindow.OrderProducts)
                    {
                        product.Id = newOrder.Id;
                        context.OrderProducts.Add(product);
                    }

                    context.SaveChanges();

                    LoadOrders(customer.Id);
                }
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
                using (var context = new CafeContext())
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                    LoadCustomers();
                    OrderListBox.ItemsSource = null;
                }
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrderListBox.SelectedItem is Order selectedOrder)
            {
                using (var context = new CafeContext())
                {
                    context.Orders.Remove(selectedOrder);
                    context.SaveChanges();
                    LoadOrders(customer.Id);
                }
            }
            else
            {
                MessageBox.Show("Selecteer een bestelling om te verwijderen.");
            }
        }

        private void LoadCustomers()
        {
            using (var context = new CafeContext())
            {
                var customers = context.Customers.ToList();

            }
        }
    }
}