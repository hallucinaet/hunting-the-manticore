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
    WriteTextColour($"The cannon is expected to deal {cannonDamage} damage this round.", ConsoleColor.Cyan);
    FireTheCannon();

    if (manticoreHP > 0) cityHP -= 1;
    round++;
}

if (cityHP <= 0)
{
    WriteTextColour("The city has been destroyed!", ConsoleColor.Magenta);
}
else if (manticoreHP <= 0)
{
    WriteTextColour("The Manticore has been destroyed! The city of Consolas has been saved!", ConsoleColor.Blue);
}


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
    if (round % 5 == 0 && round % 3 == 0) return 10;
    else if (round % 5 == 0 || round % 3 == 0) return 3;
    else return 1;
}

void FireTheCannon()
{
    targetRange = AskForNumberInRange("Enter desired cannon range", 0, 100);

    if (targetRange > manticoreDistance)
    {
        WriteTextColour("That round OVERSHOT the target.", ConsoleColor.DarkRed);
    }

    else if (targetRange < manticoreDistance)
    {
        WriteTextColour("That round FELL SHORT of the target.", ConsoleColor.Red);
    }
    else
    {
        WriteTextColour("That round was a DIRECT HIT!", ConsoleColor.Green);
        manticoreHP -= cannonDamage;
    }
}

void WriteTextColour(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ForegroundColor = ConsoleColor.White;
}