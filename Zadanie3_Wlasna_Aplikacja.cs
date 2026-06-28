using System;
using System.Collections.Generic;

namespace RpgInventorySystem
{
    public interface IUsable
    {
        void Use();
    }

    public abstract class Item
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Weight { get; private set; }

        protected Item(string name, int weight)
        {
            Id = Guid.NewGuid();
            Name = name;
            Weight = weight;
        }

        public abstract void DisplayInfo();
    }

    public class Weapon : Item, IUsable
    {
        public int Damage { get; private set; }

        public Weapon(string name, int weight, int damage) : base(name, weight)
        {
            Damage = damage;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"[Broń] {Name} (Waga: {Weight}, Obrażenia: {Damage}) | ID: {Id}");
        }
        public void Use()
        {
            Console.WriteLine($"Wykonujesz atak bronią: {Name}, zadając {Damage} obrażeń.");
        }
    }

    public class Consumable : Item, IUsable
    {
        public int HealAmount { get; private set; }
        private int _usesLeft;

        private const int MINIMUM_USES = 0;
        private const int USAGE_COST = 1;

        public Consumable(string name, int weight, int healAmount, int initialUses) : base(name, weight)
        {
            HealAmount = healAmount;
            _usesLeft = initialUses;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Przedmiot użytkowy] {Name} (Waga: {Weight}, Leczenie: {HealAmount}, Pozostałe użycia: {_usesLeft}) | ID: {Id}");
        }

        public void Use()
        {
            if (_usesLeft > MINIMUM_USES)
            {
                _usesLeft -= USAGE_COST;
                Console.WriteLine($"Wypijasz {Name}. Odzyskujesz {HealAmount} HP. Zostało użyć: {_usesLeft}");
            }
            else
            {
                Console.WriteLine($"Nie możesz użyć {Name}. Brak pozostałych użyć!");
            }
        }
    }

    public class Inventory
    {
        private readonly List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            Console.WriteLine($"Dodano '{item.Name}' do ekwipunku.");
        }

        public void DisplayAllItems()
        {
            Console.WriteLine("\n--- Zawartość Ekwipunku ---");
            foreach (var item in _items)
            {
                item.DisplayInfo();
            }
            Console.WriteLine("---------------------------\n");
        }

        public void UseItem(Item item)
        {
            if (item is IUsable usableItem)
            {
                usableItem.Use();
            }
            else
            {
                Console.WriteLine($"{item.Name} nie może zostać użyte w ten sposób.");
            }
        }
    }

    public class Player
    {
        public string Nickname { get; private set; }
        public Inventory PlayerInventory { get; private set; }

        public Player(string nickname)
        {
            Nickname = nickname;
            PlayerInventory = new Inventory();
        }
    }

    class Program
    {
        static void Main()
        {
            Player knight = new Player("Rycerz");

            Console.WriteLine($"=== System Ekwipunku RPG: Zalogowano jako {knight.Nickname} ===");

            Weapon greatsword = new Weapon("Miecz Dwuręczny", 12, 150);
            Consumable hpPotion = new Consumable("Mikstura Leczenia", 2, 250, 3);

            Console.WriteLine($"\n--- {knight.Nickname} zbiera przedmioty ---");
            knight.PlayerInventory.AddItem(greatsword);
            knight.PlayerInventory.AddItem(hpPotion);
            Console.WriteLine($"\n--- {knight.Nickname} przegląda plecak ---");
            knight.PlayerInventory.DisplayAllItems();
            Console.WriteLine($"\n--- {knight.Nickname} wykonuje akcje ---");
            knight.PlayerInventory.UseItem(greatsword);
            knight.PlayerInventory.UseItem(hpPotion);
            Console.WriteLine($"\n--- Stan plecaka po walce ---");
            knight.PlayerInventory.DisplayAllItems();

            Console.ReadLine();
        }
    }
}