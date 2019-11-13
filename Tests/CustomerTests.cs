using Api.Controllers;
using Api.Entities;
using Api.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly List<Customer> _customers = new List<Customer>
        {
            new Customer {Id = 1, Name = "Petro"},
            new Customer {Id = 2, Name = "Igor"}
        };

        [TestMethod]
        public void GetAllTest()
        {
            var repo = new Mock<IRepository<Customer>>();
            repo.Setup(r => r.GetAllAsync()).ReturnsAsync(_customers);

            var controller = new CustomerController(repo.Object);
            var values =  controller.GetAll().Result.ToList();

            Assert.AreEqual(values.Count,_customers.Count);
            Assert.AreEqual(values[0].Id,1);
            Assert.AreEqual(values[1].Name, "Igor");

        }
        [TestMethod]
        public void GetById()
        {
            var repo = new Mock<IRepository<Customer>>();
            var id = 1;
            repo.Setup(r => r.GetAsync(id)).ReturnsAsync(_customers[id]);

            var controller = new CustomerController(repo.Object);
            var value = (OkNegotiatedContentResult<Customer>)controller.Get(id).Result ;

            Assert.AreEqual(value.Content.Name,_customers[id].Name);
            Assert.AreEqual(value.Content.Id,_customers[id].Id);
        }
    }
}
