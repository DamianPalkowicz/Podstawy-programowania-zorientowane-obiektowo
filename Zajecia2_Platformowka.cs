using System;
using System.Collections.Generic;
using System.Linq;

public class Hero
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Hp { get; set; }
    public List<string> Inventory { get; set; }

    public Hero(string name, int x, int y, int hp)
    {
        Name = name;
        X = x;
        Y = y;
        Hp = hp;
        Inventory = new List<string>();
    }
    public void Move(int dx)
    {
        X += dx;
        Console.WriteLine($"[{Name}] Ruch w bok. Aktualna pozycja X: {X}");
    }
    public void Jump(int dy)
    {
        Y += dy;
        Console.WriteLine($"[{Name}] Skok. Aktualna pozycja Y: {Y}");
    }
}
public class Enemy
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Damage { get; set; }

    public Enemy(string name, int x, int y, int damage)
    {
        Name = name;
        X = x;
        Y = y;
        Damage = damage;
    }
}
public class Item
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Item(string name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }
}
public class Platform
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Length { get; set; }

    public Platform(int x, int y, int length)
    {
        X = x;
        Y = y;
        Length = length;
    }
}
public class Level
{
    public string Name { get; set; }
    public Hero Hero { get; set; }
    public List<Enemy> Enemies { get; set; }
    public List<Item> Items { get; set; }
    public List<Platform> Platforms { get; set; }

    public Level(string name)
    {
        Name = name;
        Enemies = new List<Enemy>();
        Items = new List<Item>();
        Platforms = new List<Platform>();
    }
    public void SetHero(Hero hero)
    {
        Hero = hero;
        Console.WriteLine($"--- Bohater {Hero.Name} wkracza na poziom: {Name} ---");
    }
    public void AddEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
    }
    public void AddItem(Item item)
    {
        Items.Add(item);
    }
    public void AddPlatform(Platform platform)
    {
        Platforms.Add(platform);
    }
    public void SimulateTurn()
    {
        foreach (var enemy in Enemies)
        {
            if (Hero.X == enemy.X && Hero.Y == enemy.Y)
            {
                Hero.Hp -= enemy.Damage;
                Console.WriteLine($"Wpadasz na wroga - {enemy.Name}!. Tracisz {enemy.Damage}hp.");
            }
        }
        foreach (var item in Items.ToList())
        {
            if (Hero.X == item.X && Hero.Y == item.Y)
            {
                Hero.Inventory.Add(item.Name);
                Items.Remove(item);
                Console.WriteLine($"Podnosisz przedmiot: {item.Name}");
            }
        }
        bool onPlatform = false;
        foreach (var plat in Platforms)
        {
            if (plat.Y == Hero.Y - 1 && plat.X <= Hero.X && Hero.X <= (plat.X + plat.Length))
            {
                onPlatform = true;
            }
        }
        if (onPlatform) Console.WriteLine("Bohater stoi na platformie.\n");
        else Console.WriteLine("Bohater nie stoi na platformie.\n");
    }
}

public class Program
{
    public static void Main()
    {
        Level gameLevel = new Level(name: "Mroczny Las");
        Hero player = new Hero(name: "Stefan", x: 0, y: 1, hp: 100);
        Enemy goblin = new Enemy(name: "Goblin", x: 2, y: 1, damage: 15);
        Item potion = new Item(name: "Mikstura Leczenia", x: 3, y: 1);
        Platform ground = new Platform(x: 0, y: 0, length: 5);

        gameLevel.SetHero(hero: player);
        gameLevel.AddEnemy(enemy: goblin);
        gameLevel.AddItem(item: potion);
        gameLevel.AddPlatform(platform: ground);

        player.Move(dx: 1);
        gameLevel.SimulateTurn();

        player.Move(dx: 1); // Goblin
        gameLevel.SimulateTurn();

        player.Move(dx: 1); // Potka HP
        gameLevel.SimulateTurn();
        
        player.Jump(dy: 1);
        gameLevel.SimulateTurn();

        Console.WriteLine("\n--- Podsumowanie ---");
        Console.WriteLine($"HP: {player.Hp}");
        Console.WriteLine($"Ekwipunek: [{string.Join(", ", player.Inventory)}]");
    }
}