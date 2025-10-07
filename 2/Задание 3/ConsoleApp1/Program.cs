Console.Write("Введите числитель: ");
int M = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите знаменатель: ");
int N = Convert.ToInt32(Console.ReadLine());

if (N == 0)
{
    Console.WriteLine("Нельзя делить на ноль!!!");
    return;
}

bool isNegative = false;

bool isNegativeM = false;
bool isNegativeN = false;

if (M < 0)
{
    isNegativeM = true;
    M = Math.Abs(M);
}

if (N < 0)
{
    isNegativeN = true;
    N = Math.Abs(N);
}

if (isNegativeM ^ isNegativeN)
{
    isNegative = true;
}
else
{
    isNegative = false;
}

int commonDivider(int x, int y){

    while (x != 0 && y != 0)
    {
        if (x > y)
        {
            x %= y;
        }
        else
        {
            y %= x;
        }
    }
    return x | y;
}
int cd = commonDivider(M, N);

Console.WriteLine($"Результат: {(isNegative ? "-" : "")}{M / cd}/{N / cd}");
