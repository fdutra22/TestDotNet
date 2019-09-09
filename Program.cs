using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.Utils;

namespace TesteDotNet
{
    /// <summary>
    /// Classe principaml com o metodo main.
    /// </summary>
    class Program
    {
        public static bool continua = false;
        static void Main(string[] args)
        {

            EscreveConsole("Seja Bem Vindo!");
            MsgOperacaoes();

            while (continua)
            {
                var entrada = Console.ReadLine();

                var nums = entrada.Split(";");
                //swith para a escolha do usuario das operações.
                switch (nums[0].ToString())
                {

                    case "1":
                        if (nums.Length == 3)
                        {
                            var resultadoSoma = Soma(double.Parse(nums[1]), double.Parse(nums[2]));
                            EscreveConsole("O Resultado da operação foi: " + resultadoSoma);
                        }
                        else if (nums.Length > 3)
                        {
                            var listaDouble = Array.ConvertAll(nums, element => double.Parse(element));
                            var listaNumeros = listaDouble.ToList();
                            listaNumeros.RemoveAt(0);
                            var resultadoSoma = Soma(listaNumeros);
                            EscreveConsole("O Resultado da operação foi: " + resultadoSoma);
                            EscreveConsole("Deseja exibir a Média? (S) sim, (N) não ou (P) para médias dos numeros pares");
                            var key = Console.ReadKey();
                            if (key.Key == ConsoleKey.S)
                            {
                                var resultadoMedia = MediaSoma(listaNumeros);
                                EscreveConsole("O Resultado da média foi: " + resultadoMedia);
                            }

                            if (key.Key == ConsoleKey.P)
                            {
                                var resultadoMedia = MediaSomaPares(listaNumeros);
                                EscreveConsole("O Resultado da média foi: " + resultadoMedia);
                            }

                        }
                        MsgContinua();
                        break;
                    case "2":
                        var resultadoSubtracao = Subtracao(double.Parse(nums[1]), double.Parse(nums[2]));
                        EscreveConsole("O Resultado da operação foi: " + resultadoSubtracao);
                        MsgContinua();
                        break;
                    case "3":
                        var resultadoMutliplicacao = Multiplicacao(double.Parse(nums[1]), double.Parse(nums[2]));
                        EscreveConsole("O Resultado da operação foi: " + resultadoMutliplicacao);
                        MsgContinua();
                        break;
                    case "4":
                        var resultadoDivisao = Divisao(double.Parse(nums[1]), double.Parse(nums[2]));
                        EscreveConsole("O Resultado da operação foi: " + resultadoDivisao);
                        MsgContinua();
                        break;

                    case "5":
                        new LerArquivo();
                        break;
                    default:
                        EscreveConsole("\n  Argumento inválido");
                        MsgContinua();
                        break;
                }
            }


        }


        /// <summary>
        /// Methodo para Calcular a Soma.
        /// </summary>
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
                EscreveConsole("Erro ao executar a Soma; Valores: " + n1 + " - " + n2);
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }

        /// <summary>
        /// Sobrecarga do Methodo para Calcular a Soma de n números.
        /// </summary>
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
                    EscreveConsole("Erro ao executar a Soma; Valor: " + item);
                }
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }
       


        /// <summary>
        /// Methodo para Calcular a Subtração.
        /// </summary>
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
                EscreveConsole("Erro ao executar a Subtração; Valores: " + n1 + " - " + n2);
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }

        /// <summary>
        /// Methodo para Calcular a Multiplicação.
        /// </summary>
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
                EscreveConsole("Erro ao executar a Mutliplicação; Valores: " + n1 + " - " + n2);
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }

        
        /// <summary>
        /// Methodo para Calcular a Divisão.
        /// </summary>
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
                EscreveConsole("Erro ao executar a Divisão; Valores: " + n1 + " - " + n2);
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }

        /// <summary>
        /// Methodo para calcular a media da soma.
        /// </summary>
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
                    EscreveConsole("Erro ao executar a Media da Soma; Valor: " + item);
                }
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }

        /// <summary>
        /// Methodo para calcular a media da soma de numeros pares.
        /// </summary>
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
                    EscreveConsole("Erro ao executar a Media da Soma; Valor: " + item);
                }
                Console.ResetColor();
                MsgOperacaoes();
            }
            return resultado;
        }

        /// <summary>
        /// Methodo para a escolha das operações.
        /// </summary>
        public static void MsgOperacaoes()
        {
            continua = true;
            Task.Delay(1000).Wait();
            EscreveConsole("Você pode executar as 4 operações básicas: \n" +
                "(1 Soma - 2 Subtração - 3 Multiplicação - 4 Divisão ou 5 para ler o arquivo" +
                " \n escolha um número e passe os valores ex: 1;numero1;numero2" +
                "\n Obs: Para a soma você pode escolher mais que 2 numeros, ex: 1;2;2......;n;");
        }

        /// <summary>
        /// Methodo para continua com as operaçoes.
        /// </summary>
        public static void MsgContinua()
        {

            Task.Delay(1000).Wait();
            EscreveConsole("Pressione qualquer tecla para continuar ou ESC para sair \n");

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                EscreveConsole(" OObrigado por utilizar nossa calculadora");
                Environment.Exit(0);
            }
            else
            {
                continua = true;
            }
        }


        /// <summary>
        /// Escreve no console, printa na tela.
        /// </summary>
        public static void EscreveConsole(string text)
        {
            Console.Write("{0}", text);
        }

        /// <summary>
        /// Methodo para colocar em vermelho as mensagem de erro.
        /// </summary>
        public static void ChangeColor()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
        }
       
    }
}
