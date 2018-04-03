using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrawlerExemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Google();
            // VivaReal();
            VivaReal2();
        }

        private static void Google()
        {
            var url = "http://www.google.com.br/search?q=resource+it"; //passa a url
            var web = new HtmlWeb();
            var doc = web.Load(url); //pega o codigo fonte da url
            var resultado = doc.GetElementbyId("resultStats").InnerText; // retorna por id específico
            Console.WriteLine(resultado); // escreve na tela a saida
            Console.ReadLine();
            var docNode = doc.DocumentNode;

            var node = docNode.SelectNodes("//div[@id = 'search']"); //pega a div pai e quebra todas as div filhos dela e cria uma collection

            foreach (var nNode in node.Descendants("a")) // pega os descentendes de cada filho que possuem o "a" (link
            {
                Console.WriteLine(nNode.GetAttributeValue("href", "")); //pega o valor do href

            }
        }

        private static void VivaReal()
        {
            var url = "http://www.vivareal.com.br/venda/sp/sao-paulo/centro/bela-vista/apartamento_residencial/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var docNode = doc.DocumentNode;

            var node = docNode.SelectNodes("//div[@class = 'results-list js-results-list']"); //pega a div com a determinada classe e quebra

            foreach (var nNode in node.Descendants("div").Where(n => n.Attributes.Contains("class"))) // pega cada div filho que contem class
            {

                string descricao;
                //descricao = nNode
                //    .Descendants("div")
                //    .Where(n => n.Attributes["class"].Value
                //    == "property-card__description js-property-description")
                //    .First()
                //    .InnerText.Trim();

                //ou


                if (nNode.Attributes["class"].Value
                      == "property-card__description js-property-description")
                {
                    descricao = nNode.InnerText; //nNode gera uma collection

                    Console.WriteLine(descricao); // escreve na tela a saida

                    Console.ReadLine();
                }


            }


        }

        private static void VivaReal2()
        {

            var url = "http://www.vivareal.com.br/venda/sp/sao-paulo/centro/bela-vista/apartamento_residencial/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var docNode = doc.DocumentNode;

            var node = docNode.SelectNodes("//div[@class = 'js-card-selector']");

            foreach (var nNode in node)
            {
                string titulo = nNode.Descendants("a").Where(n => n.Attributes["class"].Value == "property-card__title js-cardLink js-card-title").Single().InnerText.Replace("\n", "").Trim();
                string end = nNode.Descendants("span").FirstOrDefault().InnerText.Replace("\n", "").Trim();
                string preco = nNode.Descendants("div").Where(n => n.Attributes["class"].Value == "property-card__price js-property-card-prices js-property-card__price-small").FirstOrDefault().InnerText.Replace("\n", "").Trim();

                Console.WriteLine(titulo + "\n" + end + "\n" + preco + "\n");
                Console.ReadKey();
            }

        }
    }
}

      
