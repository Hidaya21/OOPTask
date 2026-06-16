using System.Collections;

namespace OOPTask
{
    //Methods
    //displayRoom()
    public class Room
    {
        public string roomNumber;
        public string roomType;
        public double pricePerNight;
        public Boolean isAvailable;



    }
    //Methods
   //displayGuest()
   //calculateTotalCost()
    public class Guest
    {

        public string guestId;
        public string guestName;
        public string roomNumber;
        public Boolean checkInDate;
        public double totalNights;

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // create rooms a object
            List<Room> rooms = new List<Room>();
            // create guests a object
            List<Guest> guests = new List<Guest>();
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
            switch (choice) {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
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
                    break;
            }

            

        }
    }
} 




