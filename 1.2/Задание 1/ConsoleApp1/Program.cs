Console.WriteLine("Введите день, с которого будет начинаться месяц (1 Пн - 7 Вс): ");
int start = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Введите день, который нужно проверить: ");
int day = Convert.ToInt32(Console.ReadLine());

string[] daysOfWeek = ["Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс"];

int dayOfWeekIndex = (start - 1 + day - 1) % 7;
string dayOfWeek = daysOfWeek[dayOfWeekIndex];

Console.WriteLine($"День {day} месяца - это {dayOfWeek}");

bool isWeekend = dayOfWeek == "Сб" || dayOfWeek == "Вс";
bool isHoliday = (day >= 1 && day <= 5) || (day >= 8 && day <= 10);

if (isWeekend || isHoliday)
{
    Console.WriteLine("Это выходной день");
}
else
{
    Console.WriteLine("Это рабочий день");
}
