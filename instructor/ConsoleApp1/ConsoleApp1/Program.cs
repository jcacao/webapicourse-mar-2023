


var favoriteNumbers = new List<int>() { 1, 2, 9, 10, 20, 108 };

var evens = favoriteNumbers.Where(n => n % 2 == 0);

favoriteNumbers[0] = 12;

 foreach(var num in evens) // Non-deferred operator - like a foreach
{
    Console.WriteLine( num);
}




