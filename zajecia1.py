import sys

def run_kalkulator():
    try:
        a = float(input("Podaj pierwszą liczbę: "))
        b = float(input("Podaj drugą liczbę: "))
        op = input("Wybierz operację (+, -, *, /): ").strip()

        if op == "+":
            print(f"Wynik: {a + b}")
        elif op == "-":
            print(f"Wynik: {a - b}")
        elif op == "*":
            print(f"Wynik: {a * b}")
        elif op == "/":
            if b == 0:
                print("Błąd: Nie można dzielić przez zero.")
            else:
                print(f"Wynik: {a / b}")
        else:
            print("Nieznana operacja.")
    except ValueError:
        print("Błąd: Wprowadzono niepoprawny format liczby.")

def run_konwerter_temperatur():
    try:
        direction = input("Wybierz kierunek (C – Celsjusz na Fahr, F – Fahr na Celsjusz): ").strip().upper()
        temp = float(input("Podaj wartość temperatury: "))

        if direction == "C":
            fahrenheit = temp * 1.8 + 32
            print(f"{temp}°C = {fahrenheit}°F")
        elif direction == "F":
            celsius = (temp - 32) / 1.8
            print(f"{temp}°F = {celsius}°C")
        else:
            print("Nieprawidłowy kierunek konwersji.")
    except ValueError:
        print("Błąd: Wprowadzono niepoprawny format liczby.")

def run_srednia_ocena():
    try:
        count = int(input("Podaj liczbę ocen: "))
        if count <= 0:
            print("Liczba ocen musi być większa od 0.")
            return
    except ValueError:
        print("Błąd: Liczba ocen musi być liczbą całkowitą.")
        return

    total_sum = 0
    for i in range(count):
        while True:
            try:
                grade = float(input(f"Podaj ocenę {i + 1} (1-6): "))
                
                if 1 <= grade <= 6:
                    total_sum += grade
                    break
                else:
                    print("Błąd: Ocena musi mieścić się w przedziale od 1 do 6.")
                    
            except ValueError:
                print("Błąd: Wprowadzono niepoprawny format liczby. Spróbuj ponownie.")

    average = total_sum / count
    print(f"Średnia: {average:.2f}")

    if average >= 3.0:
        print("Uczeń zdał.")
    else:
        print("Uczeń nie zdał.")

def main():
    while True:
        print("\nMENU GŁÓWNE")
        print("1. Zadanie 1: Prosty kalkulator dwóch liczb")
        print("2. Zadanie 2: Konwerter temperatur (Celsjusz ↔ Fahrenheit)")
        print("3. Zadanie 3: Średnia ocen ucznia")
        print("0. Wyjście z programu")
        choice = input("Wybierz podzadanie (0-3): ").strip()

        if choice == "1":
            run_kalkulator()
        elif choice == "2":
            run_konwerter_temperatur()
        elif choice == "3":
            run_srednia_ocena()
        elif choice == "0":
            print("Zamykanie programu.")
            sys.exit(0)
        else:
            print("Nieprawidłowy wybór. Spróbuj ponownie.")

if __name__ == "__main__":
    main()