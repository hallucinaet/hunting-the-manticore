int manticoreHP = 10;
int cityHP = 15;
int round = 1;
int manticoreDistance;
int cannonDamage;
int targetRange;

while (true)
{
    Console.Write("Player 1, how far away from the city do you want to station the Manticore? (0 to 100): ");
    manticoreDistance = Convert.ToInt32(Console.ReadLine());

    if (manticoreDistance >= 0 && manticoreDistance <= 100) break;
}

Console.Clear();
Console.WriteLine("Player 2, it is your turn.");

while (cityHP > 0 && manticoreHP > 0)
{
    ShowGameStatus();
    CalculateCannonDamage();
    Console.WriteLine($"The cannon is expected to deal {cannonDamage} this round.");
    FireTheCannon();

    cityHP -= 1;
    round++;
}

if (cityHP <= 0)
    Console.WriteLine("The city has been destroyed!");
else if (manticoreHP <= 0)
    Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");

void ShowGameStatus()
{
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine($"[STATUS] Round: {round} - City: {cityHP}/15 - Manticore: {manticoreHP}/10");
}

void CalculateCannonDamage()
{
    if (round % 5 == 0 && round % 3 == 0)
        cannonDamage = 10;
    else if (round % 5 == 0 || round % 3 == 0)
        cannonDamage = 3;
    else cannonDamage = 1;
}

void FireTheCannon()
{
    Console.Write("Enter desired cannon range: ");
    targetRange = Convert.ToInt32(Console.ReadLine());

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