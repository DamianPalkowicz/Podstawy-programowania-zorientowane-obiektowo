using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        while (true)
        {
            Console.WriteLine("\nMENU GLOWNE");
            Console.WriteLine("1. Zadanie 1: Prosty kalkulator dwoch liczb");
            Console.WriteLine("2. Zadanie 2: Konwerter temperatur (Celsjusz <-> Fahrenheit)");
            Console.WriteLine("3. Zadanie 3: Srednia ocen ucznia");
            Console.WriteLine("0. Wyjscie z programu");
            Console.Write("Wybierz zadanie (0-3): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    RunKalkulator();
                    break;
                case "2":
                    RunTempKonwerter();
                    break;
                case "3":
                    RunSredniaOcen();
                    break;
                case "0":
                    Console.WriteLine("Zamykanie programu.");
                    return;
                default:
                    Console.WriteLine("Nieprawidlowy wybor. Sprobuj ponownie.");
                    break;
            }
        }
    }

    static void RunKalkulator()
    {
        Console.Write("Podaj pierwsza liczbe: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Podaj druga liczbe: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Wybierz operacje (+, -, *, /): ");
        string op = Console.ReadLine();

        if (op == "+")
        {
            Console.WriteLine($"Wynik: {a + b}");
        }
        else if (op == "-")
        {
            Console.WriteLine($"Wynik: {a - b}");
        }
        else if (op == "*")
        {
            Console.WriteLine($"Wynik: {a * b}");
        }
        else if (op == "/")
        {
            if (b == 0)
                Console.WriteLine("Blad: Nie można dzielic przez zero.");
            else
                Console.WriteLine($"Wynik: {a / b}");
        }
        else
        {
            Console.WriteLine("Nieznana operacja arytmetyczna.");
        }
    }

    static void RunTempKonwerter()
    {
        Console.Write("Wybierz kierunek (C - Celsjusz na Fahr, F - Fahr na Celsjusz): ");
		string direction = Console.ReadLine().Trim().ToUpper();

        Console.Write("Podaj wartosc temperatury: ");
        string inputTemp = Console.ReadLine();

		if (!double.TryParse(inputTemp, out double temp))
		{
			Console.WriteLine("Blad: Wprowadzono niepoprawny format liczby.");
			return;
		}
		if (direction == "C")
		{
			double fahrenheit = temp * 1.8 + 32;
			Console.WriteLine($"{temp} C = {fahrenheit} F");
		}
		else if (direction == "F")
		{
			double celsius = (temp - 32) / 1.8;
			Console.WriteLine($"{temp} F = {celsius} C");
		}
        else
        {
            Console.WriteLine("Nieprawidlowy kierunek konwersji.");
        }
    }

    static void RunSredniaOcen()
    {
        Console.Write("Podaj liczbe ocen: ");
        int count = int.Parse(Console.ReadLine());
        
        if (count <= 0)
        {
            Console.WriteLine("Liczba ocen musi byc wieksza od 0.");
            return;
        }

        double sum = 0;
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Podaj ocene {i + 1} (1-6): ");
            sum += double.Parse(Console.ReadLine());
        }

        double average = sum / count;
        Console.WriteLine($"Srednia: {average:F2}");

        if (average >= 3.0)
            Console.WriteLine("Uczen zdal.");
        else
            Console.WriteLine("Uczen nie zdal.");
    }
}