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

int PlusNatural(int M, int N)
{
    if(M < N) return M + PlusNatural(M + 1, N);
    else return N;
}

int summ = PlusNatural(Prompt("Введите M"), Prompt("Введите N"));
Console.WriteLine(summ);
