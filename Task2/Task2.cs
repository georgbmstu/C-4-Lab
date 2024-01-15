using System;

class Car
{
    private string name;
    private int productionYear;
    private int maxSpeed;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int ProductionYear
    {
        get { return productionYear; }
        set { productionYear = value; }
    }

    public int MaxSpeed
    {
        get { return maxSpeed; }
        set { maxSpeed = value; }
    }

    public Car(string name, int productionYear, int maxSpeed)
    {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
    }
}

class CarComparer : IComparer<Car>
{
    private string sortBy;

    public CarComparer(string sortBy)
    {
        this.sortBy = sortBy;
    }

    public int Compare(Car x, Car y)
    {
        switch (sortBy)
        {
            case "Name":
                return x.Name.CompareTo(y.Name);
            case "Year":
                return x.ProductionYear.CompareTo(y.ProductionYear);
            case "Speed":
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            default:
                return 0;
        }
    }
}

class Task2
{
    static void Main()
    {
        Car[] cars = new Car[]
        {
            new Car("Lada Kalina", 2015, 150),
            new Car("Lada Sport", 2023, 2000),
            new Car("Kia Sorento", 1977, 500),
            new Car("YAZ", 1980, 8934)
        };

        Console.WriteLine("\nCars:");
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Name}, {car.ProductionYear}, {car.MaxSpeed}");
        }

        int i = 0; while (i != 1)
        {
            Console.WriteLine("\nSort by: "); string type = Console.ReadLine();
            switch (type)
            {
                case "Name":
                    Array.Sort(cars, new CarComparer("Name"));
                    i++;
                    break;
                case "Year":
                    Array.Sort(cars, new CarComparer("Year"));
                    i++;
                    break;
                case "Speed":
                    Array.Sort(cars, new CarComparer("Speed"));
                    i++;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        Console.WriteLine("\nSorted cars:");
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Name}, {car.ProductionYear}, {car.MaxSpeed}");
        }
    }
}