using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Domain.Entities
{
    [TestFixture]
    public class DentistTests
    {
        [Test]
        public void Constructor_NullName_ThrowsBusinessRuleException()
        {
            Assert.Throws<BusinessRuleException>(() => new Dentist(null!, new CleanTeeth.Domain.ValueObjects.Email("test@example.com")));
        }

        [Test]
        public void Constructor_NullEmail_ThrowsBusinessRuleException()
        {
            Assert.Throws<BusinessRuleException>(() => new Dentist("Dr. Smith", null!));
        }

        [Test]
        public void Constructor_ValidParameters_CreatesDentist()
        {
            // Arrange
            string name = "Dr. Smith";
            CleanTeeth.Domain.ValueObjects.Email email = new CleanTeeth.Domain.ValueObjects.Email("validemail@gmail.com");
            // Act and assert
            Assert.DoesNotThrow(() => new Dentist(name, email));
        }
    }
}
