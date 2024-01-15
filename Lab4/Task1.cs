using System;

class MyMatrix
{
    private int[,] matrix;
    private int rows;
    private int columns;
    private static Random random = new Random();
    public int Rows
    {
        get { return rows; }
    }

    public int Columns
    {
        get { return columns; }
    }

    public MyMatrix(int rows, int columns, int minValue, int maxValue)
    {
        this.rows = rows;
        this.columns = columns;
        matrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }
    }

    public int this[int row, int column]
    {
        get { return matrix[row, column]; }
        set { matrix[row, column] = value; }
    }

    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    {
        if (a.rows != b.rows || a.columns != b.columns)
        {
            throw new ArgumentException("Матрицы разного размера нельзя сложить.");
        }

        MyMatrix result = new MyMatrix(a.rows, a.columns, 0, 0);

        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.columns; j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator -(MyMatrix a, MyMatrix b)
    {
        if (a.rows != b.rows || a.columns != b.columns)
        {
            throw new ArgumentException("Матрицы разного размера нельзя вычитать.");
        }

        MyMatrix result = new MyMatrix(a.rows, a.columns, 0, 0);

        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.columns; j++)
            {
                result[i, j] = a[i, j] - b[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    {
        if (a.columns != b.rows)
        {
            throw new ArgumentException("Число столбцов первой матрицы должно быть равно числу строк второй матрицы.");
        }

        MyMatrix result = new MyMatrix(a.rows, b.columns, 0, 0);

        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < b.columns; j++)
            {
                for (int k = 0; k < a.columns; k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        return result;
    }

    public static MyMatrix operator *(MyMatrix matrix, int scalar)
    {
        MyMatrix result = new MyMatrix(matrix.rows, matrix.columns, 0, 0);

        for (int i = 0; i < matrix.rows; i++)
        {
            for (int j = 0; j < matrix.columns; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }

    public static MyMatrix operator /(MyMatrix matrix, int divisor)
    {
        if (divisor == 0)
        {
            throw new DivideByZeroException("Деление на ноль невозможно.");
        }

        MyMatrix result = new MyMatrix(matrix.rows, matrix.columns, 0, 0);

        for (int i = 0; i < matrix.rows; i++)
        {
            for (int j = 0; j < matrix.columns; j++)
            {
                result[i, j] = matrix[i, j] / divisor;
            }
        }

        return result;
    }
}

class Task1
{
    static void Main()
    {
        Console.Write("Введите количество строк матрицы: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов матрицы: ");
        int columns = int.Parse(Console.ReadLine());

        Console.Write("Введите минимальное значение для заполнения матрицы: ");
        int minValue = int.Parse(Console.ReadLine());

        Console.Write("Введите максимальное значение для заполнения матрицы: ");
        int maxValue = int.Parse(Console.ReadLine());

        MyMatrix matrix1 = new MyMatrix(rows, columns, minValue, maxValue);
        MyMatrix matrix2 = new MyMatrix(rows, columns, minValue, maxValue);

        Console.WriteLine("Матрица 1:");
        PrintMatrix(matrix1);

        Console.WriteLine("Матрица 2:");
        PrintMatrix(matrix2);

        MyMatrix sumMatrix = matrix1 + matrix2;
        MyMatrix diffMatrix = matrix1 - matrix2;
        MyMatrix productMatrix = matrix1 * matrix2;

        Console.WriteLine("Сумма матриц:");
        PrintMatrix(sumMatrix);

        Console.WriteLine("Разность матриц:");
        PrintMatrix(diffMatrix);

        Console.WriteLine("Произведение матриц:");
        PrintMatrix(productMatrix);

        Console.Write("Введите число для умножения матрицы: ");
        int scalar = int.Parse(Console.ReadLine());

        MyMatrix scaledMatrix = matrix1 * scalar;
        Console.WriteLine($"Умножение матрицы на число {scalar}:");
        PrintMatrix(scaledMatrix);

        Console.Write("Введите число для деления матрицы: ");
        int divisor = int.Parse(Console.ReadLine());

        MyMatrix dividedMatrix = matrix1 / divisor;
        Console.WriteLine($"Деление матрицы на число {divisor}:");
        PrintMatrix(dividedMatrix);
    }

    static void PrintMatrix(MyMatrix matrix)
    {
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
