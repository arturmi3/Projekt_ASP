using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Threading.Tasks;
using System.Linq;

using eBilet2;
using eBilet2.Models;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestCustomerControllerIndex()
        {
            var mockRepo = new eBilet2.SimpleCustomerRepository();
            mockRepo.SaveNewCustomer(new Customer { Id = 1, Name = "AA", Surname = "BB", Email = "aaa@ccc.dd", Status = CustomerStatus.Active, RegisterDate = DateTime.Now, });
            mockRepo.SaveNewCustomer(new Customer { Id = 2, Name = "BB", Surname = "EE", Email = "bbb@ccc.dd", Status = CustomerStatus.Removed, RegisterDate = DateTime.Now, });

            eBilet2.Controllers.CustomersController controller = new eBilet2.Controllers.CustomersController(mockRepo);

            var result = await controller.Index();
            
            // Assert
            Assert.IsNotNull(result);

            var model = ((Microsoft.AspNetCore.Mvc.ViewResult)result).Model;

            var collection = model as System.Collections.Generic.List<eBilet2.Models.Customer>;

            Assert.IsTrue(collection.Count == mockRepo.ListCustomers().Count());
        }

        [TestMethod]
        public async Task TestCustomerControllerEditValidation()
        {
            var mockRepo = new eBilet2.SimpleCustomerRepository();
            mockRepo.SaveNewCustomer(new Customer { Id = 1, Name = "AA", Surname = "BB", Email = "aaa@ccc.dd", Status = CustomerStatus.Active, RegisterDate = DateTime.Now, });
            mockRepo.SaveNewCustomer(new Customer { Id = 2, Name = "BB", Surname = "EE", Email = "bbb@ccc.dd", Status = CustomerStatus.Removed, RegisterDate = DateTime.Now, });

            eBilet2.Controllers.CustomersController controller = new eBilet2.Controllers.CustomersController(mockRepo);

            var result = await controller.Edit(2, new Customer { Id = 2, Name = "CC", Surname = "DD", Email = "public@email.dd", Status = CustomerStatus.Active, RegisterDate = DateTime.Now, });

            // Assert
            Assert.IsNotNull(result);

            Assert.IsTrue(((Microsoft.AspNetCore.Mvc.RedirectToActionResult)result).ActionName == "Index");

            var updatedCustomer = mockRepo.LoadCustomer(2);

            Assert.IsTrue(updatedCustomer.Name == "CC");
        }
    }
}