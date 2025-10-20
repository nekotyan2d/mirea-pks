Console.WriteLine("Выберите режим:");
Console.WriteLine("1 - Вычислить f(x) с помощью ряда Маклорена с заданной точностью e < 0,01");
Console.WriteLine("2 - Вычислить n-й член ряда");

int choice = Convert.ToInt32(Console.ReadLine());

Console.Write("Введите x прин (-1, 1): ");
double x = Convert.ToDouble(Console.ReadLine());

if (x > 1 || x < -1)
{
    Console.WriteLine("x должно принадлежать (-1, 1)!");
    return;
}

if (choice == 1)
{
    Console.Write("Введите e (e < 0,01): ");
    double e = Convert.ToDouble(Console.ReadLine());

    if (e >= 0.01)
    {
        Console.WriteLine("e должно быть меньше 0,01!");
        return;
    }

    double first = x;
    double sum = first;
    int n = 0;

    while (Math.Abs(first) >= e)
    {
        n++;
        first = Math.Pow(x, 2 * n + 1) / (2 * n + 1);
        sum += first;
    }

    Console.WriteLine($"Результат: f(x) = {sum}");
    Console.WriteLine($"Количество членов ряда: {n + 1}");
}
else if (choice == 2)
{
    Console.Write("Введите n: ");
    int n = Convert.ToInt32(Console.ReadLine());

    double first = Math.Pow(x, 2 * n + 1) / (2 * n + 1);
    Console.WriteLine($"n-й член ряда: a_{n} = {first}");
}
else
{
    Console.WriteLine("Неверный выбор!");
}
