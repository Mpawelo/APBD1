using System;
using System.Linq;
using APBD1.Domain.Equipment;
using APBD1.Domain.Users;
using APBD1.Repositories;
using APBD1.Services;

namespace APBD1.Menu
{
    public class ConsoleMenu
    {
        private readonly EquipmentRepository _equipmentRepo;
        private readonly UserRepository _userRepo;
        private readonly RentalRepository _rentalRepo;
        private readonly RentalService _rentalService;

        public ConsoleMenu(EquipmentRepository equipmentRepo, UserRepository userRepo, RentalRepository rentalRepo, RentalService rentalService)
        {
            _equipmentRepo = equipmentRepo;
            _userRepo = userRepo;
            _rentalRepo = rentalRepo;
            _rentalService = rentalService;
        }

        public void RunDemonstration()
        {
            Console.WriteLine("-- SYSTEM WYPOŻYCZALNI SPRZĘTU --\n");

            var laptop = new Laptop("Dell XPS 15", "Intel i7", 16);
            var projector = new Projector("Epson 4K", "3840x2160", 3500);
            var camera = new Camera("Sony A7 III", 24.2, true);
            
            _equipmentRepo.Add(laptop);
            _equipmentRepo.Add(projector);
            _equipmentRepo.Add(camera);

            var student = new Student("Krystian", "Pamrowski");
            var employee = new Employee("Ktos", "Wazny");
            
            _userRepo.Add(student);
            _userRepo.Add(employee);

            Console.WriteLine("1. Poprawne wypożyczenie:");
            var rental1 = _rentalService.RentEquipment(student, laptop, 5, _rentalRepo.GetAll());
            _rentalRepo.Add(rental1);
            Console.WriteLine($"Student {student.FirstName} pomyślnie wypożyczył: {laptop.Name}");

            Console.WriteLine("\n2. Próba wypożyczenia niedostępnego sprzętu:");
            try
            {
                _rentalService.RentEquipment(employee, laptop, 2, _rentalRepo.GetAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Złapano oczekiwany błąd: {ex.Message}");
            }

            Console.WriteLine("\n>3. Zwrot sprzętu w terminie:");
            _rentalService.ReturnEquipment(rental1, laptop, DateTime.Now.AddDays(2));
            Console.WriteLine($"Sprzęt {laptop.Name} zwrócony. Naliczona kara: {rental1.PenaltyFee} zł");

            Console.WriteLine("\n4. Zwrot opóźniony-naliczenie kary:");
            var rental2 = _rentalService.RentEquipment(employee, projector, 2, _rentalRepo.GetAll());
            _rentalRepo.Add(rental2);
            
            _rentalService.ReturnEquipment(rental2, projector, DateTime.Now.AddDays(5));
            Console.WriteLine($"Sprzęt {projector.Name} zwrócony po terminie. Naliczona kara: {rental2.PenaltyFee} zł");

            Console.WriteLine("\n-- RAPORT KOŃCOWY: STAN SPRZĘTU --");
            foreach (var eq in _equipmentRepo.GetAll())
            {
                Console.WriteLine($"- {eq.Name} | Typ: {eq.GetType().Name} | Status: {eq.Status}");
            }
        }
    }
}