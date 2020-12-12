using System;
using System.Collections.Generic;
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
            int menorNumero = 0;
            int maiorNumero = 0;
            int quantidadeDeNumeros = 0;

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

            caracteres = $"     Entendido iremos agora gerar os seus {quantidadeDeNumeros} números da sorte, no intervalo entre {menorNumero} e {maiorNumero}!".ToCharArray();
            EscreverLinha(caracteres);

            PulaLinha();

            PequenaPausa();

            PulaLinha();

            var numerosDaSorte = new List<string>();

            while (numerosDaSorte.Count < quantidadeDeNumeros)
            {
                var random = new Random();
                string numeroDaSorte = random.Next(menorNumero, maiorNumero).ToString();
                numeroDaSorte = Convert.ToInt32(numeroDaSorte) < 10 ? $"0{numeroDaSorte}" : numeroDaSorte;

                if (!numerosDaSorte.Contains(numeroDaSorte.ToString()))
                    numerosDaSorte.Add(numeroDaSorte.ToString());
            }

            PulaLinha();

            int i = 0;

            caracteres = $"     >>".ToCharArray();
            Escrever(caracteres);

            foreach (var numeroDaSorte in numerosDaSorte)
            {
                i++;

                if (i == 1)
                    caracteres = $" {numeroDaSorte}".ToCharArray();
                if (i > 1)
                    caracteres = $" - {numeroDaSorte} ".ToCharArray();

                EscreverLinha(caracteres);
                MenorPausa();
            }

            caracteres = $"<<".ToCharArray();
            Escrever(caracteres);

            PulaLinha();
            PulaLinha();

            PequenaPausa();
            caracteres = $"     Aqui estão os seus {quantidadeDeNumeros} números da sorte!".ToCharArray();
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
            Thread.Sleep(1000);
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
            Thread.Sleep(2000);
        }

        private static void PulaLinha()
        {
            Console.WriteLine();
        }

        private static void EscreverLinha(char[] caracteres)
        {
            foreach (var caracter in caracteres)
            {
                Thread.Sleep(20);
                Console.Write(caracter);
            }
        }
    }
}
