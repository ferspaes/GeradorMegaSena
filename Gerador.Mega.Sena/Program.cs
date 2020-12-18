using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Gerador.Mega.Sena
{
    class Program
    {
        static void Main(string[] args)
        {
            string palavraMenorNumero = string.Empty;
            string palavraMaiorNumero = string.Empty;
            string palavraQuantidadeNumeros = string.Empty;
            string palavraQuantidadeDeJogadas = string.Empty;
            int menorNumero = 0;
            int maiorNumero = 0;
            int quantidadeDeNumeros = 0;
            int quantidadeDeJogadas = 0;
            var jogadas = new List<string>();

            PulaLinha();
            PulaLinha();
            PulaLinha();
            PulaLinha();

            var caracteres = "             -= Gerador de números aleatórios para a Sorte! =-".ToCharArray();

            EscreverLinha(caracteres);
            PulaLinha();
            PulaLinha();
            PequenaPausa();

            caracteres = "     Primeiro vamos entender qual é o espaço entre o MENOR e o MAIOR número a serem gerados!".ToCharArray();

            EscreverLinha(caracteres);
            PulaLinha();
            PequenaPausa();
            PulaLinha();

            while (menorNumero == 0)
            {
                caracteres = "     Por favor digite o MENOR número possível a ser gerado e pressione a tecla Enter:".ToCharArray();
                EscreverLinha(caracteres);

                PulaLinha();
                PulaLinha();
                Espaco();

                palavraMenorNumero = Console.ReadLine();
                Int32.TryParse(palavraMenorNumero, out menorNumero);
            }

            PulaLinha();

            while (maiorNumero == 0)
            {
                caracteres = "     Por favor digite o MAIOR número possível a ser gerado e pressione a tecla Enter:".ToCharArray();
                EscreverLinha(caracteres);

                PulaLinha();
                PulaLinha();
                Espaco();

                palavraMaiorNumero = Console.ReadLine();
                Int32.TryParse(palavraMaiorNumero, out maiorNumero);
            }

            PulaLinha();

            if (maiorNumero < menorNumero)
            {
                int inversao = maiorNumero;
                maiorNumero = menorNumero;
                menorNumero = inversao;
            }

            while (quantidadeDeNumeros == 0)
            {
                caracteres = "     Por favor me diga quantos números você precisa agora?".ToCharArray();
                EscreverLinha(caracteres);

                PulaLinha();
                PulaLinha();
                Espaco();

                palavraQuantidadeNumeros = Console.ReadLine();
                Int32.TryParse(palavraQuantidadeNumeros, out quantidadeDeNumeros);
            }

            PulaLinha();

            while (quantidadeDeJogadas == 0)
            {
                caracteres = "     Por favor me diga quantas jogadas você precisa agora?".ToCharArray();
                EscreverLinha(caracteres);

                PulaLinha();
                PulaLinha();
                Espaco();

                palavraQuantidadeDeJogadas = Console.ReadLine();
                Int32.TryParse(palavraQuantidadeDeJogadas, out quantidadeDeJogadas);
            }

            PulaLinha();

            caracteres = $"     Entendido iremos agora gerar as suas {quantidadeDeJogadas} jogadas, contendo {quantidadeDeNumeros} números da sorte cada, no intervalo entre {menorNumero} e {maiorNumero}!".ToCharArray();
            EscreverLinha(caracteres);

            PulaLinha();

            PequenaPausa();

            PulaLinha();

            var numerosDaSorte = new List<string>();

            while (jogadas.Count < quantidadeDeJogadas)
            {
                while (numerosDaSorte.Count < quantidadeDeNumeros)
                {
                    var random = new Random();
                    string numeroDaSorte = random.Next(menorNumero, maiorNumero).ToString();
                    numeroDaSorte = Convert.ToInt32(numeroDaSorte) < 10 ? $"0{numeroDaSorte}" : numeroDaSorte;

                    if (!numerosDaSorte.Contains(numeroDaSorte.ToString()))
                        numerosDaSorte.Add(numeroDaSorte.ToString());
                }

                numerosDaSorte = numerosDaSorte.OrderBy(x => x).ToList();

                string jogada = string.Join(" - ", numerosDaSorte);

                if (!jogadas.Contains(jogada))
                    jogadas.Add(jogada.ToString());

                numerosDaSorte.Clear();
            }

            PulaLinha();

            foreach (var sorte in jogadas)
            {
                caracteres = $"     >> ".ToCharArray();
                Escrever(caracteres);

                caracteres = sorte.ToCharArray();

                EscreverLinha(caracteres);

                caracteres = $" <<".ToCharArray();
                Escrever(caracteres);
                PulaLinha();

                MenorPausa();
            }

            PulaLinha();
            PulaLinha();

            PequenaPausa();
            caracteres = $"     Aqui estão as suas {quantidadeDeJogadas} jogadas, contendo {quantidadeDeNumeros} números da sorte cada!".ToCharArray();
            EscreverLinha(caracteres);
            PulaLinha();
            PulaLinha();
            caracteres = "     Boa Sorte!".ToCharArray();
            EscreverLinha(caracteres);
            PulaLinha();
            PulaLinha();

            Console.WriteLine("     Pressione qualquer tecla para sair...");
            Console.Read();
        }

        private static void MenorPausa()
        {
            Thread.Sleep(800);
        }

        private static void Escrever(char[] caracteres)
        {
            Console.Write(caracteres);
        }

        private static void Espaco()
        {
            Console.Write("     ");
        }

        private static void PequenaPausa()
        {
            Thread.Sleep(1800);
        }

        private static void PulaLinha()
        {
            Console.WriteLine();
        }

        private static void EscreverLinha(char[] caracteres)
        {
            foreach (var caracter in caracteres)
            {
                Thread.Sleep(12);
                Console.Write(caracter);
            }
        }
    }
}
