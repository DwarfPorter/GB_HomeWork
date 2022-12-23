//Задача 3: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
//m = 2, n = 3 -> A(m,n) = 9
//m = 3, n = 2 -> A(m,n) = 29

int Prompt(string message)
{
    Console.Write($"{message} > ");
    return Convert.ToInt32(Console.ReadLine());
}

int Akkerman(int m, int n)
{
    if (m == 0) return (n + m + 1);
    else if (n == 0) return Akkerman((m - 1), 1);
    else return Akkerman((m-1), Akkerman(m, (n - 1)));
}



int m = Prompt("Введите m");
int n = Prompt("Введите n");

int akk = Akkerman(m, n);
Console.WriteLine($"A({m}, {n}) = {akk}");
