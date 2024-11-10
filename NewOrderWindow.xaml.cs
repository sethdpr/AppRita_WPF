using System.Collections.Generic;
using System.Windows;
using static AppRita_WPF.MainWindow;

namespace AppRita_WPF
{
    public partial class NewOrderWindow : Window
    {
        public string OrderName { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }

        public NewOrderWindow()
        {
            InitializeComponent();
            OrderProducts = new List<OrderProduct>();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OrderNameTextBox.Text = OrderName;

            foreach (var product in OrderProducts)
            {
                if (product.ProductName == "Jupiler van 't vat")
                    JupQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Maes")
                    MaesQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Palm")
                    PalmQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Hoegaarden Witteke")
                    WittekeQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Leffe Bruin")
                    LeffeBruinQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Leffe Blond")
                    LeffeBlondQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Westmalle Dubbel")
                    WestmalleDubbelQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Westmalle Trippel")
                    WestmalleTrippelQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Karmeliet")
                    KarmelietQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Kriek Boon")
                    KriekBoonQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Geuze Moriau 37cl")
                    GeuzeMoriauQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Orval")
                    OrvalQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Duvel")
                    DuvelQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Carlsberg 0.0")
                    CarlsbergQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Wijn")
                    WijnQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Martini")
                    MartiniQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Porto")
                    PortoQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Hasseltse koffie")
                    HasseltseKoffieQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Waters")
                    WatersQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Cola")
                    ColaQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Cola Zero")
                    ColaZeroQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Tonic")
                    TonicQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Ice Tea")
                    IceTeaQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Fruitsap")
                    FruitsapQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Gerolsteiner")
                    GerolsteinerQuantityTextBox.Text = product.Quantity.ToString();
                else if (product.ProductName == "Koffie")
                    KoffieQuantityTextBox.Text = product.Quantity.ToString();
            }
        }
        private void SaveOrder_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OrderNameTextBox.Text))
            {
                MessageBox.Show("Vul een geldige bestellingsnaam in.");
                return;
            }

            OrderName = OrderNameTextBox.Text;
            if (!ValidateAndAddProduct("Jupiler van 't vat", JupQuantityTextBox.Text, 1.90M)) return;
            if (!ValidateAndAddProduct("Maes", MaesQuantityTextBox.Text, 1.90M)) return;
            if (!ValidateAndAddProduct("Palm", PalmQuantityTextBox.Text, 2.20M)) return;
            if (!ValidateAndAddProduct("Hoegaarden Witteke", WittekeQuantityTextBox.Text, 2.20M)) return;
            if (!ValidateAndAddProduct("Leffe Bruin", LeffeBruinQuantityTextBox.Text, 3.20M)) return;
            if (!ValidateAndAddProduct("Leffe Blond", LeffeBlondQuantityTextBox.Text, 3.20M)) return;
            if (!ValidateAndAddProduct("Westmalle Dubbel", WestmalleDubbelQuantityTextBox.Text, 3.20M)) return;
            if (!ValidateAndAddProduct("Westmalle Trippel", WestmalleTrippelQuantityTextBox.Text, 3.20M)) return;
            if (!ValidateAndAddProduct("Karmeliet", KarmelietQuantityTextBox.Text, 3.20M)) return;
            if (!ValidateAndAddProduct("Kriek Boon", KriekBoonQuantityTextBox.Text, 3.20M)) return;
            if (!ValidateAndAddProduct("Geuze Moriau", GeuzeMoriauQuantityTextBox.Text, 5.50M)) return;
            if (!ValidateAndAddProduct("Orval", OrvalQuantityTextBox.Text, 4.50M)) return;
            if (!ValidateAndAddProduct("Duvel", DuvelQuantityTextBox.Text, 3.20M)) return;
            if (!ValidateAndAddProduct("Carlsberg 0.0", CarlsbergQuantityTextBox.Text, 2.20M)) return;
            if (!ValidateAndAddProduct("Wijn", WijnQuantityTextBox.Text, 2.50M)) return;
            if (!ValidateAndAddProduct("Martini", MartiniQuantityTextBox.Text, 2.50M)) return;
            if (!ValidateAndAddProduct("Porto", PortoQuantityTextBox.Text, 2.50M)) return;
            if (!ValidateAndAddProduct("Hasseltse Koffie", HasseltseKoffieQuantityTextBox.Text, 3.50M)) return;
            if (!ValidateAndAddProduct("Waters", WatersQuantityTextBox.Text, 1.90M)) return;
            if (!ValidateAndAddProduct("Cola", ColaQuantityTextBox.Text, 1.90M)) return;
            if (!ValidateAndAddProduct("Cola Zero", ColaZeroQuantityTextBox.Text, 2.20M)) return;
            if (!ValidateAndAddProduct("Tonic", TonicQuantityTextBox.Text, 2.20M)) return;
            if (!ValidateAndAddProduct("Ice Tea", IceTeaQuantityTextBox.Text, 2.20M)) return;
            if (!ValidateAndAddProduct("Fruitsap", FruitsapQuantityTextBox.Text, 2.20M)) return;
            if (!ValidateAndAddProduct("Gerolsteiner", GerolsteinerQuantityTextBox.Text, 2.20M)) return;
            if (!ValidateAndAddProduct("Koffie", KoffieQuantityTextBox.Text, 2.50M)) return;
            this.DialogResult = true;
            this.Close();
        }
        private bool ValidateAndAddProduct(string productName, string quantityText, decimal price)
        {
            if (string.IsNullOrWhiteSpace(quantityText)) return false;

            if (int.TryParse(quantityText, out int quantity) && quantity >= 0)
            {
                OrderProducts.Add(new OrderProduct
                {
                    ProductName = productName,
                    Quantity = quantity,
                    Price = price
                });
                return true;
            }
            else
            {
                MessageBox.Show($"Gelieve een geldig aantal in te vullen voor {productName}.", "Ongeldige invoer", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
    }
}