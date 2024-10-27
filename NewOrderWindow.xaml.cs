using System.Collections.Generic;
using System.Windows;
using static AppRita_WPF.MainWindow;

namespace AppRita_WPF
{
    public partial class NewOrderWindow : Window
    {
        public string OrderName { get; private set; }
        public List<OrderProduct> OrderProducts { get; private set; }

        public NewOrderWindow()
        {
            InitializeComponent();
            OrderProducts = new List<OrderProduct>();
        }

        private void SaveOrder_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OrderNameTextBox.Text))
            {
                MessageBox.Show("Vul een geldige bestellingsnaam in.");
                return;
            }

            OrderName = OrderNameTextBox.Text;

            if (!string.IsNullOrWhiteSpace(Product1QuantityTextBox.Text))
            {
                OrderProducts.Add(new OrderProduct
                {
                    ProductName = "Product 1",
                    Quantity = int.TryParse(Product1QuantityTextBox.Text, out int p1) ? p1 : 0,
                    Price = 10
                });
            }

            if (!string.IsNullOrWhiteSpace(Product2QuantityTextBox.Text))
            {
                OrderProducts.Add(new OrderProduct
                {
                    ProductName = "Product 2",
                    Quantity = int.TryParse(Product2QuantityTextBox.Text, out int p2) ? p2 : 0,
                    Price = 20
                });
            }

            if (!string.IsNullOrWhiteSpace(Product3QuantityTextBox.Text))
            {
                OrderProducts.Add(new OrderProduct
                {
                    ProductName = "Product 3",
                    Quantity = int.TryParse(Product3QuantityTextBox.Text, out int p3) ? p3 : 0,
                    Price = 30
                });
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}