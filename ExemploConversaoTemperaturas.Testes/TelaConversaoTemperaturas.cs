using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;

namespace ExemploConversaoTemperaturas.Testes
{
    public class TelaConversaoTemperaturas
    {
        private Browser _browser;
        private IWebDriver _driver;

        public TelaConversaoTemperaturas(Browser browser)
        {
            _browser = browser;

            string caminhoDriver = null;
            if (browser == Browser.Chrome)
            {
                caminhoDriver =
                    ConfigurationManager.AppSettings["CaminhoDriverChrome"];
            }

            _driver = WebDriverFactory.CreateWebDriver(
                browser, caminhoDriver);
        }

        public void CarregarPagina()
        {
            _driver.LoadPage(
                TimeSpan.FromSeconds(30),
                ConfigurationManager.AppSettings["UrlTelaConversaoTemperaturas"]);
        }

        public void PreencherTemperaturaFahrenheit(double valor)
        {
            _driver.SetText(
                By.Name("temperaturaFahrenheit"),
                valor.ToString());
        }

        public void ProcessarConversao()
        {
            _driver.Submit(By.Id("btnConverter"));

            WebDriverWait wait = new WebDriverWait(
                _driver, TimeSpan.FromSeconds(20));
            wait.Until((d) => d.FindElement(By.ClassName("temperaturaCelsius")) != null);
        }

        public double ObterTemperaturaCelsius()
        {
            return Convert.ToDouble(
                _driver.GetText(By.ClassName("temperaturaCelsius")));
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}