double[,] A = null;
double[,] B = null;

while (true)
{
    Console.WriteLine("1. Создание двух матриц размерности n*m");
    Console.WriteLine("2. Заполнение матриц значениями с клавиатуры");
    Console.WriteLine("3. Заполнение матриц рандомными числами в диапазоне [a; b] ");
    Console.WriteLine("4. Сложение матриц");
    Console.WriteLine("5. Умножение матриц");
    Console.WriteLine("6. Нахождение детерминанта (определителя) матрицы");
    Console.WriteLine("7. Нахождение обратной матрицы");
    Console.WriteLine("8. Транспонирование матриц");
    Console.WriteLine("9. Нахождение корней системы уравнений, заданных матрицей");
    Console.Write("Выберите действие:");

    int choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            CreateMatrices();
            break;
        case 2:
            FillMatricesFromKeyboard();
            break;
        case 3:
            FillMatricesWithRandomNumbers();
            break;
        case 4:
            SumMatrices();
            break;
        case 5:
            MultiplyMatrices();
            break;
        case 6:
            CalculateDeterminant();
            break;
        case 7:
            FindInverseMatrix();
            break;
        case 8:
            TransposeMatrices();
            break;
        case 9:
            SolveEquationSystem();
            break;
        default:
            Console.WriteLine("Некорректный выбор. Пожалуйста, выберите действие от 1 до 9.");
            break;
    }
}

void PrintMatrix(double[,] matrix)
{
    int n = matrix.GetLength(0);
    int m = matrix.GetLength(1);

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

void CreateMatrices()
{
    Console.Write("Введите количество строк n: ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество столбцов m: ");
    int m = Convert.ToInt32(Console.ReadLine());

    A = new double[n, m];
    B = new double[n, m];

    Console.WriteLine($"Созданы две матрицы размерности {n}x{m}.");
}

void FillMatricesFromKeyboard()
{
    if (A == null || B == null)
    {
        Console.WriteLine("Сначала создайте матрицы.");
        return;
    }

    Console.WriteLine("Заполнение матрицы A:");
    FillMatrixFromKeyboard(A);
    Console.WriteLine("Заполнение матрицы B:");
    FillMatrixFromKeyboard(B);
    Console.WriteLine("Матрица A:");
    PrintMatrix(A);
    Console.WriteLine("Матрица B:");
    PrintMatrix(B);
}

void FillMatrixFromKeyboard(double[,] matrix)
{
    int n = matrix.GetLength(0);
    int m = matrix.GetLength(1);

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            Console.Write($"Введите элемент [{i},{j}]: ");
            matrix[i, j] = Convert.ToDouble(Console.ReadLine());
        }
    }
}

void FillMatricesWithRandomNumbers()
{
    if (A == null || B == null)
    {
        Console.WriteLine("Сначала создайте матрицы.");
        return;
    }

    Console.Write("Введите нижнюю границу диапазона a: ");
    double a = Convert.ToDouble(Console.ReadLine());
    Console.Write("Введите верхнюю границу диапазона b: ");
    double b = Convert.ToDouble(Console.ReadLine());

    Random rand = new Random();

    FillMatrixWithRandomNumbers(A, a, b, rand);
    FillMatrixWithRandomNumbers(B, a, b, rand);

    Console.WriteLine("Матрицы заполнены случайными числами.");

    Console.WriteLine("Матрица A:");
    PrintMatrix(A);
    Console.WriteLine("Матрица B:");
    PrintMatrix(B);
}

void FillMatrixWithRandomNumbers(double[,] matrix, double a, double b, Random rand)
{
    int n = matrix.GetLength(0);
    int m = matrix.GetLength(1);

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            matrix[i, j] = a + (b - a) * rand.NextDouble();
        }
    }
}

void SumMatrices()
{
    if (A == null || B == null)
    {
        Console.WriteLine("Сначала создайте и заполните матрицы.");
        return;
    }

    int nA = A.GetLength(0);
    int mA = A.GetLength(1);

    int nB = B.GetLength(0);
    int mB = B.GetLength(1);

    if (nA != nB || mA != mB)
    {
        Console.WriteLine("Матрицы должны быть одинакового размера для сложения.");
        return;
    }

    double[,] C = new double[nA, mA];
    for (int i = 0; i < nA; i++)
    {
        for (int j = 0; j < mA; j++)
        {
            C[i, j] = A[i, j] + B[i, j];
        }
    }

    Console.WriteLine("Результат сложения матриц A и B:");
    PrintMatrix(C);
}

void MultiplyMatrices()
{
    if (A == null || B == null)
    {
        Console.WriteLine("Сначала создайте и заполните матрицы.");
        return;
    }

    int nA = A.GetLength(0);
    int mA = A.GetLength(1);

    int nB = B.GetLength(0);
    int mB = B.GetLength(1);

    if (mA != nB)
    {
        Console.WriteLine("Количество столбцов матрицы A должно быть равно количеству строк матрицы B для умножения.");
        return;
    }

    double[,] C = new double[nA, mB];
    for (int i = 0; i < nA; i++)
    {
        for (int j = 0; j < mB; j++)
        {
            C[i, j] = 0;
            for (int k = 0; k < mA; k++)
            {
                C[i, j] += A[i, k] * B[k, j];
            }
        }
    }

    Console.WriteLine("Результат умножения матриц A и B:");
    PrintMatrix(C);
}

void CalculateDeterminant()
{
    if (A == null)
    {
        Console.WriteLine("Сначала создайте и заполните матрицу A.");
        return;
    }

    int n = A.GetLength(0);
    int m = A.GetLength(1);

    if (n != m)
    {
        Console.WriteLine("Матрица должна быть квадратной для вычисления детерминанта.");
        return;
    }

    double det = Determinant(A);
    Console.WriteLine($"Детерминант матрицы A: {det}");
}

double Determinant(double[,] matrix)
{
    int n = matrix.GetLength(0);

    double[,] C = new double[n, n];
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            C[i, j] = matrix[i, j];

    double det = 1.0;
    int sign = 1;
    const double eps = 1e-12;

    for (int i = 0; i < n; i++)
    {
        // частичный выбор главного элемента: найти максимальный по модулю элемент в столбце i на или ниже строки i
        int pivot = i;
        double maxAbs = Math.Abs(C[i, i]);
        for (int r = i + 1; r < n; r++)
        {
            double absVal = Math.Abs(C[r, i]);
            if (absVal > maxAbs)
            {
                maxAbs = absVal;
                pivot = r;
            }
        }

        // если главный элемент (численно) равен нулю, детерминант равен нулю
        if (maxAbs < eps)
            return 0.0;

        // меняем строки местами при необходимости
        if (pivot != i)
        {
            for (int c = i; c < n; c++)
            {
                double tmp = C[i, c];
                C[i, c] = C[pivot, c];
                C[pivot, c] = tmp;
            }
            sign = -sign;
        }

        // используем текущий главный элемент для исключения элементов ниже
        double pivotVal = C[i, i];
        det *= pivotVal;

        for (int r = i + 1; r < n; r++)
        {
            double factor = C[r, i] / pivotVal;
            for (int c = i; c < n; c++)
            {
                C[r, c] -= factor * C[i, c];
            }
        }
    }

    return det * sign;
}

void FindInverseMatrix()
{
    if (A == null)
    {
        Console.WriteLine("Сначала создайте и заполните матрицу A.");
        return;
    }

    int n = A.GetLength(0);
    int m = A.GetLength(1);

    if (n != m)
    {
        Console.WriteLine("Матрица должна быть квадратной для нахождения обратной матрицы.");
        return;
    }

    double det = Determinant(A);
    if (Math.Abs(det) < 1e-12)
    {
        Console.WriteLine("Матрица вырождена, обратная матрица не существует.");
        return;
    }

    double[,] inverse = InverseMatrix(A);
    Console.WriteLine("Обратная матрица A:");
    PrintMatrix(inverse);
}

double[,] InverseMatrix(double[,] matrix)
{
    int n = matrix.GetLength(0);
    double[,] augmented = new double[n, 2 * n];

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            augmented[i, j] = matrix[i, j];
        }
        augmented[i, i + n] = 1.0;
    }

    for (int i = 0; i < n; i++)
    {
        // частичный выбор главного элемента
        int pivot = i;
        double maxAbs = Math.Abs(augmented[i, i]);
        for (int r = i + 1; r < n; r++)
        {
            double absVal = Math.Abs(augmented[r, i]);
            if (absVal > maxAbs)
            {
                maxAbs = absVal;
                pivot = r;
            }
        }

        // меняем строки местами при необходимости
        if (pivot != i)
        {
            for (int c = 0; c < 2 * n; c++)
            {
                double tmp = augmented[i, c];
                augmented[i, c] = augmented[pivot, c];
                augmented[pivot, c] = tmp;
            }
        }

        // нормализуем главный элемент
        double pivotVal = augmented[i, i];
        for (int c = 0; c < 2 * n; c++)
        {
            augmented[i, c] /= pivotVal;
        }

        // исключаем элементы в других строках
        for (int r = 0; r < n; r++)
        {
            if (r != i)
            {
                double factor = augmented[r, i];
                for (int c = 0; c < 2 * n; c++)
                {
                    augmented[r, c] -= factor * augmented[i, c];
                }
            }
        }
    }

    double[,] inverse = new double[n, n];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            inverse[i, j] = augmented[i, j + n];
        }
    }

    return inverse;
}