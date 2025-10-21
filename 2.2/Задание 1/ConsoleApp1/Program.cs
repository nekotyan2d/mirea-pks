double[,]? A = null;
double[,]? B = null;

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

    double[,]? inverse = InverseMatrix(A);
    if (inverse == null)
        return;
        
    Console.WriteLine("Обратная матрица A:");
    PrintMatrix(inverse);
}

double[,]? InverseMatrix(double[,] matrix)
{
    int n = matrix.GetLength(0);
    double[,] A = new double[n, n];
    double[,] I = new double[n, n];

    // копируем A и создаем единичную матрицу
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            A[i, j] = matrix[i, j];
            I[i, j] = (i == j) ? 1.0 : 0.0;
        }
    }

    // по гауссу
    for (int i = 0; i < n; i++)
    {
        // поиск ведущего элемента
        double pivot = A[i, i];
        if (Math.Abs(pivot) < 1e-12)
        {
            // ищем строку с ненулевым элементом
            int swapRow = i + 1;
            while (swapRow < n && Math.Abs(A[swapRow, i]) < 1e-12)
            {
                swapRow++;
            }


            if (swapRow == n)
            {
                Console.WriteLine("Матрица вырождена, обратная матрица не существует.");
                return null;
            }

            // меняем строки местами
            for (int k = 0; k < n; k++)
            {
                (A[i, k], A[swapRow, k]) = (A[swapRow, k], A[i, k]);
                (I[i, k], I[swapRow, k]) = (I[swapRow, k], I[i, k]);
            }

            pivot = A[i, i];
        }

        // нормализуем строку, чтобы главный элемент стал равен 1
        for (int k = 0; k < n; k++)
        {
            A[i, k] /= pivot;
            I[i, k] /= pivot;
        }

        // обнуляем все элементы в столбце i кроме диагонали
        for (int j = 0; j < n; j++)
        {
            if (j == i) continue;

            double factor = A[j, i];
            for (int k = 0; k < n; k++)
            {
                A[j, k] -= factor * A[i, k];
                I[j, k] -= factor * I[i, k];
            }
        }

    }

    return I;
}

void TransposeMatrices()
{
    if (A == null || B == null)
    {
        Console.WriteLine("Сначала создайте и заполните матрицы.");
        return;
    }

    Console.WriteLine("Транспонированная матрица A:");
    PrintMatrix(TransposeMatrix(A));
    Console.WriteLine("Транспонированная матрица B:");
    PrintMatrix(TransposeMatrix(B));
}

double[,] TransposeMatrix(double[,] matrix)
{
    int n = matrix.GetLength(0);
    int m = matrix.GetLength(1);

    double[,] T = new double[m, n];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            T[j, i] = matrix[i, j];
        }
    }

    return T;
}

void SolveEquationSystem()
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
        Console.WriteLine("Матрица должна быть квадратной для решения системы уравнений.");
        return;
    }

    Console.WriteLine("Введите свободные члены системы уравнений (вектор B):");
    double[,] B = new double[n, 1];
    for (int i = 0; i < n; i++)
    {
        Console.Write($"B[{i}]: ");
        B[i, 0] = Convert.ToDouble(Console.ReadLine());
    }

    double[]? X = SolveGauss(A, B);

    if (X == null)
    {
        Console.WriteLine("Система не имеет решения или имеет бесконечно много решений.");
        return;
    }

    Console.WriteLine("Решение системы уравнений (вектор X):");
    for (int i = 0; i < n; i++)
    {
        Console.WriteLine($"X[{i}] = {X[i]}");
    }
}

double[]? SolveGauss(double[,] A, double[,] B)
{
    int n = A.GetLength(0);
    double[,] C = new double[n, n + 1];

    // [A|B]
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            C[i, j] = A[i, j];
        }
        C[i, n] = B[i, 0];
    }

    for (int i = 0; i < n; i++)
    {
        // поиск ведущего элемента
        double pivot = A[i, i];
        if (Math.Abs(pivot) < 1e-12)
        {
            // ищем строку с ненулевым элементом
            int swapRow = i + 1;
            while (swapRow < n && Math.Abs(A[swapRow, i]) < 1e-12)
            {
                swapRow++;
            }


            if (swapRow == n)
            {
                Console.WriteLine("Матрица вырождена, обратная матрица не существует.");
                return null;
            }

            // меняем строки местами
            for (int k = 0; k < n; k++)
            {
                (A[i, k], A[swapRow, k]) = (A[swapRow, k], A[i, k]);
                (C[i, k], C[swapRow, k]) = (C[swapRow, k], C[i, k]);
            }

            pivot = A[i, i];
        }

        // нормализуем строку, чтобы главный элемент стал равен 1
        for (int k = 0; k < n; k++)
        {
            A[i, k] /= pivot;
            C[i, k] /= pivot;
        }

        // обнуляем все элементы в столбце i кроме диагонали
        for (int j = 0; j < n; j++)
        {
            if (j == i) continue;

            double factor = A[j, i];
            for (int k = 0; k < n; k++)
            {
                A[j, k] -= factor * A[i, k];
                C[j, k] -= factor * C[i, k];
            }
        }

    }

    double[] X = new double[n];
    for (int i = 0; i < n; i++)
    {
        X[i] = C[i, n];
    }

    return X;
}