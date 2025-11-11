Console.Write("Введите число: ");
int n = Convert.ToInt32(Console.ReadLine());

Console.WriteLine(Reverse(n, 0));

int Reverse(int initial, int result)
{
    if(initial > 0)
    {
        result = (result * 10) + (initial % 10);
        return Reverse(initial / 10, result);
    }
    else
    {
        return result;
    }
}

