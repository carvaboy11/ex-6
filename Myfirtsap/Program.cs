using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        const int tamanho = 1000;
        int[] vetor = GeradorValores.GerarValoresUnicos(tamanho);

        Console.WriteLine("🔢 Vetor desordenado (10 primeiros valores):");
        Util.ImprimirVetor(vetor, 10);

        Stopwatch stopwatch = Stopwatch.StartNew();

        Ordenador.BubbleSort(vetor);

        stopwatch.Stop();

        Console.WriteLine("\n✅ Vetor ordenado (10 primeiros valores):");
        Util.ImprimirVetor(vetor, 10);

        Console.WriteLine($"\n⏱️ Tempo de execução: {stopwatch.ElapsedMilliseconds} ms");

        // Estatísticas
        Console.WriteLine($"\n📊 Estatísticas:");
        Console.WriteLine($"Menor valor: {vetor.First()}");
        Console.WriteLine($"Maior valor: {vetor.Last()}");
        Console.WriteLine($"Média: {vetor.Average():F2}");
    }
}

static class GeradorValores
{
    public static int[] GerarValoresUnicos(int quantidade)
    {
        HashSet<int> valores = new HashSet<int>();
        Random random = new Random();

        while (valores.Count < quantidade)
        {
            valores.Add(random.Next(0, 10000)); 
        }

        return valores.ToArray();
    }
}

static class Ordenador
{
    public static void BubbleSort(int[] vetor)
    {
        int n = vetor.Length;
        bool trocou;

        for (int i = 0; i < n - 1; i++)
        {
            trocou = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (vetor[j] > vetor[j + 1])
                {
                    (vetor[j], vetor[j + 1]) = (vetor[j + 1], vetor[j]);
                    trocou = true;
                }
            }

            if (!trocou) break; 
        }
    }
}

static class Util
{
    public static void ImprimirVetor(int[] vetor, int quantidade)
    {
        for (int i = 0; i < Math.Min(quantidade, vetor.Length); i++)
        {
            Console.Write(vetor[i] + " ");
        }
        Console.WriteLine();
    }
}
