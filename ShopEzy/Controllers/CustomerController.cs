using Microsoft.AspNetCore.Mvc;
using ShopEzy.Data;
using ShopEzy.Models;
using ShopEzy.utils;

namespace ShopEzy.Controllers
{
    public class CustomerController : Controller
    {

        private ShopEzyDbContext _dbContext;

        public CustomerController(ShopEzyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            // Get all customers from database
            var customers = _dbContext.Customers.ToList();

            // Pass the customers to the view
            return View(customers);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string firstname, string lastname, string email, string phonenumber, DateTime dateofbirth, string address, string password, string confirmPassword)
        {
            //validate fields
            if (string.IsNullOrEmpty(firstname))
            {
                ModelState.AddModelError("firstname", "First name is required.");
            }
            if (string.IsNullOrEmpty(lastname))
            {
                ModelState.AddModelError("lastname", "Last name is required.");
            }
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("email", "Email is required.");
            }
            if (string.IsNullOrEmpty(phonenumber))
            {
                ModelState.AddModelError("phonenumber", "Phone number is required.");
            }
            if (string.IsNullOrEmpty(address))
            {
                ModelState.AddModelError("address", "Address is required.");
            }
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "Password is required.");
            }
            if (string.IsNullOrEmpty(confirmPassword))
            {
                ModelState.AddModelError("confirmPassword", "Confirm password is required.");
            }

            // match passwords
            if (password != confirmPassword)
            {
                ModelState.AddModelError("confirmPassword", "The password and confirmation password do not match.");
            }

            // if modelstate is not valid ,return and show the error message
            if (!ModelState.IsValid)
            {
                return View();
            }

            // save user 
            _dbContext.Customers.Add(new Customer() 
                                    {   FirstName = firstname, 
                                        LastName = lastname,
                                        Email = email,
                                        PhoneNumber = phonenumber,
                                        DateOfBirth = dateofbirth,
                                        Address = address,
                                        Password = password });
            _dbContext.SaveChanges();

            // set success message
            TempData["SuccessMessage"] = "Registration successful!";

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // query customer from database
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Email == email && c.Password == password);

            if (customer == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View();
            }

            // save user info 
            HttpContext.Session.SetObject("customer", customer);

            // redirect to home page
            return RedirectToAction("Index","Home");


        }
    }
}
