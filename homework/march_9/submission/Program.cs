int[] numbers = new int[] { 3, 5, 6, 4, 8, 5, 10, 9, 7, 2, 3 };
int i;
i = 1;
int largest;
largest = numbers[0];


while (i < numbers.Length)
{
    if (numbers[i] > largest)
    {
        largest = numbers[i];
        i = i + 1;
    } else if (numbers[i] < largest)
    {
        i = i + 1;
    }
}

Console.WriteLine("The largest number is " + largest);