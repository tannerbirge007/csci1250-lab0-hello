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