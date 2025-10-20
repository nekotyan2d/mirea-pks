while (true)
{
    Console.Write("Введите номер билета: ");
    string number = Console.ReadLine();

    int sum1 = 0;
    int sum2 = 0;

    for (int i = 0; i < number.Length; i++)
    {
        if (i < number.Length / 2)
        {
            sum1 += Convert.ToInt32(number[i]);
        }
        else
        {
            sum2 += Convert.ToInt32(number[i]);
        }
    }

    Console.WriteLine(sum1 == sum2);
}