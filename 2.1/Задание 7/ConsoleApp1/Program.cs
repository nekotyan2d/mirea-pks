Console.Write("n: ");
int n = Convert.ToInt32(Console.ReadLine());
Console.Write("a: ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("b: ");
int b = Convert.ToInt32(Console.ReadLine());
Console.Write("w: ");
int w = Convert.ToInt32(Console.ReadLine());
Console.Write("h: ");
int h = Convert.ToInt32(Console.ReadLine());

int d = 0;
int left = 0;
int right = Math.Min(w, h);

while (left <= right)
{
    int mid = (left + right) / 2;

    int width = w / (a + 2 * mid);
    int height = h / (b + 2 * mid);

    if (width * height >= n)
    {
        d = mid;
        left = mid + 1;
    }
    else
    {
        right = mid - 1;
    }
}

Console.WriteLine($"Ответ d = {d}");