Console.WriteLine("Загадайте число (0-63)");
int min = 0;
int max = 63;

for (int i = 0; i < 7; i++)
{
    int mid = (min + max) / 2;
    Console.Write($"Ваше число больше {mid}? (да-1/нет-0): ");
    int answer = Convert.ToInt32(Console.ReadLine());

    if (answer == 1)
    {
        min = mid + 1;
    }
    else if (answer == 0)
    {
        max = mid;
    }
    else
    {
        Console.WriteLine("Введите 1 или 0");
        i--;
        continue;
    }
}

Console.WriteLine($"Загаданное число: {min}");