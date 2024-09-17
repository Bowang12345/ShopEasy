using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Moq;
using NuGet.ContentModel;
using ShopEzy.Data;
using ShopEzy.Models;
using System.Net;
using Xunit;

namespace ShopEzy.Controllers
{
    public class CustomerUnitTestController : Controller
    {

        private readonly Mock<CustomerController> _controller;

        public CustomerUnitTestController()
        {
            _controller = new Mock<CustomerController>();
        }

        //get a customer info 
        public Customer GetCustomer() 
        {

            Customer customer = new Customer(1,"John", "Doe", "test@email.com", "1234567890", DateTime.Now, "street","1234567890");

            return customer;
        }

        public IActionResult Index()
        {
            Customer customer = GetCustomer();
            return View(customer);
        }

        public IActionResult? Login(string email, string password)
        {
            Customer customer = GetCustomer();
            if (customer.Email == email && customer.Password == password)
            { 
                return View("Index", customer);
            }
            else
            {
                return null;
            }
            
        }

        public IActionResult? Register(Customer customer,string confirmPassword)
        {
            //validate fields
            if (string.IsNullOrEmpty(customer.FirstName))
            {
                return null;
            }
            if (string.IsNullOrEmpty(customer.LastName))
            {
                return null;
            }
            if (string.IsNullOrEmpty(customer.Email))
            {
                return null;
            }
            if (string.IsNullOrEmpty(customer.PhoneNumber))
            {
                return null;
            }
            if (string.IsNullOrEmpty(customer.Address))
            {
                return null;
            }
            if (string.IsNullOrEmpty(customer.Password))
            {
                return null;
            }
            if (string.IsNullOrEmpty(confirmPassword))
            {
                return null;
            }

            // match passwords
            if (customer.Password != confirmPassword)
            {
                return null;
            }
           
            //IActionResult actionResult = _controller.Register(customer.FirstName, customer.LastName, customer.Email, customer.PhoneNumber, customer.DateOfBirth,customer.Address, customer.Password,confirmPassword);
            /*if (result == null)
            {
                return null;
            }*/
            return View("Index", customer);
        }


        public IActionResult? Update(Customer customer)
        {
            //validate fields
            if (string.IsNullOrEmpty(customer.FirstName))
            {
                return null;
            }
            if (string.IsNullOrEmpty(customer.LastName))
            {
                return null;
            }
            if (string.IsNullOrEmpty(customer.Email))
            {
                return null;
            }
            if (string.IsNullOrEmpty(customer.PhoneNumber))
            {
                return null;
            }
            if (string.IsNullOrEmpty(customer.Address))
            {
                return null;
            }
            if (string.IsNullOrEmpty(customer.Password))
            {
                return null;
            }
            // update customer info




            return View("Index", customer);

        }

    }
}
