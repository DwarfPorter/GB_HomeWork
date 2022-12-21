//Задача 2: Задайте значения M и N. Напишите программу, 
//которая найдёт сумму натуральных элементов в промежутке от M до N с помощью рекурсии.
//
//M = 1; N = 15 -> 120
//M = 4; N = 8. -> 30

int Prompt(string message)
{
    Console.Write($"{message} > ");
    return Convert.ToInt32(Console.ReadLine());
}

int summ = 0;

void PlusNatural(int M, int N)
{
    summ = summ + M;
    if(M < N) PlusNatural(M+1, N);
}

PlusNatural(Prompt("Введите M"), Prompt("Введите N"));
Console.WriteLine(summ);
