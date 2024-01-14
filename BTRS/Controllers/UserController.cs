using BTRS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace BTRS.Controllers
{
    public class UserController : Controller   //connect dbcontext with controller
    {
        private MyDBContext _context;

        public UserController(MyDBContext context)
        {
            this._context = context;
        }



        public IActionResult PassengerBookings()
        {
            //int pid =(int) HttpContext.Session.GetInt32("userID");
            int pid = 1;
            var data = from b in _context.bookings
                       where b.PassengerID == pid
                       select b.TripID;

            List<int> tids = data.ToList();



            var trips = from t in _context.trips
                        where tids.Contains(t.TripID)
                        select t;
            List<Trip> tripList = trips.ToList();

            return View(tripList);
        }



        public IActionResult AdminIndex()
        {

            var data = from u in _context.trips

                       select u;

            IEnumerable<Trip> admin_trips = data.ToList();

            return View(admin_trips);
        }

        public IActionResult PassengerIndex()
        {

            var data = from u in _context.trips

                       select u;

            IEnumerable<Trip> pass_trips = data.ToList();

            return View(pass_trips);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SignUp(Passenger user)
        {
            bool empty = checkEmpty(user);
            bool duplicat = checkUsername(user.UserName);

            if (empty)
            {
                if (duplicat)
                {
                    _context.passengers.Add(user);      //after connect controller with dbcontext
                    _context.SaveChanges();
                    TempData["Msg"] = "the data was saved"; //to sent from controller to view 

                    return View();
                }
                else
                {
                    TempData["Msg"] = "Please Change the username";  //to sent from controller to view 
                    return View();
                }
            }
            else
            {
                TempData["Msg"] = "Please fill all input ";
                return View();
            }
        }


        public bool checkUsername(string username)    //i can use for loop rather than queri 
        {
            Passenger ps = _context.passengers.Where(u => u.UserName.Equals(username)).FirstOrDefault();
            if (ps != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkEmpty(Passenger psng)
        {
            if (String.IsNullOrEmpty(psng.UserName)) return false;
            else if (String.IsNullOrEmpty(psng.Password)) return false;
            else if (String.IsNullOrEmpty(psng.Name)) return false;
            else return true;
        }








        //LOGIN

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(Login userlogin)

        {


            if (ModelState.IsValid)

            {

                string username = userlogin.username;

                string password = userlogin.password;

                Passenger user = _context.passengers.Where(
                     u => u.UserName.Equals(username) &&
                     u.Password.Equals(password)
                     ).FirstOrDefault();

                Admin admin = _context.admains.Where(

                    a => a.UserName.Equals(username)

                    &&

                    a.Password.Equals(password)
                    ).FirstOrDefault();

                if (user != null)
                {
                    HttpContext.Session.SetInt32("userID", user.PassengerID);
                    return RedirectToAction("ListTrips",user);
                }
                else if (admin != null)
                {
                    HttpContext.Session.SetInt32("adminID", admin.AdminID);
                    return RedirectToAction("Index", "Trips");
                }
                else
                {
                    TempData["Msg"] = "The user Not Found";
                }
            }

            else
            {

            }

            return View();

        }
        public IActionResult ListTrips()
        {

            return View("ListTrips", _context.trips.ToList());

        }
       
        public IActionResult Booking(int tripId)
        {

            int TripId = tripId;
            int PassengerID = (int)HttpContext.Session.GetInt32("userID");

            Booking booking = new Booking
            {
                PassengerID = PassengerID,
                TripID = tripId,
                
            };

            booking.Passenger = _context.passengers.Find(PassengerID);
            booking.Trip = _context.trips.Find(TripId);

            _context.bookings.Add(booking);
            _context.SaveChanges();

            return ListTrips();
        }

        public IActionResult FavList()
        {
            int PassengerID = (int)HttpContext.Session.GetInt32("PassengerID");
            List<int> lst_trips = _context.bookings.Where(
            b => b.PassengerID == PassengerID).Select(s=> s.Trip.TripID).ToList();

            List<Trip> lst = _context.trips.Where(
                t => lst_trips.Contains(t.TripID)
                ).ToList(); 

            return View(lst);   

        }



        public IActionResult BooksList()
        {
            int PassengerID = (int)HttpContext.Session.GetInt32("userID");


            var query = from trips in _context.trips
                        join books in _context.bookings on trips.TripID equals books.TripID where books.PassengerID== PassengerID
                        select trips;


            return View("BooksList", query.ToList());

        }









    }
}
