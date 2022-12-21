//Задача 3: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
//Например, даны 2 матрицы:
//2 4 1 | 3 4
//3 2 1 | 3 3
//_ _ _ | 1 1
//Результирующая матрица будет:
//19 21
//16 19

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

void PrintMatrixMultiplicationView(int[,] matrixA, int[,] matrixB)
{
    int rows = 0;
    if(matrixA.GetLength(0) > matrixB.GetLength(0)) rows = matrixA.GetLength(0);
    else rows = matrixB.GetLength(0); //Определяем в какой матрице больше строк

    for(int i = 0; i < rows; i++)
    {
        PrintMatrixRow(matrixA, i);
        Console.Write("| ");
        PrintMatrixRow(matrixB, i);
        Console.WriteLine();
    }
}

void PrintMatrixRow(int[,] matrix, int row)  //Выводит строку матрицы, если в матрице такой строки нет, выводит пустую строку
{
    for(int j = 0; j < matrix.GetLength(1); j++)
    {
        if(row < matrix.GetLength(0)) 
        {
            Console.Write($"{matrix[row,j]} ");
        }
        else 
        {
            Console.Write("_ ");           
        }
    }
}

bool ValidateMatrix(int[,] matrixA, int[,] matrixB)
{
    if(matrixA.GetLength(1) == matrixB.GetLength(0)) return true;
    Console.WriteLine("Решения не существует");
    return false;
}

int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
{
    int[,] matrixAB = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
    for(int i = 0; i < matrixAB.GetLength(0); i++)
    {
        for(int j = 0; j < matrixAB.GetLength(1); j++)
        {
            NewMatrixElement(matrixAB, matrixA, matrixB, i, j);
        }
    }
    return matrixAB;
}

void NewMatrixElement(int[,] matrixAB, int[,] matrixA, int[,] matrixB, int i, int j)
{
    for(int k = 0; k < matrixA.GetLength(1); k++)
    {
        matrixAB[i,j] = matrixAB[i,j] + matrixA[i,k]*matrixB[k,j];
    }
}

int[,] matrix_A = GenerateMatrix();
int[,] matrix_B = GenerateMatrix();
PrintMatrixMultiplicationView(matrix_A, matrix_B);

if(ValidateMatrix(matrix_A, matrix_B))
{
    int[,] matrix_AB = MatrixMultiplication(matrix_A, matrix_B);
    System.Console.WriteLine("Результирующая матрица будет:");
    PrintMatrix(matrix_AB);
}
