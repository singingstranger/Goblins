// See https://aka.ms/new-console-template for more information
using Goblins.Core;

Console.WriteLine("Welcome to my wonderful Goblin Hatchery!");
var eggProvider = new GoblinProvider();
var hatchery = new GoblinHatchery(eggProvider);
var employmentAgency = new GoblinEmploymentAgency();

var goblins = hatchery.Hatch();

var employedGoblins = employmentAgency.Employ(goblins);

foreach(var goblin in employedGoblins)
{
    Console.WriteLine($"Goblin hatched! They are called {goblin.Name} and they are {goblin.Colour} and they weild a {goblin.Tools.First().GetType().Name} in their job as {goblin.Job}");
}

//Given a set of freshly hatched goblins,
//When I assign them jobs
//Then red goblins with pickaxes go to the mines
//And red goblins with pens go to the newspaper
//And blue goblins get rejected
//And all other goblins go to the tower

//Given a set of freshly hatched goblins,
//When one has a pen
//Then they are renamed to "writer"

//Given a set of freshly hatched goblins,
//When given a list of Items
//Then only the ones with pickaxes get given rocks

//Given a green goblin with a pen
//When that goblin is sent to the tower
//Then the pen gets replaced with a sword

//Given a green goblin with a pickaxe
//When that goblin is sent to the tower
//Then the pickaxe gets replaced with a bow and 6 arrows

//Given a goblin manager
//When looking at a Goblin Report
//Then the number of goblins is displayed
//And the number is broken down by colour
//And the number is broken down by job

Console.ReadKey();