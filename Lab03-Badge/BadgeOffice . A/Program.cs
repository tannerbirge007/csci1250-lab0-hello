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
