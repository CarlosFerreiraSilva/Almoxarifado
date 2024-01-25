using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Xunit;

namespace Almoxarifado_Xunit
{
    public class UnitTest1
    {


        public IWebDriver driver { get; private set; }
        public IDictionary<String, Object> vars { get; private set; }
        public IJavaScriptExecutor js { get; private set; }
        public UnitTest1()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<String, Object>();
        }
        public void Dispose()
        {
            driver.Quit();
        }

        [Theory]
        [InlineData("20")]
        [InlineData("20")]
        public void CT03R3RequisicaoQtdItem(string valorEsperado)
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
            driver.FindElement(By.Id("Quantidade")).Click();
            driver.FindElement(By.Id("Quantidade")).SendKeys(valorEsperado);
            driver.FindElement(By.CssSelector("#BtnInserirItens > span")).Click();
            Thread.Sleep(3000);
            IWebElement tabela = driver.FindElement(By.Id("tabelaItens"));
            IWebElement celula = tabela.FindElement(By.XPath(".//tr[1]/td[3]"));
            string valorEncontrado = celula.Text;
            driver.Quit();

            Assert.Equal(valorEsperado,valorEncontrado);
        }
    }
}
