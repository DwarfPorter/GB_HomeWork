//Задача 4. (*) Напишите программу, которая заполнит спирально массив 4 на 4.
//Например, на выходе получается вот такой массив:
//01 02 03 04
//12 13 14 05
//11 16 15 06
//10 09 08 07


void PrintMatrixAccurately(int[,] matrix) //не уверен, возможно нужно было сделать решением массив строк
{
    for(int i = 0; i < matrix.GetLength(0); i++)
    {
        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            if(matrix[i,j] < 10) Console.Write($"0{matrix[i,j]} ");
            else Console.Write($"{matrix[i,j]} ");
        }
        Console.WriteLine();
    }
}

void Step(int[,] massive, int direction, int ready_steps, int var, int x, int y)
{
    int steps = 0;
    int reverse = 1;
    if(direction%4 > 1) reverse = -1;
   
    int even = ( direction + 1 ) % 2;
    int odd = direction % 2;
   
    while(steps < massive.GetLength(even) - ready_steps)
    {
        var++;
        massive[y + reverse * odd * steps, x + reverse * even * steps] = var;
        steps++;        
    }
    x = x + ( ( steps - 1 ) * even - odd ) * reverse;
    y = y + ( ( steps - 1 ) * odd + even ) * reverse;
    ready_steps = ready_steps + even;
    if (var < massive.GetLength(0)*massive.GetLength(1)) Step(massive, direction+1, ready_steps, var, x, y);
}

int[,] array = new int[9, 9];
Step(array, 0, 0, 0, 0, 0);
PrintMatrixAccurately(array);
