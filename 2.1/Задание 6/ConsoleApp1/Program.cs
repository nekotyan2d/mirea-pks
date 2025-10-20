Console.Write("Введите количество бактерий: ");
int n = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество антибиотика: ");
int x = Convert.ToInt32(Console.ReadLine());

int antibioticEffect = 10;
int hour = 1;
while(n > 0 && antibioticEffect > 0)
{
    n *= 2;
    n -= antibioticEffect * x;
    if (n < 0) n = 0;
    antibioticEffect--;
    Console.WriteLine($"После {hour} часа бактерий осталось {n}");
    hour++;
}