using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet
{

    class Program
    {
        public static bool continua = false;
        static void Main(string[] args)
        {

            Console.WriteLine("Seja Bem Vindo!");
            MsgOperacaoes();

            while (continua)
            {
                var entrada = Console.ReadLine();

                var nums = entrada.Split(";");
                switch (nums[0].ToString())
                {

                    case "1":
                        if (nums.Length == 3)
                        {
                            var resultadoSoma = Soma(double.Parse(nums[1]), double.Parse(nums[2]));
                            Console.WriteLine("O Resultado da operação foi: " + resultadoSoma);
                        }
                        else if (nums.Length > 3)
                        {
                            var listaDouble = Array.ConvertAll(nums, element => double.Parse(element));
                            var listaNumeros = listaDouble.ToList();
                            listaNumeros.RemoveAt(0);
                            var resultadoSoma = Soma(listaNumeros);
                            Console.WriteLine("O Resultado da operação foi: " + resultadoSoma);
                            Console.WriteLine("Deseja exibir a Média? (S) sim, (N) não ou (P) para médias dos numeros pares");
                            var key = Console.ReadKey();
                            if (key.Key == ConsoleKey.S)
                            {
                                var resultadoMedia = MediaSoma(listaNumeros);
                                Console.WriteLine("O Resultado da média foi: " + resultadoMedia);
                            }

                            if (key.Key == ConsoleKey.P)
                            {
                                var resultadoMedia = MediaSomaPares(listaNumeros);
                                Console.WriteLine("O Resultado da média foi: " + resultadoMedia);
                            }

                        }
                        MsgContinua();
                        break;
                    case "2":
                        var resultadoSubtracao = Subtracao(double.Parse(nums[1]), double.Parse(nums[2]));
                        Console.WriteLine("O Resultado da operação foi: " + resultadoSubtracao);
                        MsgContinua();
                        break;
                    case "3":
                        var resultadoMutliplicacao = Multiplicacao(double.Parse(nums[1]), double.Parse(nums[2]));
                        Console.WriteLine("O Resultado da operação foi: " + resultadoMutliplicacao);
                        MsgContinua();
                        break;
                    case "4":
                        var resultadoDivisao = Divisao(double.Parse(nums[1]), double.Parse(nums[2]));
                        Console.WriteLine("O Resultado da operação foi: " + resultadoDivisao);
                        MsgContinua();
                        break;

                    case "5":
                        LerArquivo();
                        break;
                    default:
                        Console.WriteLine("\n  Argumento inválido");
                        MsgContinua();
                        break;
                }
            }


        }

        public static double Soma(double n1, double n2)
        {
            double resultado = 0.0;
            try
            {
                resultado = n1 + n2;
            }
            catch (Exception ex)
            {
                ChangeColor();
                Console.WriteLine("Erro ao executar a Soma; Valores: " + n1 + " - " + n2);
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }

        public static double Soma(List<double> ns)
        {
            double resultado = 0.0;
            try
            {
                resultado = ns.Sum(x => Convert.ToDouble(x));
            }
            catch (Exception ex)
            {
                ChangeColor();
                foreach (var item in ns)
                {
                    Console.WriteLine("Erro ao executar a Soma; Valor: " + item);
                }
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }

        public static double Subtracao(double n1, double n2)
        {
            double resultado = 0.0;
            try
            {
                resultado = n1 - n2;
            }
            catch (Exception ex)
            {
                ChangeColor();
                Console.WriteLine("Erro ao executar a Subtração; Valores: " + n1 + " - " + n2);
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }

        public static double Multiplicacao(double n1, double n2)
        {
            double resultado = 0.0;
            try
            {
                resultado = n1 * n2;
            }
            catch (Exception ex)
            {
                ChangeColor();
                Console.WriteLine("Erro ao executar a Mutliplicação; Valores: " + n1 + " - " + n2);
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }

        public static double Divisao(double n1, double n2)
        {
            double resultado = 0.0;
            try
            {
                resultado = n1 / n2;
            }
            catch (Exception ex)
            {
                ChangeColor();
                Console.WriteLine("Erro ao executar a Divisão; Valores: " + n1 + " - " + n2);
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }


        public static double MediaSoma(List<double> ns)
        {
            double resultado = 0.0;
            try
            {
                resultado = ns.Average(innerList => innerList);
            }
            catch (Exception ex)
            {
                ChangeColor();
                foreach (var item in ns)
                {
                    Console.WriteLine("Erro ao executar a Media da Soma; Valor: " + item);
                }
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }

        public static double MediaSomaPares(List<double> ns)
        {
            double resultado = 0.0;
            var nPares = new List<Double>();
            try
            {
                foreach (var item in ns)
                {
                    if (item % 2 == 0)//operador %
                    {
                        nPares.Add(item);
                    }
                }

                resultado = nPares.Average(innerList => innerList);
            }
            catch (Exception ex)
            {
                ChangeColor();
                foreach (var item in ns)
                {
                    Console.WriteLine("Erro ao executar a Media da Soma; Valor: " + item);
                }
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }


        public static void MsgOperacaoes()
        {
            continua = true;
            Task.Delay(1000).Wait();
            Console.WriteLine("Você pode executar as 4 operações básicas: \n" +
                "(1 Soma - 2 Subtração - 3 Multiplicação - 4 Divisão ou 5 para ler o arquivo" +
                " \n escolha um número e passe os valores ex: 1;numero1;numero2" +
                "\n Obs: Para a soma você pode escolher mais que 2 numeros, ex: 1;2;2......;n;");
        }

        public static void MsgContinua()
        {

            Task.Delay(1000).Wait();
            Console.WriteLine("Pressione qualquer tecla para continuar ou ESC para sair \n");

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                Console.Write("{0}", " OObrigado por utilizar nossa calculadora");
                Environment.Exit(0);
            }
            else
            {
                continua = true;
            }
        }

        public static void ChangeColor()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void LerArquivo()
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
                    if (item.Contains("Soma"))
                    {
                        if (nums.Length == 4)
                        {
                            var resultadoSoma = Soma(double.Parse(nums[2]), double.Parse(nums[3]));

                            dicionario.Add(nome, resultadoSoma);
                        }
                        else
                        {
                            var novaLista = nums.Where(val => val != nums[0] && val != nums[1]).ToArray();
                            var listaDouble = Array.ConvertAll(novaLista, element => double.Parse(element));
                            var listaNumeros = listaDouble.ToList();
           
                            var resultadoSoma = Soma(listaNumeros);
                            dicionario.Add(nome, resultadoSoma);
                        }
                    }

                    if (item.Contains("Divis"))
                    {
                        var resultadoDivisaso = Divisao(double.Parse(nums[2]), double.Parse(nums[3]));
                        dicionario.Add(nome, resultadoDivisaso);
                    }

                    if (item.Contains("Subtra"))
                    {
                        var resultadoSubtracao = Subtracao(double.Parse(nums[2]), double.Parse(nums[3]));
                        dicionario.Add(nome, resultadoSubtracao);

                    }

                    if (item.Contains("Multipl"))
                    {
                        var resultadoMultiplicacao = Multiplicacao(double.Parse(nums[2]), double.Parse(nums[3]));
                        dicionario.Add(nome, resultadoMultiplicacao);

                    }
                }

                foreach(var item in dicionario)
                {
                    Console.WriteLine("Resultado de: " + item.Key + " = " + item.Value);
                }
            }catch(Exception ex)
            {
                Console.Write("{0}", " erro ao executar o arquivo");
            }
        }
    }
}
