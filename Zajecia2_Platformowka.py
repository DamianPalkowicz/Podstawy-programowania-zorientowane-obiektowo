class Hero:
    def __init__(self, name: str, x: int, y: int, hp: int):
        self.name = name
        self.x = x
        self.y = y
        self.hp = hp
        self.inventory = []

    def move(self, dx: int):
        self.x += dx
        print(f"[{self.name}] Ruch w bok. Aktualna pozycja X: {self.x}")

    def jump(self, dy: int):
        self.y += dy
        print(f"[{self.name}] Skok. Aktualna pozycja Y: {self.y}")

class Enemy:
    def __init__(self, name: str, x: int, y: int, damage: int):
        self.name = name
        self.x = x
        self.y = y
        self.damage = damage

class Item:
    def __init__(self, name: str, x: int, y: int):
        self.name = name
        self.x = x
        self.y = y

class Platform:
    def __init__(self, x: int, y: int, length: int):
        self.x = x
        self.y = y
        self.length = length

class Level:
    def __init__(self, name: str):
        self.name = name
        self.hero = None
        self.enemies = []
        self.items = []
        self.platforms = []

    def set_hero(self, hero: Hero):
        self.hero = hero
        print(f"--- Bohater {self.hero.name} wkracza na poziom: {self.name} ---")

    def add_enemy(self, enemy: Enemy):
        self.enemies.append(enemy)

    def add_item(self, item: Item):
        self.items.append(item)

    def add_platform(self, platform: Platform):
        self.platforms.append(platform)

    def simulate_turn(self):
        for enemy in self.enemies:
            if self.hero.x == enemy.x and self.hero.y == enemy.y:
                self.hero.hp -= enemy.damage
                print(f"Wpadasz na wroga - {enemy.name}!. Tracisz {enemy.damage}hp.")

        for item in self.items[:]:
            if self.hero.x == item.x and self.hero.y == item.y:
                self.hero.inventory.append(item.name)
                self.items.remove(item)
                print(f"Podnosisz przedmiot: {item.name}")

        on_platform = False
        for plat in self.platforms:
            if plat.y == self.hero.y - 1 and plat.x <= self.hero.x <= (plat.x + plat.length):
                on_platform = True
                
        if on_platform:
            print(f"Bohater stoi na platformie.\n")
        else:
            print(f"Bohater nie stoi na platformie.\n")

if __name__ == "__main__":
    game_level = Level(name="Mroczny Las")
    player = Hero(name="Stefan", x=0, y=1, hp=100)
    goblin = Enemy(name="Goblin", x=2, y=1, damage=15)
    potion = Item(name="Mikstura Leczenia", x=3, y=1)
    ground = Platform(x=0, y=0, length=5)

    game_level.set_hero(hero=player)
    game_level.add_enemy(enemy=goblin)
    game_level.add_item(item=potion)
    game_level.add_platform(platform=ground)

    player.move(dx=1)
    game_level.simulate_turn()

    player.move(dx=1) #Goblin
    game_level.simulate_turn()

    player.move(dx=1) #Potka HP
    game_level.simulate_turn()
    
    player.jump(dy=1)
    game_level.simulate_turn()

    print("\n--- Podsumowanie ---")
    print(f"HP: {player.hp}")
    print(f"Ekwipunek: {player.inventory}")