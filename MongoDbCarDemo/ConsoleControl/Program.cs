using DataAccess;
using DataAccess.Models;
using System;

var carManager = new CarManager();

ConsoleKey key = ConsoleKey.Enter;

while (key != ConsoleKey.Escape)
{
    Console.WriteLine("Enter model, make and color separated by a space:");
    var names = Console.ReadLine().Split(' ');
    Console.WriteLine("Enter it's horsepower:");
    var horsePower = int.Parse(Console.ReadLine());
    Console.WriteLine("Press escape to stop entering cars.");
    key = Console.ReadKey().Key;
    var newCar = new Car() { HorsePower = horsePower, Model = names[0], Make = names[1], Color = names[2] };

    carManager.Add(newCar);
}

var all = carManager.GetAll();
Console.WriteLine("==========================================");

foreach (var car in all)
{
    Console.WriteLine();
    Console.WriteLine($"Id: {car.Id}");
    Console.WriteLine($"Model: {car.Model}");
    Console.WriteLine($"Make: {car.Make}");
    Console.WriteLine($"Color: {car.Color}");
    Console.WriteLine($"HorsePower: {car.HorsePower}");
    Console.WriteLine();
}