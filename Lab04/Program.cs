/*
 * Name:        Tanner Birge
 * Course:      CSCI 1250, Section 001
 * Assignment:  Lab 04, The Group Trip
 * Date:        October 14, 2026
 * Description: Rebuilds the trip calculator with methods and arrays so it
 *              reports on a whole group instead of one person.
 */

// Two constants carried over from Lab 02
const double SLICES_PER_PIZZA = 8;
const double TAX_RATE = 0.18;

// Five questions that stay
Console.Write("Round trip miles: ");
double roundTripMiles = double.Parse(Console.ReadLine());

Console.Write("Miles per gallon: ");
double milesPerGallon = double.Parse(Console.ReadLine());

Console.Write("Price per gallon: ");
double pricePerGallon = double.Parse(Console.ReadLine());

Console.Write("How many pizzas: ");
double numberOfPizzas = double.Parse(Console.ReadLine());

Console.Write("Price per pizza: ");
double pricePerPizza = double.Parse(Console.ReadLine());

Console.WriteLine();

// Part 1: Moves fuel math into a method and calculates trip totals
double fuelCost = FuelCost(roundTripMiles, milesPerGallon, pricePerGallon);
double pizzaCost = numberOfPizzas * pricePerPizza;
double tripTotal = fuelCost + pizzaCost;

Console.WriteLine("=== Part 1: The Trip ===");
Console.WriteLine("Fuel cost: " + fuelCost.ToString("C"));
Console.WriteLine("Pizza cost: " + pizzaCost.ToString("C"));
Console.WriteLine("Trip total: " + tripTotal.ToString("C"));
Console.WriteLine();

// Part 2: Declares the group arrays and splits the cost and slices
string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

double totalSlices = numberOfPizzas * SLICES_PER_PIZZA;
double slicesPerPerson = totalSlices / names.Length;
double costPerPerson = tripTotal / names.Length;

Console.WriteLine("=== Part 2: The Group ===");
Console.WriteLine("People going: " + names.Length);
Console.WriteLine("Slices each: " + slicesPerPerson.ToString("F1"));
Console.WriteLine("Cost per person: " + costPerPerson.ToString("C"));
Console.WriteLine();

// Part 3: Loops through every person, reports their hours, and tallies totals
double totalHours = 0;
double totalTakeHomePay = 0;
double longest = 0;

Console.WriteLine("=== Part 3: Who Works How Long ===");

for (int i = 0; i < names.Length; i++)
{
    double takeHomePay = TakeHomePay(hoursWorked[i], hourlyRates[i], TAX_RATE);
    double takeHomePayPerHour = takeHomePay / hoursWorked[i];
    double hoursToWork = HoursToCover(costPerPerson, takeHomePayPerHour);

    totalHours += hoursWorked[i];
    totalTakeHomePay += takeHomePay;
    longest = Math.Max(longest, hoursToWork);

    Console.WriteLine(names[i] + ": takes home " + takeHomePay.ToString("C") + " for " + hoursWorked[i].ToString("F0") + " hours, " + takeHomePayPerHour.ToString("C") + " per hour, must work " + hoursToWork.ToString("F2") + " hours");
}

Console.WriteLine();
Console.WriteLine("Total hours worked: " + totalHours.ToString("F0"));
Console.WriteLine("Total take home pay: " + totalTakeHomePay.ToString("C"));
Console.WriteLine("Longest anyone must work: " + longest.ToString("F2"));


// ==========================================
// Methods
// ==========================================

// Calculates and returns the fuel cost from round trip miles, mpg, and price per gallon
static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}

// Calculates and returns the net take-home pay after tax withholding
static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours * hourlyRate;
    double taxWithheld = grossPay * taxRate;
    return grossPay - taxWithheld;
}

// Calculates and returns the hours needed to cover a given amount owed
static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed / takeHomePerHour;
}