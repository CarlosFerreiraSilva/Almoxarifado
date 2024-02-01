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
        public void TesteCT01ValidarTeladeRequisição()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.CssSelector(".button-save")).Click();

            var resultadoEsperadoObrigatorio = "solid red";
            var resultadoEsperadoNaoObrigatorio = "solid var(--Grey-200, #e3e6eb)";

            try
            {
                var id = driver.FindElement(By.Id("idDepartamento")).GetAttribute("style");
                Assert.Contains(resultadoEsperadoObrigatorio, id);

                var departamento = driver.FindElement(By.Id("departamento")).GetAttribute("style");
                Assert.Contains(resultadoEsperadoObrigatorio, departamento);

                var data = driver.FindElement(By.Id("dataRequesicao")).GetAttribute("style");
                Assert.Contains(resultadoEsperadoObrigatorio, data);

                var idFunc = driver.FindElement(By.Id("idFuncionario")).GetAttribute("style");
                Assert.Contains(resultadoEsperadoObrigatorio, idFunc);

                var cargo = driver.FindElement(By.Id("cargo")).GetAttribute("style");
                Assert.Contains(resultadoEsperadoObrigatorio, cargo);

                var categoriaMotivo = driver.FindElement(By.Id("categoriaMotivo")).GetAttribute("style");
                Assert.Contains(resultadoEsperadoObrigatorio, categoriaMotivo);

                var motivo = driver.FindElement(By.Id("Motivo")).GetAttribute("style");
                Assert.Contains(resultadoEsperadoObrigatorio, motivo);

                var nomeFunc = driver.FindElement(By.Id("NomeFuncionario")).GetAttribute("style");
                Assert.Contains(resultadoEsperadoNaoObrigatorio, nomeFunc);
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }

            Dispose();
        }

        [Fact]
        public void TesteCT02SelecionadoVerde()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("idDepartamento")).Click();
            var resultadoEsperado = "green";

            try
            {
                var id = driver.FindElement(By.Id("idDepartamento")).GetAttribute("style");
                Assert.Contains(resultadoEsperado, id);
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }
     

            Dispose();
        }

        [Fact]
        public void TesteCT03ValidarCampoID()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
 


            driver.FindElement(By.Id("idDepartamento")).SendKeys("-3");
            driver.FindElement(By.Id("idDepartamento")).Click();

            try
            {
                var resultadonegativo = true;
                var valor2 = Convert.ToInt32(driver.FindElement(By.Id("idDepartamento")).GetAttribute("value"));
                if (valor2 < 0)
                {
                    resultadonegativo = false;
                }
                Assert.True(resultadonegativo);
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }


            Dispose();
        }

        [Fact]
        public void TesteCT04CategoriaMotivo()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

            var resultadoEsperado1 = "Gestão";
            var resultadoEsperado2 = "Cliente";
            var resultadoEsperado3 = "RP";
        
            try
            {
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'Gestão']")).Click();
                    var valor1 = dropdown.FindElement(By.XPath("//option[. = 'Gestão']")).GetProperty("innerHTML");
                    Assert.Equal(resultadoEsperado1, valor1);
                }
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'Cliente']")).Click();
                    var valor2 = dropdown.FindElement(By.XPath("//option[. = 'Cliente']")).GetProperty("innerHTML");
                    Assert.Equal(resultadoEsperado2, valor2);
                }
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'RP']")).Click();
                    var valor3 = dropdown.FindElement(By.XPath("//option[. = 'RP']")).GetProperty("innerHTML");
                    Assert.Equal(resultadoEsperado3, valor3);
                }
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }
            Dispose();
        }

        [Fact]
        public void TesteCT05Motivo()
        {
            var resultadoEsperado1 = "Planejamento";
            var resultadoEsperado2 = "Financeiro";

            try
            {
                driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
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
                    var valor1 = dropdown.FindElement(By.XPath("//option[. = 'Planejamento']")).GetProperty("innerHTML");
                    Assert.Equal(resultadoEsperado1, valor1);
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
                    var valor2 = dropdown.FindElement(By.XPath("//option[. = 'Financeiro']")).GetProperty("innerHTML");
                    Assert.Equal(resultadoEsperado2, valor2);
                }
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'RP']")).Click();
                }
                driver.FindElement(By.Id("Motivo")).Click();
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }
 
            Dispose();
        }

        [Fact]
        public void TesteCT06Departamento()
        {
            var resultadoEsperadoDepartamento = "Administração";

            driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("idDepartamento")).SendKeys("1");
            driver.FindElement(By.CssSelector(".camposPrincipaisLinha1")).Click();

            try
            {
                var valor1 = driver.FindElement(By.Id("departamento")).GetAttribute("value");
                Assert.Equal(resultadoEsperadoDepartamento, valor1);
            }
            catch (Exception)
            {

                Dispose();
                throw;
            }

            Dispose();
        }

        [Fact]
        public void TesteCT07Funcionário()

        {
            var resultadoEsperado = "Anderson";
            try
            {
                driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
                driver.FindElement(By.Id("idFuncionario")).Click();
                driver.FindElement(By.Id("idFuncionario")).SendKeys("1");
                driver.FindElement(By.Id("NomeFuncionario")).Click();
                driver.FindElement(By.Id("NomeFuncionario")).SendKeys("Pedro");
                var valor1 = driver.FindElement(By.Id("NomeFuncionario")).GetAttribute("value");
                driver.FindElement(By.CssSelector(".camposPrincipaisLinha2")).Click();
                Assert.Equal(resultadoEsperado,valor1);
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }

            Dispose();
        }

        [Fact]
        public void TesteCT08Produto()
        {
            var resultadoEsperadoDescricao = "Papel A4";
            var resultadoEsperadoEstoque = "10";
            try
            {
                driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
                driver.FindElement(By.CssSelector(".camposItens > div:nth-child(3)")).Click();
                var valor1 = driver.FindElement(By.Id("DescricaoProduto")).GetAttribute("value");
                var valor2 = driver.FindElement(By.Id("Estoque")).GetAttribute("value");

                Assert.Equal(resultadoEsperadoDescricao, valor1);
                Assert.Equal(resultadoEsperadoEstoque, valor2);
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }

            
            Dispose();
        }

        [Fact]
        public void TesteCT09Quantidade()
        {
            bool valorEsperado = true;
            try
            {
                driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
                driver.FindElement(By.Id("Saida")).Click();
                driver.FindElement(By.Id("Saida")).SendKeys("100");
                driver.FindElement(By.CssSelector(".camposItens > div:nth-child(3)")).Click();
                driver.FindElement(By.Id("Saida")).Click();
                driver.FindElement(By.Id("Saida")).SendKeys("-0");
                var valor1 = Convert.ToInt32(driver.FindElement(By.Id("Saida")).GetAttribute("value"));
                if (valor1 == 10)
                {
                    valorEsperado = false;
                }
                Assert.True(valorEsperado);
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }
           
            Dispose();
        }

        [Fact]
        public void TesteCT10ValidarCampoQuantidade()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            driver.FindElement(By.Id("Saida")).Click();
            driver.FindElement(By.Id("Saida")).SendKeys("-10");
            
            try
            {
                bool valorEsperado = true;
                var valor1 = Convert.ToInt32(driver.FindElement(By.Id("Saida")).GetAttribute("value"));
                if (valor1 < 0)
                {
                    valorEsperado = false;
                }
                Assert.IsType<int>(valor1);
                Assert.True(valorEsperado);
            }
            catch (Exception)
            {

                Dispose();
                throw;
            }

            Dispose();
        }

        [Fact]
        public void TesteCT11BotãoGravar()
        {
            var valorNaoEsperado = "disabled";
            var resultado = false;
            driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
            try
            {
               var valor = driver.FindElement(By.CssSelector(".button-save")).GetProperty("disabled");
                if (valor.Contains(valorNaoEsperado))
                {
                    resultado = true;
                }
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }
            Assert.True(resultado);

            Dispose();
        }


        [Fact]
        public void TesteCT13Estoque()
        {
            //Jujuba, estoque minimo = 30

            try
            {
                driver.Navigate().GoToUrl("http://127.0.0.1:5501/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("4");
                driver.FindElement(By.CssSelector(".grupoProdutoDescricao")).Click();
                driver.FindElement(By.Id("Saida")).Click();
                driver.FindElement(By.Id("Saida")).SendKeys("10");
                driver.FindElement(By.Id("button-add")).Click();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("4");
                driver.FindElement(By.CssSelector(".linhaAdicionarItens")).Click();

                var valorEsperado1 = "rgb(0, 210, 34);";
                var verde = driver.FindElement(By.Id("corEstoque")).GetAttribute("style");
                Assert.Contains(valorEsperado1, verde);

                driver.FindElement(By.CssSelector(".excluir")).Click();
                driver.FindElement(By.Id("Saida")).Click();
                driver.FindElement(By.Id("Saida")).SendKeys("23");
                driver.FindElement(By.Id("button-add")).Click();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("4");
                driver.FindElement(By.CssSelector(".linhaAdicionarItens")).Click();

                var valorEsperado2 = "yellow;";
                var amarelo = driver.FindElement(By.Id("corEstoque")).GetAttribute("style");
                Assert.Contains(valorEsperado2, amarelo);

                driver.FindElement(By.CssSelector(".excluir")).Click();
                driver.FindElement(By.Id("Saida")).Click();
                driver.FindElement(By.Id("Saida")).SendKeys("40");
                driver.FindElement(By.Id("button-add")).Click();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("4");
                driver.FindElement(By.CssSelector(".linhaAdicionarItens")).Click();

                var valorEsperado3 = "rgb(146, 3, 12);";
                var vermelho = driver.FindElement(By.Id("corEstoque")).GetAttribute("style");
                Assert.Contains(valorEsperado3, vermelho);

           
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }
            Dispose();
        }


      
        

    }
}