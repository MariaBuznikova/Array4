//В кинотеатре n рядов по m мест в каждом. В двумерном массиве хранится
//информация о проданных билетах, число 1 означает, что билет на данное место уже
//продано, число 0 означает, что место свободно. Поступил запрос на продажу k билетов на
//соседние места в одном ряду. Определите, можно ли выполнить такой запрос.
using System;

namespace Массивы4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1; int m = 1;
            int k = 1;
            //int rez = 0;
            Random r = new Random();

            do
            {
                Console.WriteLine("Введите кол-во рядов в зале");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n <= 1);
            do
            {
                Console.WriteLine("Введите кол-во мест в ряде");
                m = Convert.ToInt32(Console.ReadLine());
            } while (m <= 1);

            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = r.Next(0, 2);
                }
            }
            PrintMatrix(matrix);
            do
            {
                Console.WriteLine("Сколько мест необходимо?");
                k = Convert.ToInt32(Console.ReadLine());
            } while (k <= 1 || k > m);

            // 0 - свободно
            
            int f = 0;
            int[] rank = new int[n];
            for (int i = 0; i < n; i++)
            {
                int Count = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j - 1] == 0 && matrix[i, j - 1] == matrix[i, j])
                    {
                        Count++;
                    }
                    else
                        Count = 0;
                    
                }
                if (Count >= k - 1)
                {
                    rank[f] = 1;
                }
                else rank[f] = -1;
                f++;
                               
            }
            Vivod(rank, "Massiv");
            for(int i =0; i<rank.Length; i++)
            {
                if (rank[i]==1)
                {
                    Console.WriteLine($"Есть места в {i+1}м ряде");
                }
            }
            

        }

    


        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0}{1}", matrix[i, j], "  "));
                }
                Console.WriteLine();
            }
        }

        static void Vivod(int[] M, string msg)
        {
            if (M == null)
                return;
            else
            {
                Console.WriteLine(msg + ":");
                foreach (int el in M)
                {
                    Console.Write(el.ToString() + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
