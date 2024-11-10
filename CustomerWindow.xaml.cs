using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            LoadOrders(customer.Id);
        }

        private void LoadOrders(int customerId)
        {
            using (var context = new CafeContext())
            {
                var orders = context.Orders
                    .Where(o => o.CustomerId == customerId)
                    .Include(o => o.OrderProducts)
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
                    var existingCustomer = context.Customers.Find(customer.Id);
                    if (existingCustomer == null)
                    {
                        MessageBox.Show("De geselecteerde klant bestaat niet in de database.");
                        return;
                    }

                    var newOrder = new Order
                    {
                        CustomerId = customer.Id,
                        OrderName = newOrderWindow.OrderName,
                        OrderDate = DateTime.Now,
                        OrderProducts = newOrderWindow.OrderProducts
                    };

                    context.Orders.Add(newOrder);
                    context.SaveChanges();

                    LoadOrders(customer.Id);
                }
            }
        }
        private void OrderListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (OrderListBox.SelectedItem == null)
            {
                MessageBox.Show("Geen bestelling geselecteerd.");
                return;
            }

            if (OrderListBox.SelectedItem is Order selectedOrder)
            {
                NewOrderWindow newOrderWindow = new NewOrderWindow();

                newOrderWindow.OrderName = selectedOrder.OrderName;
                newOrderWindow.OrderProducts = selectedOrder.OrderProducts.ToList();

                if (newOrderWindow.ShowDialog() == true)
                {
                    using (var context = new CafeContext())
                    {
                        var orderToUpdate = context.Orders
                            .Include(o => o.OrderProducts)
                            .FirstOrDefault(o => o.Id == selectedOrder.Id);

                        if (orderToUpdate != null)
                        {
                            orderToUpdate.OrderName = newOrderWindow.OrderName;
                            orderToUpdate.OrderProducts = newOrderWindow.OrderProducts;

                            context.SaveChanges();
                            LoadOrders(orderToUpdate.CustomerId);
                        }
                        else
                        {
                            MessageBox.Show("De geselecteerde bestelling kon niet worden gevonden in de database.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Het geselecteerde item is geen bestelling.");
            }
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrderListBox.SelectedItem is Order selectedOrder)
            {
                using (var context = new CafeContext())
                {
                    var orderToRemove = context.Orders.Find(selectedOrder.Id);
                    if (orderToRemove != null)
                    {
                        context.Orders.Remove(orderToRemove);
                        context.SaveChanges();
                    }
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