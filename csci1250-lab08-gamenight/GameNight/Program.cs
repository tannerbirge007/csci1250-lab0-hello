/*
Name:       Tanner Birge
Course:     CSCI 1250, Section 001
Assignment: Lab 08, Game Night
Date:       November 22, 2026
Description: Keeps a game night leaderboard in three text files. Shows the
             season so far, records tonight's points, saves the new totals,
             and adds tonight's result to a history that grows every week.
*/

const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;

// Look for the data files next to Program.cs, however the program is started.
string projectFolder = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

// Part 3 (Top): Read history.txt and show past game nights
Console.WriteLine("=== GAME NIGHT LEADERBOARD ===");
string[] history = File.ReadAllLines(HISTORY_FILE);

if (history.Length == 0)
{
    Console.WriteLine("No nights played yet.");
}
else
{
    Console.WriteLine($"Nights played: {history.Length}");

    // foreach: every line in the history array is printed in order without needing an index.
    foreach (string line in history)
    {
        Console.WriteLine($"  {line}");
    }
}

int tonightNumber = history.Length + 1;
Console.WriteLine($"Tonight is Night {tonightNumber}.");
Console.WriteLine();

// Part 1: Read both files and show the current standings
string[] players = File.ReadAllLines(PLAYERS_FILE);
string[] points = File.ReadAllLines(POINTS_FILE);

Console.WriteLine("PLAYER".PadRight(11) + "POINTS");

// for: the name and the points live in two arrays,
// and only a shared index keeps them together.
for (int i = 0; i < players.Length; i++)
{
    Console.WriteLine(players[i].PadRight(11) + points[i]);
}

int leader = LeaderIndex(points);
int seasonTotal = TotalPoints(points);

Console.WriteLine($"Leader: {players[leader]} with {points[leader]}");
Console.WriteLine($"Season total: {seasonTotal}");
Console.WriteLine();

// Part 2: Get tonight's points, find tonight's winner, and save new season totals
string winnerTonight = "";
int bestTonight = -1;

// for: we must update points[i] at the same index as players[i].
for (int i = 0; i < players.Length; i++)
{
    Console.Write($"Points tonight for {players[i]}: ");
    int tonight = Convert.ToInt32(Console.ReadLine());

    // while: validation repeats an unknown number of times until a valid score is entered.
    while (tonight < 0 || tonight > MAX_POINTS)
    {
        Console.WriteLine($"Points must be from 0 to {MAX_POINTS}.");
        Console.Write($"Points tonight for {players[i]}: ");
        tonight = Convert.ToInt32(Console.ReadLine());
    }

    int season = Convert.ToInt32(points[i]) + tonight;
    points[i] = season.ToString();

    if (tonight > bestTonight)
    {
        bestTonight = tonight;
        winnerTonight = players[i];
    }
}

Console.WriteLine($"Tonight's winner: {winnerTonight} with {bestTonight}");
Console.WriteLine();

File.WriteAllLines(POINTS_FILE, points);
Console.WriteLine($"Saved {POINTS_FILE}.");

// Part 3 (Bottom): Add tonight's result to history.txt
string[] entry = { HistoryEntry(tonightNumber, winnerTonight, bestTonight) };
File.AppendAllLines(HISTORY_FILE, entry);
Console.WriteLine($"Added to {HISTORY_FILE}: {entry[0]}");

// Returns the index position of the player with the highest score
static int LeaderIndex(string[] points)
{
    int highestIndex = 0;
    int highestScore = Convert.ToInt32(points[0]);

    // for: we need the index position to track where the highest score is stored.
    for (int i = 1; i < points.Length; i++)
    {
        int current = Convert.ToInt32(points[i]);
        if (current > highestScore)
        {
            highestScore = current;
            highestIndex = i;
        }
    }

    return highestIndex;
}

// Returns the sum of all points in the points array
static int TotalPoints(string[] points)
{
    int total = 0;

    // foreach: every value in the array is added without needing its index.
    foreach (string value in points)
    {
        total += Convert.ToInt32(value);
    }

    return total;
}

// Returns the formatted summary string for a single game night
static string HistoryEntry(int night, string winner, int points)
{
    return $"Night {night}: {winner} won with {points} points";
}
