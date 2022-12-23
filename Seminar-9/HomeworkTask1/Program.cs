//Задача 1: Задайте значения M и N. Напишите программу, которая выведет все чётные натуральные числа в промежутке от M до N с помощью рекурсии.
//
//M = 1; N = 5 -> "2, 4"
//M = 4; N = 8 -> "4, 6, 8"

int Prompt(string message)
{
    Console.Write($"{message} > ");
    return Convert.ToInt32(Console.ReadLine());
}

void EvenNatural(int M, int N)
{
    if(M % 2 == 0) Console.Write($"{M}, ");
    if(M < N) EvenNatural(M+1, N);
}

EvenNatural(Prompt("Введите M"), Prompt("Введите N"));
Console.WriteLine();
