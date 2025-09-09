Console.Write("N: ");
int n = Convert.ToInt32(Console.ReadLine());

while (n > 150000)
{
    Console.Write("Банкомат не может выдать более 150000 рублей за одну операцию, попробуйте другую сумму. N: ");
    n = Convert.ToInt32(Console.ReadLine());
}

int[] vals = [5000, 2000, 1000, 500, 200, 100];

foreach (var val in vals)
{
    int c = n / val;
    if (c > 0)
    {
        n %= val;
        Console.WriteLine($"{val}: {c}");
    }
}