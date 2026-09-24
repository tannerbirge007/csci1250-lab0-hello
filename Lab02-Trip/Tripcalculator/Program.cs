/*
* Name:        Tanner Birge
* Course:      CSCI 1250, Section 001
* Assignment:  Lab 02, Trip Calculator
* Date:        September 23, 2026
* Description: Calculates the fuel, food, and work hours behind one road trip.
*/

// Part 1: Calculates fuel required and total fuel cost
Console.WriteLine("=== Part 1: Road Trip ===");

Console.Write("Round trip miles: ");
double roundTripMiles = double.Parse(Console.ReadLine());

Console.Write("Miles per gallon: ");
double milesPerGallon = double.Parse(Console.ReadLine());

Console.Write("Price per gallon: ");
double pricePerGallon = double.Parse(Console.ReadLine());

double gallonsNeeded = roundTripMiles / milesPerGallon;
double fuelCost = gallonsNeeded * pricePerGallon;

Console.WriteLine();
Console.WriteLine("Gallons needed: " + gallonsNeeded.ToString("F2"));
Console.WriteLine("Fuel cost: " + fuelCost.ToString("C"));
// Part 2: Calculates total slices, slices per person, and pizza cost
Console.WriteLine();
Console.WriteLine("=== Part 2: Pizza Party ===");

const double SLICES_PER_PIZZA = 8;

Console.Write("How many people are going: ");
double numberOfPeople = double.Parse(Console.ReadLine());

Console.Write("How many pizzas: ");
double numberOfPizzas = double.Parse(Console.ReadLine());

Console.Write("Price per pizza: ");
double pricePerPizza = double.Parse(Console.ReadLine());

double totalSlices = numberOfPizzas * SLICES_PER_PIZZA;
double slicesPerPerson = totalSlices / numberOfPeople;
double pizzaCost = numberOfPizzas * pricePerPizza;

Console.WriteLine();
Console.WriteLine("Total slices: " + totalSlices);
Console.WriteLine("Slices per person: " + slicesPerPerson.ToString("F1"));
Console.WriteLine("Pizza cost: " + pizzaCost.ToString("C"));