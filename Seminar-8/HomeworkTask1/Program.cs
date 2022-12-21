//Задача 1: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//В итоге получается вот такой массив:
//7 4 2 1
//9 5 3 2
//8 4 4 2

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

int[,] SortArrayLines(int[,] matrix)
{
    int temp = 0;
    for(int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        {
            for (int k = j + 1; k < matrix.GetLength(1); k++)
            {
                if (matrix[i,j] < matrix[i,k])
                {
                    Swap(matrix, i, j, i, k);
                }
            }
        }
    }
    return matrix;
}

void Swap(int[,] baseArray, int i1, int j1, int i2, int j2)
{
    (baseArray[i1,j1], baseArray[i2, j2])=(baseArray[i2,j2], baseArray[i1,j1]);
}

int[,] array = GenerateMatrix();
PrintMatrix(array);
Console.WriteLine();
int[,] sorted_array = SortArrayLines(array);
PrintMatrix(sorted_array);
