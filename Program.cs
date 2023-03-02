int manticoreHP = 10;
int cityHP = 15;
int round = 1;
int cannonDamage;
int targetRange;

int manticoreDistance = AskForNumberInRange("Player 1, how far away from the city do you want to station the Manticore? (0 to 100):", 0, 100);
Console.Clear();

Console.WriteLine("Player 2, it is your turn.");

while (cityHP > 0 && manticoreHP > 0)
{
    ShowGameStatus();
    cannonDamage = CalculateCannonDamage();
    Console.WriteLine($"The cannon is expected to deal {cannonDamage} this round.");
    FireTheCannon();

    if (manticoreHP > 0) cityHP -= 1;
    round++;
}

if (cityHP <= 0)
    Console.WriteLine("The city has been destroyed!");
else if (manticoreHP <= 0)
    Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");

// ---------- METHODS ----------

int AskForNumber(string text)
{
    Console.Write(text + " ");
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

int AskForNumberInRange(string text, int min, int max)
{
    while (true)
    {
        int number = AskForNumber(text);
        if (number > min || number < max)
            return number;
    }
}

void ShowGameStatus()
{
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine($"[STATUS] Round: {round} - City: {cityHP}/15 - Manticore: {manticoreHP}/10");
}

int CalculateCannonDamage()
{
    if (round % 5 == 0 && round % 3 == 0)
        return 10;
    else if (round % 5 == 0 || round % 3 == 0)
        return 3;
    else return 1;
}

void FireTheCannon()
{
    targetRange = AskForNumberInRange("Enter desired cannon range", 0, 100);

    if (targetRange > manticoreDistance)
        Console.WriteLine("That round OVERSHOT the target.");
    else if (targetRange < manticoreDistance)
        Console.WriteLine("That round FELL SHORT of the target.");
    else
    {
        Console.WriteLine("That round was a DIRECT HIT!");
        manticoreHP -= cannonDamage;
    }
}