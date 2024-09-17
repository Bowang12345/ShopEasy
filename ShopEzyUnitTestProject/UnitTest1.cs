using Microsoft.AspNetCore.Mvc;
using ShopEzy.Controllers;
using ShopEzy.Models;

namespace ShopEzyUnitTestProject
{
    [TestClass]
    public class CustomerUnitTest
    {
        [TestMethod]
        public void TestIndexMethod()
        {
            CustomerUnitTestController customerUnitTestController = new CustomerUnitTestController();
            IActionResult result = customerUnitTestController.Index() as IActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestLoginMethod()
        {
            CustomerUnitTestController customerUnitTestController = new CustomerUnitTestController();
            IActionResult result = customerUnitTestController.Login("test@email.com","1234567890") as IActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestRegisterMethod()
        {
            CustomerUnitTestController customerUnitTestController = new CustomerUnitTestController();
            Customer customer = new Customer(1, "John", "Doe", "test@email.com", "1234567890", DateTime.Now, "street", "1234567890");
            IActionResult result = customerUnitTestController.Register(customer,"1234567890") as IActionResult;
            Assert.IsNotNull(result);
        }


    }//end of customer controller test class
}