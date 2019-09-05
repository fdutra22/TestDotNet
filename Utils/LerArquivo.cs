using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteDotNet.Utils
{
    //Clase para ler um arquivo.
    public class LerArquivo
    {
        public  LerArquivo()
        {

            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"..\..\..\arquivo.txt", Encoding.UTF8);

                var dicionario = new Dictionary<string, double>();
                System.Console.WriteLine("Conteúdo = ");
                foreach (string line in lines)
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    Console.WriteLine("\t" + line);
                }

                foreach (var item in lines)
                {
                    var nums = item.Split(";");
                    var nome = nums[0];

                    //se for soma
                    if (item.Contains("Soma"))
                    {
                        if (nums.Length == 4)
                        {
                            var resultadoSoma = Program.Soma(double.Parse(nums[2]), double.Parse(nums[3]));

                            dicionario.Add(nome, resultadoSoma);
                        }
                        else
                        {
                            var novaLista = nums.Where(val => val != nums[0] && val != nums[1]).ToArray();
                            var listaDouble = Array.ConvertAll(novaLista, element => double.Parse(element));
                            var listaNumeros = listaDouble.ToList();

                            var resultadoSoma = Program.Soma(listaNumeros);
                            dicionario.Add(nome, resultadoSoma);
                        }
                    }

                    //Se contem divisao
                    if (item.Contains("Divis"))
                    {
                        var resultadoDivisaso = Program.Divisao(double.Parse(nums[2]), double.Parse(nums[3]));
                        dicionario.Add(nome, resultadoDivisaso);
                    }

                    //se contais subtração
                    if (item.Contains("Subtra"))
                    {
                        var resultadoSubtracao = Program.Subtracao(double.Parse(nums[2]), double.Parse(nums[3]));
                        dicionario.Add(nome, resultadoSubtracao);

                    }

                    //se for multiplicacao
                    if (item.Contains("Multipl"))
                    {
                        var resultadoMultiplicacao = Program.Multiplicacao(double.Parse(nums[2]), double.Parse(nums[3]));
                        dicionario.Add(nome, resultadoMultiplicacao);

                    }
                }

                foreach (var item in dicionario)
                {
                    Console.WriteLine("Resultado de: " + item.Key + " = " + item.Value);
                }
            }
            catch (Exception ex)
            {
                Console.Write("{0}", " erro ao executar o arquivo");
            }
        }
    }
}
