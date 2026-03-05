int numbers;

//number 1
numbers = 0;

while (numbers < 5)
{
    numbers = numbers + 1;
    Console.WriteLine(numbers);
}

//number 2
numbers = 99;

while (numbers < 150)
{
    numbers = numbers + 1;
    Console.WriteLine(numbers);
}

//number 3
numbers = -2;

while (numbers < 100)
{
    
    numbers = numbers + 2;
    Console.WriteLine(numbers);
}

//number 4
numbers = 21;

while (numbers > -20)
{
    numbers = numbers - 1;
    Console.WriteLine(numbers);
}

//number 5
numbers = 1;

while (numbers <= 100)
{
    Console.WriteLine(numbers);
    numbers = numbers + 3;
}

//number 6
numbers = 1;

while (numbers <= 1024)
{
    Console.WriteLine(numbers);
    numbers = numbers * 2;
}

// number 7

bool yesNo;
yesNo = false;

while (yesNo == false)
{
    Console.WriteLine("do you want the loop to stop? if so type stop");
    string input = Console.ReadLine();
    if (input == "stop" || input == "Stop")
    {yesNo = true;} else 
    {yesNo = false;}
}

// number 8 

bool trueFalse;
trueFalse = true;
numbers = 1;
while (numbers < 10)
{
    if (trueFalse == true)
    {
        Console.WriteLine(true);
        trueFalse = false;
    } else if (trueFalse == false)
    {
        Console.WriteLine(false);
        trueFalse = true;
    }

    numbers = numbers + 1;
}

//number 9
bool isEven;
isEven = false;
numbers = 1;

while (numbers <= 20)
{
 Console.WriteLine(numbers);
 numbers = numbers + 1;
 if (isEven == false)
 {
     Console.Write("odd");
         isEven = true;
 }else if(isEven == true)
 {
     Console.Write("even");
     isEven = false;
 }
}

//number 10

string[] value = new string[5];
value = ["once", "upon", "a", "midnight", "dreary"];
int modifier;
modifier = 0;
while (modifier < 5)
{
    Console.WriteLine(value[modifier]);
    modifier++;
}