System Ekwipunku RPG

Opis tematu:
Aplikacja to uproszczony model systemu ekwipunku postaci z gry RPG. System pozwala na stworzenie gracza, który posiada własny ekwipunek, do którego może dodawać różne typy przedmiotów. Każdy przedmiot ma swój unikalny identyfikator ID.

Lista klas:

Item (klasa abstrakcyjna): Reprezentuje ogólny wzorzec przedmiotu w grze. 
  Odpowiedzialność: Przechowywanie podstawowych cech (nazwa, waga, unikalne ID) wspólnych dla każdego łupu.
  Właściwości: Id, Name, Weight.
  Metody: DisplayInfo() (abstrakcyjna).

Weapon: Dziedziczy po Item, implementuje interfejs IUsable.
  Odpowiedzialność: Modelowanie broni zadającej obrażenia.
  Właściwości: Damage.
  Metody: Use(), DisplayInfo() (nadpisana).

Consumable: Dziedziczy po Item, implementuje interfejs IUsable.
  Odpowiedzialność: Modelowanie przedmiotów zużywalnych (np. mikstur leczących) i kontrolowanie ich pozostałej ilości.
  Właściwości: HealAmount, _usesLeft (prywatne pole).
  Metody: Use(), DisplayInfo() (nadpisana).

Inventory: 
   Odpowiedzialność: Zarządzanie kolekcją posiadanych przedmiotów.
   Właściwości: _items (lista).
   Metody: AddItem(), DisplayAllItems(), UseItem().

Player:
  Odpowiedzialność: Reprezentacja konkretnego gracza w systemie.
  Właściwości: Nickname, PlayerInventory.

IUsable (interfejs): Określa, że dany obiekt posiada metodę Use().

Opis relacji między klasami:
1. Dziedziczenie (Relacja "jest rodzajem"): Klasy Weapon i Consumable dziedziczą po bazowej klasie Item (Broń jest rodzajem przedmiotu).
2. Kolekcja: Klasa Inventory posiada relację z klasą Item poprzez prywatną listę (kolekcję) List<Item> _items.
3. Kompozycja/Agregacja: Klasa Player posiada właściwość PlayerInventory typu Inventory (Gracz ma swój ekwipunek, tworzony razem z instancją gracza).
4. Parametr metody: W klasie Inventory, metoda UseItem(Item item) przyjmuje obiekt klasy Item z zewnątrz w celu wykonania na nim operacji.
5. Realizacja interfejsu: Klasy Weapon i Consumable realizują kontrakt interfejsu IUsable.

Wskazanie czterech zasad OOP w projekcie:

Enkapsulacja: Pola w klasach posiadają modyfikator private set (np. Weight, Damage), dzięki czemu ich stan można nadać tylko przez konstruktor, chroniąc je przed niekontrolowaną zmianą z zewnątrz. Dodatkowo w klasie Consumable zmienna _usesLeft jest prywatna i jej zmiana (pomniejszenie o 1) odbywa się wyłącznie kontrolowanie wewnątrz metody Use().

Dziedziczenie: Klasy Weapon oraz Consumable bazują na klasie ogólnej Item, przejmując z niej mechanizm generowania Guid Id, nazwy oraz wagi, rozszerzając ją jedynie o własne cechy (obrażenia lub leczenie).

Polimorfizm: Wywoływanie metody DisplayInfo() w pętli foreach w klasie Inventory. Pętla operuje na ogólnym typie Item, ale dla każdego obiektu wywoływana jest inna, specyficzna implementacja tej metody (inna dla miecza, inna dla mikstury). 

Abstrakcja: Stworzenie klasy abstrakcyjnej Item, z której nie da się utworzyć bezpośrednio obiektu (służy tylko jako koncept-baza) oraz interfejsu IUsable, który narzuca z góry kontrakt (metodę Use()), ukrywając jednocześnie szczegóły jej wewnętrznej implementacji.

---
Zgodnie z wytycznymi z instrukcji kursu, przy projektowaniu szkieletu klas, planowaniu relacji i wyłapywaniu błędów składniowych korzystano ze wsparcia narzędzia AI, zachowując jednak pełne zrozumienie napisanego kodu.