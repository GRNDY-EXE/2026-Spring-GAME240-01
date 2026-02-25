Console.WriteLine("what is your math question?");

double A;
double B;
int question;
double result;

Console.WriteLine("If you want addition press 1, subtraction press 2, multiplication press 3, division press 4");

question = int.Parse(Console.ReadLine());

if (question == 1) 
{
    Console.WriteLine("what is your first variable?");
    A = int.Parse(Console.ReadLine());
    Console.WriteLine("what is your second variable?");
    B = int.Parse(Console.ReadLine());
    result = A + B;
} else if (question == 2)
{
    Console.WriteLine("what is your first variable?");
    A = int.Parse(Console.ReadLine());
    Console.WriteLine("what is your second variable?");
    B = int.Parse(Console.ReadLine());
    result = A - B;
} else if (question == 3) 
{
    Console.WriteLine("what is your first variable?");
    A = int.Parse(Console.ReadLine());
    Console.WriteLine("what is your second variable?");
    B = int.Parse(Console.ReadLine());
    result = A * B;
} else if (question == 4) 
{
    Console.WriteLine("what is your first variable?");
    A = int.Parse(Console.ReadLine());
    Console.WriteLine("what is your second variable?");
    B = int.Parse(Console.ReadLine());
    result = A / B;
}else
    {
    Console.WriteLine("ERROR");
    result = 0;
    }

Console.WriteLine("result:");
Console.Write(result);



