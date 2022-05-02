using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Section_16___Currency_Converter_WPF_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataTable currencyDataTable = new DataTable();

        public MainWindow()
        {
            InitializeComponent();

            BindCurrency();
        }

        private void BindCurrency()
        {
            currencyDataTable.Columns.Add("Text", typeof(string));
            currencyDataTable.Columns.Add("Value", typeof(double));

            currencyDataTable.Rows.Add("--SELECT--", 0);
            currencyDataTable.Rows.Add("USD", 1);
            currencyDataTable.Rows.Add("EUR", 2);
            currencyDataTable.Rows.Add("GBP", 3);
            currencyDataTable.Rows.Add("AED", 4);
            currencyDataTable.Rows.Add("BRL", 5);
            currencyDataTable.Rows.Add("BTC", 6);
            currencyDataTable.Rows.Add("INR", 7);
            currencyDataTable.Rows.Add("JPY", 8);
            currencyDataTable.Rows.Add("NZD", 9);
            currencyDataTable.Rows.Add("CAD", 10);
            currencyDataTable.Rows.Add("ISK", 11);
            currencyDataTable.Rows.Add("PHP", 12);
            currencyDataTable.Rows.Add("DKK", 13);
            currencyDataTable.Rows.Add("CZK", 14);

            cmbFromCurrency.ItemsSource = currencyDataTable.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = currencyDataTable.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            Convert_ClickAsync(sender, e);
        }

        private async Task Convert_ClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidateConvertInput();
            }
            catch (Exception exception)
            {
                InvalidConvertError(exception);
                return;
            }

            String convertedCurrency;

            try
            {
                await UpdateCurrencyValues();
                
                convertedCurrency = ConvertCurrency();
            }
            catch (Exception)
            {
                return;
            }

            PrintToConvertedCurrencyFieldAndClearErrorLabel(convertedCurrency);
        }

        private async Task UpdateCurrencyValues()
        {
            Root currencyData = await GetCurrencyData();

            UpdateCurrencyDataBase(currencyData);
        }

        private async Task<Root> GetCurrencyData()
        {
            string url = $"https://openexchangerates.org/api/latest.json?app_id=201bae8d0f5d4d00818150c31286f17b";

            Root val = await GetData(url);

            return val;
        }

        private static async Task<Root> GetData(string url)
        {
            var myRoot = new Root();

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<Root>(responseString);

                        return responseObject;
                    }

                    return myRoot;
                }
            }
            catch (Exception)
            {
                return myRoot;
            }
        }

        private void UpdateCurrencyDataBase(Root currencyData)
        {
            UpdateCurrencyDataBaseEntry("USD", currencyData.rates.USD);
            UpdateCurrencyDataBaseEntry("EUR", currencyData.rates.EUR);
            UpdateCurrencyDataBaseEntry("GBP", currencyData.rates.GBP);
            UpdateCurrencyDataBaseEntry("AED", currencyData.rates.AED);
            UpdateCurrencyDataBaseEntry("BRL", currencyData.rates.BRL);
            UpdateCurrencyDataBaseEntry("BTC", currencyData.rates.BTC);
            UpdateCurrencyDataBaseEntry("INR", currencyData.rates.INR);
            UpdateCurrencyDataBaseEntry("JPY", currencyData.rates.JPY);
            UpdateCurrencyDataBaseEntry("NZD", currencyData.rates.NZD);
            UpdateCurrencyDataBaseEntry("CAD", currencyData.rates.CAD);
            UpdateCurrencyDataBaseEntry("ISK", currencyData.rates.ISK);
            UpdateCurrencyDataBaseEntry("PHP", currencyData.rates.PHP);
            UpdateCurrencyDataBaseEntry("DKK", currencyData.rates.DKK);
            UpdateCurrencyDataBaseEntry("CZK", currencyData.rates.CZK);
        }

        private void UpdateCurrencyDataBaseEntry(string currency, double rate)
        {
            foreach (DataRow dr in currencyDataTable.Rows)
            {
                if (dr.Field<string>("Text") == currency)
                {
                    dr.SetField<double>("Value", rate);
                    return;
                }
            }
        }

        private void ValidateConvertInput()
        {
            bool isTxtCurrencyValid = (txtCurrency.Text != null) && (txtCurrency.Text.Trim() != "");

            if (!isTxtCurrencyValid)
            {
                throw new Exception("Please input a valid Enter Amount :");
            }

            bool isValidInputAmount = IsValidInputAmount(txtCurrency.Text);

            if (!isValidInputAmount)
            {
                throw new Exception("The Entered Amount has to be a number up to 2 d.p. without spaces( )");
            }

            bool isFromCurrencyValid = (cmbFromCurrency.SelectedValue != null) && (cmbFromCurrency.SelectedIndex != 0);

            if (!isFromCurrencyValid)
            {
                throw new Exception("Please select a valid From :");
            }

            bool isToCurrencyValid = (cmbToCurrency.SelectedValue != null) && (cmbToCurrency.SelectedIndex != 0);

            if (!isToCurrencyValid)
            {
                throw new Exception("Please select a valid To :");
            }

            bool isToAndFromCurrencyDifferent = (cmbToCurrency.Text != cmbFromCurrency.Text);

            if (!isToAndFromCurrencyDifferent)
            {
                throw new Exception("Please select different From and To currencies");
            }
        }

        private bool IsValidInputAmount(string input)
        {
            decimal inputDecimal;

            bool isAbleToParse = decimal.TryParse(input, out inputDecimal);

            if (!isAbleToParse)
            {
                return false;
            }

            if (!input.Contains("."))
            {
                return true;
            }

            Regex rx = new Regex(@"\.[0-9]{1,2}$");

            return rx.IsMatch(input);
        }

        private void InvalidConvertError(Exception exception)
        {
            PrintErrorOnLabel(exception);
            ClearConvertedCurrencyField();
        }

        private void PrintErrorOnLabel(Exception exception)
        {
            errorLabel.Content = exception.Message;
        }

        private void ClearErrorLabel()
        {
            errorLabel.Content = "";
        }

        private void PrintToConvertedCurrencyFieldAndClearErrorLabel(String text)
        {
            ClearErrorLabel();
            PrintToConvertedCurrencyField(text);
        }

        private void PrintToConvertedCurrencyField(String text)
        {
            convertedCurrencyLabel.Content = "Converted Currency:";
            lblCurrency.Content = text;
        }

        private void ClearConvertedCurrencyField()
        {
            convertedCurrencyLabel.Content = "";
            lblCurrency.Content = "";
        }

        private string ConvertCurrency()
        {
            decimal inputAmount = decimal.Parse(txtCurrency.Text);

            decimal fromCurrency = GetCurrencyValue(cmbFromCurrency.Text);
            
            decimal toCurrency = GetCurrencyValue(cmbToCurrency.Text);

            decimal convertedAmount = (inputAmount / fromCurrency) * toCurrency;

            decimal convertedAmountTo2dp = Math.Floor(convertedAmount * 100) / 100;

            string convertedCurrenyString = cmbToCurrency.Text + " " + convertedAmountTo2dp.ToString("N2");

            return convertedCurrenyString;
        }

        private decimal GetCurrencyValue(String currencyString)
        {
            foreach (DataRow dr in currencyDataTable.Rows)
            {
                if (dr.Field<string>("Text") == currencyString)
                {
                    return ((decimal) dr.Field<double>("Value"));
                }
            }
            return 0;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearErrorLabel();
            ClearConvertedCurrencyField();

            txtCurrency.Text = string.Empty;

            if (cmbFromCurrency.Items.Count > 0)
            {
                cmbFromCurrency.SelectedIndex = 0;
            }
            if (cmbToCurrency.Items.Count > 0)
            {
                cmbToCurrency.SelectedIndex = 0;
            }
        }
    }
}
