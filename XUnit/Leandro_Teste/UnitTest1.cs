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

namespace Leandro_Teste
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
        [Fact]
        public void TesteCT01()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.CssSelector(".button-save")).Click();
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("idDepartamento")).SendKeys("2");
            driver.FindElement(By.CssSelector(".camposPrincipaisLinha2")).Click();
            driver.FindElement(By.Id("NomeFuncionario")).Click();
            driver.FindElement(By.Id("NomeFuncionario")).SendKeys("5fd");
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                dropdown.FindElement(By.XPath("//option[. = 'Cliente']")).Click();
            }
            driver.FindElement(By.CssSelector(".button-save")).Click();
            Dispose();
        }

        [Fact]
        public void TesteCT02()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("idDepartamento")).Click();
            Dispose();
        }

        [Fact]
        public void TesteCT03()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("idDepartamento")).SendKeys("1");
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("idDepartamento")).SendKeys("0");
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("idDepartamento")).SendKeys("-1");
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("idDepartamento")).SendKeys("-2");
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("idDepartamento")).SendKeys("-3");
            driver.FindElement(By.Id("idDepartamento")).Click();
            Dispose();
        }

        [Fact]
        public void TesteCT04()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                dropdown.FindElement(By.XPath("//option[. = 'Gestão']")).Click();
            }
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                dropdown.FindElement(By.XPath("//option[. = 'Cliente']")).Click();
            }
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                dropdown.FindElement(By.XPath("//option[. = 'RP']")).Click();
            }
            Dispose();
        }

        [Fact]
        public void TesteCT05()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                dropdown.FindElement(By.XPath("//option[. = 'Gestão']")).Click();
            }
            driver.FindElement(By.Id("Motivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("Motivo"));
                dropdown.FindElement(By.XPath("//option[. = 'Planejamento']")).Click();
            }
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                dropdown.FindElement(By.XPath("//option[. = 'Cliente']")).Click();
            }
            driver.FindElement(By.Id("Motivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("Motivo"));
                dropdown.FindElement(By.XPath("//option[. = 'Financeiro']")).Click();
            }
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                dropdown.FindElement(By.XPath("//option[. = 'RP']")).Click();
            }
            driver.FindElement(By.Id("Motivo")).Click();
            Dispose();
        }

        [Fact]
        public void TesteCT06()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("idDepartamento")).SendKeys("1");
            driver.FindElement(By.CssSelector(".camposPrincipaisLinha1")).Click();
            driver.FindElement(By.Id("idDepartamento")).SendKeys("2");
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("idDepartamento")).SendKeys("3");
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("idDepartamento")).SendKeys("4");
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("idDepartamento")).SendKeys("40");
            driver.FindElement(By.CssSelector(".camposPrincipaisLinha1")).Click();
            Dispose();
        }

        [Fact]
        public void TesteCT07()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("NomeFuncionario")).Click();
            driver.FindElement(By.Id("NomeFuncionario")).SendKeys("Pedro");
            driver.FindElement(By.CssSelector(".camposPrincipaisLinha2")).Click();
            Dispose();
        }

        [Fact]
        public void TesteCT08()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
            driver.FindElement(By.CssSelector(".camposItens > div:nth-child(3)")).Click();
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys("2");
            driver.FindElement(By.CssSelector(".box-total")).Click();
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys("3");
            driver.FindElement(By.CssSelector(".box-total")).Click();
            Dispose();
        }

        [Fact]
        public void TesteCT09()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("Saida")).Click();
            driver.FindElement(By.Id("Saida")).SendKeys("100");
            driver.FindElement(By.CssSelector(".camposItens > div:nth-child(3)")).Click();
            Dispose();
        }

        [Fact]
        public void TesteCT10()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("Saida")).Click();
            driver.FindElement(By.Id("Saida")).SendKeys("-10");
            Dispose();
        }

        [Fact]
        public void TesteCT11()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.CssSelector(".button-save")).Click();
            Dispose();
        }

        [Fact]
        public void TesteCT12()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("urgente")).Click();
            driver.FindElement(By.Id("medio")).Click();
            driver.FindElement(By.Id("baixo")).Click();
            Dispose();
        }

        [Fact]
        public void TesteCT13()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
            driver.FindElement(By.CssSelector(".itensRequisicao > div:nth-child(2)")).Click();
            driver.FindElement(By.Id("Saida")).Click();
            driver.FindElement(By.Id("Saida")).SendKeys("9");
            driver.FindElement(By.CssSelector(".BtnInserirItens")).Click();
            Dispose();
        }

        [Fact]
        public void TesteCT14()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("corEstoque")).Click();
            Dispose();
        }
    }
}