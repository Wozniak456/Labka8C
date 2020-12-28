using System;

namespace Labka8C
{
    class Program
    {
        static int[,] InputMatrix(int numberRows, int numberCols) // Генерація матриці за допомогою рандому
        {
            Random rnd = new Random();

            int[,] matrix = new int[numberRows, numberCols];
            for (int i = 0; i < numberRows; i++)
            {
                for (int j = 0; j < numberCols; j++)
                {
                    matrix[i, j] = rnd.Next(15)-6;
                }
            }
            return matrix; 
        }
        static void PrintMatrix(int[,] matrix) // Виведення матриці
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]}\t");
                }
                Console.WriteLine();
            }
        }
        static int Sum_f(int[,] matrix) // Знаходження суми модулів елементів головної діагоналі, якщо перший елемент в рядку < 0
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,0] < 0) 
                {
                    sum += Math.Abs(matrix[i, i]);
                }
            }
            return sum;
        }
        static int Min_sum_matrix(int[,] matrix1, int[,] matrix2, int[,] matrix3) // Знаходження індекса матриці, чия сума на гол. діагоналі найменша
        {
            int minInd = 1; int minSum = Sum_f(matrix1);
            int sum = Sum_f(matrix2);
            if (sum < minSum)
            {
                minInd = 2;
                minSum = sum;
            }
            sum = Sum_f(matrix3);
            if (sum < minSum)
            {
                minInd = 3;
                minSum = sum;
            }
            Console.WriteLine($"Матриця пiд номером [{minInd}] має мiнiмальну суму елементiв на гол. дiагоналi, чий рядок починається з елемента < 0. Сума таких елементiв: {minSum} ");
            return minInd;
        }
        static int[,] SortMatrix (int[,] matrix)
        {
            for (int k = 0; k < matrix.GetLength(0); k++) // за рядками
            {
                for (int i = 0; i < matrix.GetLength(1) - 1; i++) // за стовпцями
                {        //пошук мінімального елемента
                    int min = i; 
                    for (int j = i + 1; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[k,j] < matrix[k,min])
                        {
                            min = j;
                        }
                    }    //обмін елементів
                    int temp = matrix[k,min]; 
                    matrix[k,min] = matrix[k,i];
                    matrix[k,i] = temp;
                }
            }
            
            return matrix;
        } 
        static void Main(string[] args)
        {
            Console.WriteLine("Возняк Софiя, IС-01, Варiант 7");
            Console.Write("Введiть кiлькiсть рядкiв/стовпцiв: ");
            int number_m = Convert.ToInt32(Console.ReadLine());
            int[,] Matrix_1 = InputMatrix(number_m,number_m);
            int[,] Matrix_2 = InputMatrix(number_m,number_m);
            int[,] Matrix_3 = InputMatrix(number_m,number_m);
            Console.WriteLine("Матриця 1: ");
            PrintMatrix(Matrix_1);
            Console.WriteLine("Матриця 2: ");
            PrintMatrix(Matrix_2);
            Console.WriteLine("Матриця 3: ");
            PrintMatrix(Matrix_3);
            switch (Min_sum_matrix(Matrix_1, Matrix_2, Matrix_3))
            {
                case 1:
                    PrintMatrix(SortMatrix(Matrix_1));
                    break;
                case 2:
                    PrintMatrix(SortMatrix(Matrix_2));
                    break;
                case 3:
                    PrintMatrix(SortMatrix(Matrix_3));
                    break;
            }
        }
    }
}
