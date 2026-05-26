Room currentRoom = Room.Home;

bool gameRunning = true;
bool gateUnlocked = false;

int money = 0;
int joeWins = 0;

bool ticketReady = false;
bool hasTicket = false;
bool usedWallet = false;

slowText("I really want to go to the concert tonight...");
slowText("But tickets are 100 dollars.");
slowText("I guess I should work hard at my job and definitely not waste time gambling with Old Joe.");
slowText("Anyway, I am at Chapman now.");
slowText("");

describeRoom(currentRoom);

while (gameRunning)
{
    slowText("");
    slowText("What do you want to do?");
    Console.WriteLine("Type commands like: move right, take ticket, use wallet, use ticket");
    string playerInput = System.Console.ReadLine();

    string[] words = playerInput.Split(" ");

    if (words.Length < 2)
    {
        slowText("That command needs two words, like move right or use wallet.");
    }
    else
    {
        string command = words[0].ToLower();
        string thing = words[1].ToLower();

        switch (currentRoom)
        {
            case Room.Home:
                if (command == "move")
                {
                    if (thing == "right")
                    {
                        currentRoom = Room.VillageHub;
                        describeRoom(currentRoom);
                    }
                    else
                    {
                        slowText("You cannot move that way from here.");
                    }
                }
                else if (command == "take")
                {
                    slowText("There is nothing useful to take here.");
                }
                else if (command == "use")
                {
                    useItem(thing);
                }
                else
                {
                    slowText("That is not a valid command.");
                }
                break;

            case Room.VillageHub:
                if (command == "move")
                {
                    if (thing == "left")
                    {
                        currentRoom = Room.Home;
                        describeRoom(currentRoom);
                    }
                    else if (thing == "up")
                    {
                        currentRoom = Room.OldJoesHouse;
                        describeRoom(currentRoom);
                    }
                    else if (thing == "down")
                    {
                        currentRoom = Room.Work;
                        describeRoom(currentRoom);
                    }
                    else if (thing == "right")
                    {
                        currentRoom = Room.Gate;
                        describeRoom(currentRoom);
                    }
                    else
                    {
                        slowText("You cannot move that way from here.");
                    }
                }
                else if (command == "take")
                {
                    slowText("There is nothing to take here. Chapman is beautiful, but you probably should not steal campus decorations.");
                }
                else if (command == "use")
                {
                    useItem(thing);
                }
                else
                {
                    slowText("That is not a valid command.");
                }
                break;

            case Room.Work:
                if (command == "move")
                {
                    if (thing == "up")
                    {
                        currentRoom = Room.VillageHub;
                        describeRoom(currentRoom);
                    }
                    else
                    {
                        slowText("You cannot move that way from here.");
                    }
                }
                else if (command == "take")
                {
                    slowText("You cannot take anything here. Your boss is watching.");
                }
                else if (command == "use")
                {
                    if (thing == "desk")
                    {
                        money = money + 10;
                        slowText("After many boring hours, you earned 10 bucks.");
                        slowText("Your boss scolded you for looking tired.");
                        slowText("You now have $" + money + ".");
                    }
                    else
                    {
                        useItem(thing);
                    }
                }
                else
                {
                    slowText("That is not a valid command.");
                }
                break;

            case Room.OldJoesHouse:
                if (command == "move")
                {
                    if (thing == "down")
                    {
                        currentRoom = Room.VillageHub;
                        describeRoom(currentRoom);
                    }
                    else
                    {
                        slowText("You cannot move that way from here.");
                    }
                }
                else if (command == "take")
                {
                    if (thing == "ticket")
                    {
                        if (ticketReady == true && hasTicket == false)
                        {
                            hasTicket = true;
                            slowText("You took the concert ticket from Old Joe's table.");
                            slowText("Joe says: Don't lose it, kid.");
                        }
                        else if (hasTicket == true)
                        {
                            slowText("You already have the ticket.");
                        }
                        else
                        {
                            slowText("Joe has not given you a ticket yet. You need to win blackjack 2 times.");
                        }
                    }
                    else
                    {
                        slowText("You cannot take that here.");
                    }
                }
                else if (command == "use")
                {
                    if (thing == "cards")
                    {
                        slowText("Joe says: Alright, one round of blackjack.");
                        bool gameResultWin = blackjackGame();

                        if (gameResultWin == true)
                        {
                            joeWins = joeWins + 1;
                            slowText("Joe says: You got lucky.");
                            slowText("You have beaten Joe " + joeWins + " time(s).");
    //change number of wins to get ticket here (note also need to change joe dialogue.
                            if (joeWins >= 2 && ticketReady == false)
                            {
                                ticketReady = true;
                                slowText("Joe sighs and pulls out a concert ticket.");
                                slowText("Joe says: Fine. You earned it. Type take ticket.");
                            }
                        }
                        else
                        {
                            slowText("Joe says: Better luck next time.");
                        }
                    }
                    else
                    {
                        useItem(thing);
                    }
                }
                else
                {
                    slowText("That is not a valid command.");
                }
                break;

            case Room.Gate:
                if (command == "move")
                {
                    if (thing == "left")
                    {
                        currentRoom = Room.VillageHub;
                        describeRoom(currentRoom);
                    }
                    else if (thing == "right")
                    {
                        if (gateUnlocked == true)
                        {
                            currentRoom = Room.Concert;
                            describeRoom(currentRoom);
                            slowText("You made it into the concert.");
                            slowText("The lights flash. The bass shakes the floor.");
                            slowText("YOU WIN!");
                            gameRunning = false;
                        }
                        else
                        {
                            slowText("The security guard blocks the entrance.");
                            slowText("Security Guard says: No ticket, no entry.");
                        }
                    }
                    else
                    {
                        slowText("You cannot move that way from here.");
                    }
                }
                else if (command == "take")
                {
                    slowText("There is nothing to take here. The security guard is staring at you.");
                }
                else if (command == "use")
                {
                    if (thing == "wallet")
                    {
                        usedWallet = true;
                        slowText("You check your wallet.");
                        slowText("You have $" + money + ".");

                        if (money >= 100 && hasTicket == false)
                        {
                            money = money - 100;
                            hasTicket = true;
                            slowText("You buy a concert ticket for $100.");
                            slowText("Security Guard says: Alright, now use the ticket.");
                        }
                        else if (hasTicket == true)
                        {
                            slowText("Your concert ticket is in your wallet.");
                        }
                        else
                        {
                            slowText("You do not have enough money for a ticket.");
                        }
                    }
                    else if (thing == "ticket")
                    {
                        if (hasTicket == true)
                        {
                            gateUnlocked = true;
                            slowText("You show the ticket to the security guard.");
                            slowText("Security Guard says: You're good. Go in.");
                            slowText("The gate is now open. Type move right to enter the concert.");
                        }
                        else
                        {
                            slowText("You do not have a ticket.");
                        }
                    }
                    else
                    {
                        useItem(thing);
                    }
                }
                else
                {
                    slowText("That is not a valid command.");
                }
                break;

            case Room.Concert:
                slowText("You are already at the concert. You win.");
                gameRunning = false;
                break;
        }
    }
}

void describeRoom(Room room)
{
    slowText("");

    switch (room)
    {
        case Room.Home:
            slowText("Home");
            slowText("This is your starting room. You are getting ready for the day.");
            slowText("Items you can use: wallet");
            slowText("Exits: right");
            break;

        case Room.VillageHub:
            slowText("Village Hub");
            slowText("You are standing at Chapman. The campus looks beautiful, with warm brick buildings, trees, and students walking between classes.");
            slowText("Items you can take: none");
            slowText("Items you can use: wallet");
            slowText("Exits: left to Home, up to Old Joe's House, down to Work, right to Gate");
            break;

        case Room.OldJoesHouse:
            slowText("Old Joe's House");
            slowText("Old Joe's place smells like old carpet, coffee, and questionable decisions.");
            slowText("Joe says: You here to play blackjack again?");
            slowText("Items you can use: cards");
            if (ticketReady == true && hasTicket == false)
            {
                slowText("Items you can take: ticket");
            }
            else
            {
                slowText("Items you can take: none");
            }
            slowText("Exits: down to Village Hub");
            break;

        case Room.Work:
            slowText("Work");
            slowText("This is your boring job. You can work here to earn money.");
            slowText("Your boss says: Stop standing around.");
            slowText("Items you can use: desk");
            slowText("Exits: up to Village Hub");
            break;

        case Room.Gate:
            slowText("Gate to Concert");
            slowText("A serious security guard stands between you and the concert.");
            slowText("Security Guard says: Ticket or 100 dollars. Otherwise, keep walking.");
            slowText("Items you can use: wallet, ticket");
            if (gateUnlocked == true)
            {
                slowText("Exits: left to Village Hub, right to Concert");
            }
            else
            {
                slowText("Exits: left to Village Hub, right to Concert is locked");
            }
            break;

        case Room.Concert:
            slowText("Concert");
            slowText("You finally made it inside. The crowd is loud and the stage lights are flashing.");
            slowText("Items you can take: none");
            slowText("Exits: none");
            break;
    }
}

void useItem(string item)
{
    if (item == "wallet")
    {
        usedWallet = true;
        slowText("You check your wallet.");
        slowText("You have $" + money + ".");

        if (hasTicket == true)
        {
            slowText("You also have a concert ticket.");
        }
        else
        {
            slowText("You do not have a concert ticket.");
        }
    }
    else if (item == "ticket")
    {
        if (hasTicket == true)
        {
            slowText("You hold up your ticket, but there is nobody here to show it to.");
        }
        else
        {
            slowText("You do not have a ticket.");
        }
    }
    else
    {
        slowText("You cannot use that here.");
    }
}
//ngl I coded this blackjack game in class and worked on it throughout the semester, so I just wanted to make a game around this:
bool blackjackGame()
{
    int[] dealer = new int[2];
    int dealerHand = 0;

    int[] player = new int[2];
    int playerHand = 0;

    System.Random random = new System.Random();

    bool dealerBust = false;
    bool bustPlayer = false;

    int randomNumberInRange;

    bool playerTurn = true;

    slowText("LETS PLAY BLACKJACK!!");

    randomNumberInRange = randomNumberGenerator(random, playerTurn);
    dealer[0] = randomNumberInRange;

    randomNumberInRange = randomNumberGenerator(random, playerTurn);
    player[0] = randomNumberInRange;

    randomNumberInRange = randomNumberGenerator(random, playerTurn);
    dealer[1] = randomNumberInRange;

    randomNumberInRange = randomNumberGenerator(random, playerTurn);
    player[1] = randomNumberInRange;

    dealerHand = dealer[0] + dealer[1];
    playerHand = player[0] + player[1];

    slowText("Dealer's hand: " + dealer[0] + ", " + dealer[1]);
    slowText("Player's hand: " + player[0] + ", " + player[1]);
    slowText("Player total: " + playerHand);

    slowText("Do you want to hit or stand?");
    string input = System.Console.ReadLine();

    while ((input.ToLower() == "hit") && (bustPlayer == false))
    {
        randomNumberInRange = randomNumberGenerator(random, playerTurn);

        slowText("New card: " + randomNumberInRange);

        playerHand = playerHand + randomNumberInRange;

        slowText("Player total: " + playerHand);

        if (playerHand > 21)
        {
            bustPlayer = true;
            slowText("BUST!");
        }
        else
        {
            slowText("Do you want to hit or stand?");
            input = System.Console.ReadLine();
        }
    }

    slowText("Dealer's turn");
    slowText("Dealer total: " + dealerHand);

    playerTurn = false;

    while ((playerHand > dealerHand) && (dealerBust == false) && (bustPlayer == false))
    {
        randomNumberInRange = randomNumberGenerator(random, playerTurn);

        slowText("Dealer gets new card: " + randomNumberInRange);

        dealerHand = dealerHand + randomNumberInRange;
        slowText("Dealer total: " + dealerHand);

        if (dealerHand > 21)
        {
            dealerBust = true;
        }
    }

    if (dealerBust == true)
    {
        slowText("DEALER BUST!");
    }

    if (((playerHand > dealerHand) && (bustPlayer == false)) || (dealerBust == true))
    {
        slowText("You Win");
        return true;
    }
    else if (playerHand == dealerHand)
    {
        slowText("Tie");
        return false;
    }
    else
    {
        slowText("You Lose");
        return false;
    }
}

int randomNumberGenerator(System.Random random, bool playerTurn)
{
    int inputNum;

    inputNum = random.Next(1, 13);

    if ((inputNum == 1) && (playerTurn == true))
    {
        slowText("You have an ace. Do you want it to be 11?");
        slowText("Write yes for 11, no for 1.");

        string aceInput = System.Console.ReadLine();

        if (aceInput.ToLower() == "yes")
        {
            inputNum = 11;
            return inputNum;
        }
        else
        {
            return inputNum;
        }
    }
    else if (inputNum > 10)
    {
        inputNum = 10;
        return inputNum;
    }

    return inputNum;
}

void slowText(string text)
{
    foreach (char letter in text)
    {
        System.Console.Write(letter);
        System.Threading.Thread.Sleep(20);
    }

    System.Console.WriteLine();
}

enum Room
{
    Home,
    VillageHub,
    OldJoesHouse,
    Work,
    Gate,
    Concert
}