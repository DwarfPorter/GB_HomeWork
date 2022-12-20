//Задача 2: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//5 2 6 7
//Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int Prompt(string message)
{
    System.Console.Write($"{message} > ");
    return Convert.ToInt32(Console.ReadLine());
}

int[,] GenerateMatrix()
{
    int rows = Prompt("Введите количество строк в массиве");
    int cols = Prompt("Введите количество стобцов в массиве");
    int min = Prompt("Введите порог минимальных значений");
    int max = Prompt("Введите порог максимальных значений");
    int[,] matrix = new int[rows, cols];

    for(int i = 0; i < rows; i++)
    {
        for(int j = 0; j < cols; j++)
        {
            matrix[i,j] = new Random().Next(min, max);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for(int i = 0; i < matrix.GetLength(0); i++)
    {
        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]} ");
        }
        Console.WriteLine();
    }
}

int FindMinSummString(int[,] matrix)
{
    int summ_min = Int32.MaxValue;
    int summ_local = 0;
    int number = 0;
    for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                summ_local = summ_local + matrix[i, j];
            }
            if(summ_local < summ_min) number = i;
            summ_local = 0;
        }
    return number;
}

int[,] random_matrix = GenerateMatrix();
PrintMatrix(random_matrix);
int min_string = FindMinSummString(random_matrix);
System.Console.WriteLine($"{min_string} строка с минимальной суммой элементов");
