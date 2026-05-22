string specialFile;
string logFile;
string saveFile;

string specialFish = "";
string[] fishList = new string[0];

int specialAmount = 0;
int fishAmount = 0;

// Ask for today's special file
while (true)
{
    System.Console.WriteLine("What is the file path for today's special?");
    specialFile = System.Console.ReadLine();

    try
    {
        specialFish = System.IO.File.ReadAllText(specialFile);
        specialFish = specialFish.Trim();
        break;
    }
    catch
    {
        System.Console.WriteLine("That file does not exist. Please try again.");
    }
}

// Ask for fishmonger's log file
while (true)
{
    System.Console.WriteLine("What is the file path for the fishmonger's log?");
    logFile = System.Console.ReadLine();

    try
    {
        fishList = System.IO.File.ReadAllLines(logFile);
        break;
    }
    catch
    {
        System.Console.WriteLine("That file does not exist. Please try again.");
    }
}

// Count fish
foreach (string fish in fishList)
{
    string thisFish = fish.Trim();

    if (thisFish != "")
    {
        fishAmount++;

        if (thisFish == specialFish)
        {
            specialAmount++;
        }
    }
}

// Create final output
string finalText = "";

finalText = finalText + "Today's special is " + specialFish + "\n";
finalText = finalText + "Total " + specialFish + " caught: " + specialAmount + "\n";
finalText = finalText + "Total fish caught: " + fishAmount;

// Ask where to save result until it works
while (true)
{
    System.Console.WriteLine("Where do you want to save the result?");
    System.Console.WriteLine("Please include the file name at the end, like result.txt");
    saveFile = System.Console.ReadLine();

    try
    {
        System.IO.File.WriteAllText(saveFile, finalText);
        break;
    }
    catch
    {
        System.Console.WriteLine("Could not save there. Try another file path and check film name ends with .txt");
        System.Console.WriteLine("Remember: the folder must already exist, but the text file does not have to exist.");
    }
}

System.Console.WriteLine("Result saved.");