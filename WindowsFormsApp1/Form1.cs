using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private IWebDriver driver;
        public Form1()
        {
            InitializeComponent();
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications"); // Noņem popup logus kā 3md
            driver = new ChromeDriver(@"C:\CS\Exam2024\chromedriver_win32\", chromeOptions);
            driver.Url = "https://www.ebay.com"; // Palaižot projektu atver pārlūkprogrammā ebay.com mājaslapu 
        }

        private void searchButton(object sender, EventArgs e)
        {
            string keyWord = searchField.Text;
            driver.FindElement(By.Id("gh-ac")).Clear(); // not;ira lauku, lai meklējot citu ierakstu nav concat

            IWebElement Searchbar = driver.FindElement(By.Id("gh-ac")); //(meklēšanas loga elementa id ir "gh-ac"
            Searchbar.SendKeys(keyWord);

            IWebElement ebayButton = driver.FindElement(By.Id("gh-btn")); //(meklēšanas pogas elementa id ir "gh-btn"
            ebayButton.Click();

            searchLinkField.Text = driver.Url; //pievieno saiti uz meklēšanas rezultātu link to search result laukā, 
            searchHistoryBox.AppendText(searchLinkField.Text + Environment.NewLine); //pievieno saiti meklēšanas sarakstam Search history laukā.
        }

        private void backButton(object sender, EventArgs e)
        {
            driver.Navigate().Back();
            driver.FindElement(By.Id("gh-ac")).Clear();
            searchField.Clear();
            searchLinkField.Clear();
        }

        private void closeButton(object sender, EventArgs e)
        {
            driver.Quit(); //Aizver pārlūkprogrammu
        }
    }
}
