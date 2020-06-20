using MarsRover.Business.Services;
using MarsRover.Common.Enum;
using MarsRover.Core.Interfaces;
using MarsRover.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var services = ServiceContainerBuilder.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            Console.WriteLine("Welcome to the Mars Rover Commander");
            
            Console.WriteLine("Enter Plateau Size(Ex: 5 5) : ");
            var plateauSize = Console.ReadLine();

            var plateau = serviceProvider.GetService<IPlateau>();
            plateau.SetSize(plateauSize);

            var roverCommander = serviceProvider.GetService<IRoverCommander>();
            roverCommander.Plateau = plateau;

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Rover Position(Ex: 1 2 N) : ");
                    var roverPosition = Console.ReadLine();

                    Console.WriteLine("Enter Rover Commands (Ex : LMLMLMLMM) : ");
                    var roverCommands = Console.ReadLine();

                    IRover rover = serviceProvider.GetService<IRover>();
                    rover.SetPosition(roverPosition);
                    rover.Commands = roverCommands;

                    roverCommander.Plateau.AddRover(rover);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Do you want to add one more Rover?(Y/N) : ");
                var continueInput = Console.ReadLine();

                if (continueInput != "Y")
                    break;
            };

            foreach (var rover in roverCommander.Plateau.Rovers)
            {
                try
                {
                    roverCommander.Move(rover);
                    Console.WriteLine($"{rover.LocationX} {rover.LocationY} {rover.Direction.ToString()}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }

            Console.Read();
        }
    }
}
