using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Utils;

namespace ExemploConversaoTemperaturas.Testes
{
    [TestClass]
    public class Testes
    {
        [TestMethod]
        public void TestarFirefox()
        {
            TelaConversaoTemperaturas tela =
                new TelaConversaoTemperaturas(Browser.Firefox);
            tela.CarregarPagina();
            tela.PreencherTemperaturaFahrenheit(-459.67);
            tela.ProcessarConversao();
            double resultado = tela.ObterTemperaturaCelsius();
            tela.Fechar();

            Assert.AreEqual(-273.15, resultado);
        }

        [TestMethod]
        public void TestarChrome()
        {
            TelaConversaoTemperaturas tela =
                new TelaConversaoTemperaturas(Browser.Chrome);
            tela.CarregarPagina();
            tela.PreencherTemperaturaFahrenheit(32);
            tela.ProcessarConversao();
            double resultado = tela.ObterTemperaturaCelsius();
            tela.Fechar();

            Assert.AreEqual(0, resultado);
        }

        [TestMethod]
        public void TestarFirefox2()
        {
            TelaConversaoTemperaturas tela =
                new TelaConversaoTemperaturas(Browser.Firefox);
            tela.CarregarPagina();
            tela.PreencherTemperaturaFahrenheit(212);
            tela.ProcessarConversao();
            double resultado = tela.ObterTemperaturaCelsius();
            tela.Fechar();

            Assert.AreEqual(100, resultado);
        }
    }
}