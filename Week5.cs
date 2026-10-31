
using System;

// ===== PART A =====
// A1: 5
// A2: Hurt
// A3: 4
// A4: 14


//B1
{
    int baseDamage = 40;
    int armor = 15;
    int level = 4;

    int damage = baseDamage - armor;

    if (level >= 5)
    {
        damage += 10;
    }

    if (damage < 1)
    {
        damage = 1;
    }

    string label;

    if (damage >= 30)
    {
        label = "Strong hit";
    }
    else if (damage >= 10)
    {
        label = "Normal hit";
    }
    else
    {
        label = "Weak hit";
    }

    Console.WriteLine($"Damage: {damage} ({label})");

   
    level = 6;
    damage = baseDamage - armor;

    if (level >= 5)
        damage += 10;

    if (damage < 1)
        damage = 1;

    label = damage >= 30 ? "Strong hit" :
            damage >= 10 ? "Normal hit" : "Weak hit";

    Console.WriteLine($"Damage: {damage} ({label})");

    
    level = 4;
    armor = 50;
    damage = baseDamage - armor;

    if (level >= 5)
        damage += 10;

    if (damage < 1)
        damage = 1;

    label = damage >= 30 ? "Strong hit" :
            damage >= 10 ? "Normal hit" : "Weak hit";

    Console.WriteLine($"Damage: {damage} ({label})");
}


//B2
{
    int gold = 120;
    int choice = 2;
    int price = 0;
    string item = "";

    switch (choice)
    {
        case 1:
            item = "Sword";
            price = 100;
            break;

        case 2:
            item = "Bow";
            price = 80;
            break;

        case 3:
            item = "Potion";
            price = 25;
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;
    }

    if (choice >= 1 && choice <= 3)
    {
        if (gold >= price)
        {
            gold -= price;
            Console.WriteLine($"You bought a {item}! Gold left: {gold}");
        }
        else
        {
            Console.WriteLine($"You need {price - gold} more gold.");
        }
    }
}


//B3 
{
    for (int wave = 1; wave <= 30; wave++)
    {
        string monster;

        if (wave % 3 == 0 && wave % 5 == 0)
        {
            monster = "BOSS";
        }
        else if (wave % 3 == 0)
        {
            monster = "Slime";
        }
        else if (wave % 5 == 0)
        {
            monster = "Bat";
        }
        else
        {
            monster = "empty";
        }

        Console.WriteLine($"Wave {wave}: {monster}");
    }
}


//B4 
{
    int level = 1;
    int xp = 0;
    int fights = 0;

    while (level < 5)
    {
        fights++;
        xp += 35;

        if (xp >= 100)
        {
            xp -= 100;
            level++;

            Console.WriteLine($"LEVEL UP! Now level {level}");
        }
    }

    Console.WriteLine(
        $"Reached level {level} after {fights} fights (xp left: {xp})");
}


//Buradan sonrasını Ai yardımı ile yaıldı hocam
{
    int Clamp(int value, int min, int max)
    {
        if (value < min)
            return min;

        if (value > max)
            return max;

        return value;
    }

    Console.WriteLine(Clamp(150, 0, 100));
    Console.WriteLine(Clamp(-20, 0, 100));
    Console.WriteLine(Clamp(55, 0, 100));

    int hp = 80;
    hp += 50;

    hp = Clamp(hp, 0, 100);

    Console.WriteLine($"HP after potion: {hp}");
}


//B6
{
    string GetRank(int score)
    {
        if (score >= 1000)
            return "Gold";

        if (score >= 500)
            return "Silver";

        if (score >= 1)
            return "Bronze";

        return "No medal";
    }

    for (int score = 0; score <= 1250; score += 250)
    {
        Console.WriteLine($"Score {score}: {GetRank(score)}");
    }
}


//B7
{
    int Attack(int hp, int damage)
    {
        hp -= damage;

        if (hp < 0)
            hp = 0;

        return hp;
    }

    bool IsAlive(int hp)
    {
        return hp > 0;
    }

    int playerHp = 150;
    int bossHp = 120;
    int playerDamage = 25;
    int bossDamage = 25;
    int turn = 0;

    while (IsAlive(playerHp) && IsAlive(bossHp))
    {
        turn++;

        bossHp = Attack(bossHp, playerDamage);

        if (!IsAlive(bossHp))
        {
            Console.WriteLine($"Turn {turn} | Boss: {bossHp}");
            break;
        }

        int damage = bossDamage;

        if (turn % 3 == 0)
        {
            damage *= 2;
        }

        playerHp = Attack(playerHp, damage);

        Console.WriteLine(
            $"Turn {turn} | Boss: {bossHp} | Player: {playerHp}");
    }

    if (IsAlive(playerHp))
    {
        Console.WriteLine(
            $"You win in {turn} turns! HP left: {playerHp}");
    }
    else
    {
        Console.WriteLine(
            $"You lose in {turn} turns! Boss HP left: {bossHp}");
    }
}


//B8
{
    string Hint(int guess, int secret)
    {
        if (guess < secret)
            return "Too low";

        if (guess > secret)
            return "Too high";

        return "Correct!";
    }

    int secret = 42;
    int tries = 5;
    int usedTries = 0;
    bool found = false;

    while (tries > 0)
    {
        Console.Write($"Guess ({tries} tries left): ");

        int guess = int.Parse(Console.ReadLine()!);

        usedTries++;
        tries--;

        string hint = Hint(guess, secret);

        Console.WriteLine(hint);

        if (guess == secret)
        {
            found = true;
            break;
        }
    }

    if (found)
    {
        Console.WriteLine($"You found it in {usedTries} tries!");
    }
    else
    {
        Console.WriteLine("You lost! No tries left.");
    }
}
