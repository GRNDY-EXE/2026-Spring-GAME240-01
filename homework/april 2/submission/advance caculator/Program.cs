string operation;
operation = "a";
string inputString;
int x = 0;
int y = 0;
string[] splitInput;
bool use;
use = true;
int result = 0;
int reminder = 0;
int answer = 0;
bool haveResult = false;
Console.WriteLine("This calculator can perform 4 operations: addition (+), subtraction (-), multiplication (*), modulus operation (%) and division.");
Console.WriteLine("Please type a mathematical expression, or type \"quit\" to shut down the calculator.");
Console.WriteLine("(also you may use \"answer\" as variable)");
while (use)
{
    
    
    inputString = Console.ReadLine();
    

    if (inputString.ToLower() == "quit")
    {
        use = false;
        Console.WriteLine("goodbye");
    }else{
        inputString = inputString + " 1 2";
    splitInput = inputString.Trim().Split( );
    operation = (splitInput[1]); 
    if (operation == "+" || 
        operation == "-" || 
        operation == "*" || 
        operation == "/" ||
        operation == "%")
    {
        use = true;
        if (splitInput[0].ToLower() == "answer" && haveResult == true)
        {
            x = answer;
            
        } else if (splitInput[0].ToLower() == "answer" && haveResult == false)
        {
            Console.WriteLine("No previous answer exists, try again");
            continue;
        }
        else
        {
            x = int.Parse(splitInput[0]); 
        } 
   
    operation = (splitInput[1]);

    if (splitInput[2].ToLower() == "answer")
    {
        y = answer;
    }else if (splitInput[0].ToLower() == "answer" && haveResult == false)
    {
        Console.WriteLine("No previous answer exists, try again");
        continue;
    }
    else
    {
        y = int.Parse(splitInput[2]);
    }
    
        if (operation == "+")
        {
            result = x + y;
            Console.WriteLine( """=""" + result);
            haveResult = true;
        }  else if (operation == "-")
        {
            result = x - y; 
            Console.WriteLine( """=""" + result);
            haveResult = true;
        } else if (operation == "*")
        {
            result = x * y;
            Console.WriteLine( """=""" + result);
            haveResult = true;
        } else if (operation == "/")
            {
            result = x / y;
            reminder = x % y;
            haveResult = true;
            Console.WriteLine("""=""" + result + "reminder of" + reminder);
            } else if (operation == "%")
        {
            result = x % y;
            Console.WriteLine("""=""" + result);
            haveResult = true;
        }
    }
    else
    {
        Console.WriteLine("I do not know how to do that please try again. (note remember to add space between operations and number)");
        use = true;
        haveResult = false;
    }
   
    answer = result;
    
    Console.WriteLine("Please type a mathematical expression, or type \"quit\" to shut down the calculator. (also you may use \"answer\" as variable)");
}
}