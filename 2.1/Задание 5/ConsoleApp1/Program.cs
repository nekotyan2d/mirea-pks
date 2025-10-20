Console.Write("Молока в мл: ");
int milk = Convert.ToInt32(Console.ReadLine());
Console.Write("Воды в мл: ");
int water = Convert.ToInt32(Console.ReadLine());

int latte = 0;
int americano = 0;

int summ = 0;

while ((milk >= 270 && water >= 30) || (water >= 300))
{
    Console.Write("Выберите напиток (1 - американо, 2 - латте): ");
    int choice = Convert.ToInt32(Console.ReadLine());
    if (choice == 1)
    {
        if (water < 300)
        {
            Console.WriteLine("Не хватает воды");
            continue;
        }
        water -= 300;
        summ += 150;
        americano++;
        Console.WriteLine("Ваш напиток готов");
    }
    else if (choice == 2)
    {
        if (water < 30)
        {
            Console.WriteLine("Не хватает воды");
            continue;
        }
        if (milk < 270)
        {
            Console.WriteLine("Не хватает молока");
            continue;
        }
        water -= 30;
        milk -= 270;
        summ += 170;
        latte++;
        Console.WriteLine("Ваш напиток готов");
    }
    if ((milk < 270 && water < 30) || (water < 300))
    {
        Console.WriteLine("*Отчет*");
        Console.WriteLine("Ингридиентов осталось:");
        Console.WriteLine($"  Молоко: {milk} мл");
        Console.WriteLine($"  Вода: {water} мл");
        Console.WriteLine($"Кружек американо приготовлено: {americano}");
        Console.WriteLine($"Кружек латте приготовлено: {latte}");
        Console.WriteLine($"Итого: {summ} рублей");
    }
}