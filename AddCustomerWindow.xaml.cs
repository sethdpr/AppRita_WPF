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

namespace AppRita_WPF
{
    public partial class AddCustomerWindow : Window
    {
        public string CustomerName { get; private set; }
        public string CustomerPhone { get; private set; }

        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void SaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) && !string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            {
                CustomerName = NameTextBox.Text;
                CustomerPhone = PhoneTextBox.Text;
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vul zowel de naam als het telefoonnummer in.");
            }
        }
    }
}
