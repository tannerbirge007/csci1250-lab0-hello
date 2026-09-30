/*
 * Name:        Tanner Birge
 * Course:      CSCI 1250, Section 001
 * Assignment:  Lab 03, The Badge Office
 * Date:        September 30, 2026
 * Description: Builds a student badge from a name, two random assignments,
 *              and the walking distance to a first class.
 */

Random rng = new Random();

//Part 1: The name
Console.Write("Full name: ");
string fullName = Console.ReadLine();
fullName = fullName.Trim();

int spacePosition = fullName.IndexOf(" ");
string firstName = fullName.Substring(0, spacePosition);
string lastName = fullName.Substring(spacePosition + 1);

string badgename = fullName.ToUpper();
string username = (firstName.Substring(0, 1) + lastName).ToLower();
string initials = firstName.Substring(0, 1).ToUpper() + "." + lastName.Substring(0, 1).ToUpper() + ".";
int lastnamelength = lastName.Length;

Console.WriteLine("Name on badge: " + badgename);
Console.WriteLine("Username: " + username);
Console.WriteLine("Initials: " + initials);
Console.WriteLine("Letters in last name: " + lastnamelength);

//Part 2: The numbers
int studentid = rng.Next(100000,1000000); 
int locker = rng.Next(1,501);

Console.WriteLine();
Console.WriteLine("student ID:"+ studentid);
Console.WriteLine("Locker:" + locker);

// Part 3: The walk
Console.WriteLine();
Console.Write("dorm X:");
double dormX = double.Parse(Console.ReadLine());

Console.Write("dorm Y:");
double dormY = double.Parse(Console.ReadLine());

Console.Write("class X:");
double classX = double.Parse(Console.ReadLine());

Console.Write("class Y:");
double classY = double.Parse(Console.ReadLine());

Console.Write("Walking speed in feet per second: ");
double speed = double.Parse(Console.ReadLine());

double deltaX = classX - dormX;
double deltaY = classY - dormY;
double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

int totalSeconds = (int)(distance / speed);
int minutes = totalSeconds / 60;
int seconds = totalSeconds % 60;

Console.WriteLine();
Console.WriteLine($"Distance: {distance:F1} feet");
Console.WriteLine($"Walk time: {minutes} minutes {seconds} seconds");

// Part 4:
int checkDigit = studentId % 9;
string fullId = $"{studentId}-{checkDigit}";

string walkDisplay = $"{minutes} min {seconds} sec";

Console.WriteLine();
Console.WriteLine("==================================");
Console.WriteLine("        ETSU STUDENT BADGE        ");
Console.WriteLine("==================================");

Console.WriteLine("NAME".PadRight(10) + badgename);
Console.WriteLine("USERNAME".PadRight(10) + username);
Console.WriteLine("ID".PadRight(10) + fullId);
Console.WriteLine("LOCKER".PadRight(10) + locker);
Console.WriteLine("WALK".PadRight(10) + walkDisplay);
Console.WriteLine("==================================");