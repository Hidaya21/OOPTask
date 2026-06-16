using System.Collections;

namespace OOPTask
{
   
    public class Room
    {
        public string roomNumber { get; set; }
        public string roomType { get; set; }
        public double pricePerNight { get; set; }
        public bool isAvailable { get; set; }
        public Room(string roomNumber, string roomType, double pricePerNight, bool isAvailable)
        {
            this.roomNumber = roomNumber;
            this.roomType = roomType;
            this.pricePerNight = pricePerNight;
            this.isAvailable = isAvailable;
        }
        public void DisplayRoom()
        {
            Console.Write("Room Number: " + roomNumber);
            Console.Write("Room Type: " + roomType);
            Console.Write("Price: " + pricePerNight);
            Console.Write("Available: " + isAvailable);
        }



        }
    public class Guest
    {
        public string guestId { get; }
        public string guestName { get; set; }
        public string roomNumber { get; set; }
        public DateTime checkInDate { get; set; }
        public double totalNights { get; set; }
        public Guest(string guestId, string guestName, string roomNumber, DateTime checkInDate, int totalNights)
        {
            this.guestId = guestId;
            this.guestName = guestName;
            this.roomNumber = roomNumber;
            this.checkInDate = checkInDate;
            this.totalNights = totalNights;
        }
        public double calculateTotalCost(Room room)
        {
            return room.pricePerNight * totalNights;
        }
        public void displayGuest()
        {
            Console.WriteLine("ID: " + guestId);
            Console.WriteLine("Name: " + guestName);
            Console.WriteLine("Room: " + roomNumber);
            Console.WriteLine("Nights: " + totalNights);
        }
    }
    internal class Program
    {
        public static void AddRoom(List<Room> rooms)
        {
            Console.Write("Room number: ");
            string roomNumber = Console.ReadLine();
            if (rooms.Any(r => r.roomNumber == roomNumber))
            {
                Console.WriteLine("Room already exists!");
                return;
            }
            Console.Write("Room type: ");
            string roomType = Console.ReadLine();

            Console.Write("Price per night: ");
            if (!double.TryParse(Console.ReadLine(), out double price) || price <= 0)
            {
                Console.WriteLine("Invalid price!");
                return;
            }
            rooms.Add(new Room(roomNumber, roomType, price, true));
            Console.WriteLine("Room added successfully!");
            Console.WriteLine("Total rooms: " + rooms.Count);
        }

        public static void RegisterGuest(List<Guest> guests)
        {
            // Create a unique guest ID automatically (G001, G002, G003...)
            string id = "G" + (guests.Count + 1).ToString("D3");
            Console.Write("Guest name: ");
            string name = Console.ReadLine();
            Console.Write("Check-in date: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Total nights: ");
            // Validate that total nights is a positive integer
            if (!int.TryParse(Console.ReadLine(), out int nights) || nights <= 0)
            {
                Console.WriteLine("Invalid nights");
                return;
            }
            guests.Add(new Guest(id, name, "Not Assigned", date, nights));
            Console.WriteLine("Guest registered successfully! ID:" + id);
        }
        public static void BookRoom(List<Room> rooms, List<Guest> guests)
        {
            Console.Write("Guest ID: ");
            string id = Console.ReadLine();
            var guest = guests.FirstOrDefault(g => g.guestId == id);
            if (guest == null)
            {
                Console.WriteLine("Guest not found!");
                return;
            }
            Console.Write("Room number: ");
            string roomNo = Console.ReadLine();
            var room = rooms.FirstOrDefault(r => r.roomNumber == roomNo);
            if (room == null)
            {
                Console.WriteLine("Room not found!");
                return;
            }
            if (!room.isAvailable)
            {
                Console.WriteLine("Room is already booked!");
                return;
            }
            guest.roomNumber = room.roomNumber;
            room.isAvailable = false;
            double total = guest.calculateTotalCost(room);
            Console.WriteLine("BOOKING CONFIRMED");
            Console.WriteLine("Guest: " + guest.guestName);
            Console.WriteLine("Room: " + room.roomNumber + room.roomType);
            Console.WriteLine("Price: "+room.pricePerNight);
            Console.WriteLine("Nights: "+ guest.totalNights);
            Console.WriteLine("Total: " + total + "OMR" );
        }


        static void Main(string[] args)
        {
            // create rooms a object
            List<Room> rooms = new List<Room>
            {             
                new Room("001","Single",50,true),
                new Room("002","Double",80,true),
                new Room("003","Suite",120,true),
                new Room("004","Single",55,true),
                new Room("005","Double",90,true),
                new Room("006","Suite",150,true)
            };
            // create guests a object
            List<Guest> guests = new List<Guest>();
            while (true)
            {
                Console.WriteLine("================================= ");
                Console.WriteLine(" GRAND VISTA HOTEL — MANAGEMENT SYSTEM ");
                Console.WriteLine("================================= ");
                Console.WriteLine("1. Add New Room");
                Console.WriteLine("2. Register New Guest ");
                Console.WriteLine("3. Book a Room for a Guest  ");
                Console.WriteLine("4. Search & Filter Rooms   ");
                Console.WriteLine("5. Guest & Booking Statistics ");
                Console.WriteLine("6. Check Out a Guest");
                Console.WriteLine("7. Remove Unavailable Rooms");
                Console.WriteLine("0. Exit");
                Console.WriteLine("================================= ");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddRoom(rooms);
                        break;
                    case 2:
                        RegisterGuest(guests);
                        break;
                    case 3:
                        BookRoom(rooms, guests);
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 0:
                        return;
                }
            }

            

        }
    }
} 




