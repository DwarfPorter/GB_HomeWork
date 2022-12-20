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

int[,] FillArraySpirally(int row, int col)
{
    int[,] massive = new int[row, col];
    int direction = 0;
    int x = 0;
    int y = 0;
    int filled_columns = 0;
    int filled_rows = 0;
    int steps_iside_iteration = 0;
    int var = 0;

    while(var < massive.GetLength(0)*massive.GetLength(1))
    { 
        switch (direction)
        {
            case 0: // идём направо
            {
                while(steps_iside_iteration < massive.GetLength(1) - filled_columns)
                {
                    var++;
                    massive[y, steps_iside_iteration + x] = var;
                    steps_iside_iteration++;
                }
                x = x + steps_iside_iteration - 1;
                steps_iside_iteration = 0;
                filled_rows++; //для каждого последующего шага "вычеркиваем" заполненную строку
                y++; //заранее делаем шаг вниз
            } 
            break;

            case 1: // идём вниз
            {
                while(steps_iside_iteration < massive.GetLength(0) - filled_rows)
                {
                    var++;
                    massive[steps_iside_iteration + y, x] = var;
                    steps_iside_iteration++;
                }
                y = y + steps_iside_iteration - 1;
                steps_iside_iteration = 0;
                filled_columns++; //для каждого последующего шага "вычеркиваем" заполненный столбец
                x--; //заранее делаем шаг влево
            } 
            break;

            case 2: //идём влево
            {
                while(steps_iside_iteration < massive.GetLength(1) - filled_columns)
                {
                    var++;
                    massive[y, x - steps_iside_iteration] = var;
                    steps_iside_iteration++;
                }
                x = x - steps_iside_iteration + 1;
                steps_iside_iteration = 0;
                filled_rows++;
                y--; //заранее делаем шаг вверх
            }
            break;

            case 3: //идём вверх
            {
                while(steps_iside_iteration < massive.GetLength(0) - filled_rows)
                {
                    var++;
                    massive[y - steps_iside_iteration, x] = var;
                    steps_iside_iteration++;
                }
                y = y - steps_iside_iteration + 1;
                steps_iside_iteration = 0;
                filled_columns++;
                x++; //заранее делаем шаг вправо
            } 
            break;
        }
        direction++;
        if(direction == 4) direction = 0; // сбрасываем счётчик направления, для корректной работы цикла
    }
    return massive;
}

int[,] array = FillArraySpirally(4, 4);
PrintMatrixAccurately(array);
