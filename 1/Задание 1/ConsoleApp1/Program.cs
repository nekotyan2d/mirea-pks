double x = 0;
double y = 0;
double res = 0;
double M = 0;

while (true)
{
    Console.Write("operation (+ - * / % 1/x x^2 sqrt M+ M-): ");
    string? operation = Console.ReadLine();

    switch (operation)
    {
        case "+":
            inputX();
            inputY();
            res = x + y;
            Console.WriteLine("{0} + {1} = {2}", [x, y, res]);
            break;
        case "-":
            inputX();
            inputY();
            res = x - y;
            Console.WriteLine("{0} - {1} = {2}", [x, y, res]);
            break;
        case "*":
            inputX();
            inputY();
            res = x * y;
            Console.WriteLine("{0} * {1} = {2}", [x, y, res]);
            break;
        case "/":
            inputX();
            inputY();
            res = x / y;
            Console.WriteLine("{0} / {1} = {2}", [x, y, res]);
            break;
        case "1/x":
            inputX();
            res = 1 / x;
            Console.WriteLine("1/{0} = {1}", [x, res]);
            break;
        case "x^2":
            inputX();
            res = Math.Pow(x, 2);
            Console.WriteLine("{0}^2 = {1}", [x, res]);
            break;
        case "%":
            inputX();
            inputY();
            res = x * (y / 100);
            Console.WriteLine("{0} % {1} = {2}", [x, y, res]);
            break;
        case "sqrt":
            inputX();
            res = Math.Sqrt(x);
            Console.WriteLine("sqrt({0}) = {1}", [x, res]);
            break;
        case "M+":
            M = res;
            break;
        case "M-":
            M = 0;
            break;

    }
}

void inputX()
{
    Console.Write("x = ");
    string? s = Console.ReadLine();
    if (s.Equals("MR"))
    {
        x = M;
    }
    else
    {
        x = Convert.ToInt32(s);
    }
}

void inputY()
{
    Console.Write("y = ");
    string? s = Console.ReadLine();
    if (s.Equals("MR"))
    {
        y = M;
    }
    else
    {
        y = Convert.ToInt32(s);
    }
}