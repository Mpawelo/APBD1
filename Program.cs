using System;
using APBD1.Repositories;
using APBD1.Services;
using APBD1.Menu;

namespace APBD1
{
    class Program
    {
        static void Main(string[] args)
        {
            var equipmentRepo = new EquipmentRepository();
            var userRepo = new UserRepository();
            var rentalRepo = new RentalRepository();

            var penaltyCalculator = new PenaltyCalculator();
            var rentalService = new RentalService(penaltyCalculator);

            var menu = new ConsoleMenu(equipmentRepo, userRepo, rentalRepo, rentalService);

            menu.RunDemonstration();

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}