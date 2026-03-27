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
    public class PatientTests
    {
        [Test]
        public void Constructor_NullName_ThrowsBusinessRuleException()
        {
            Assert.Throws<BusinessRuleException>(() => new Patient(null!, new CleanTeeth.Domain.ValueObjects.Email("validemail@gmail.com")));
        }

        [Test]
        public void Constructor_NullEmail_ThrowsBusinessRuleException()
        {
            Assert.Throws<BusinessRuleException>(() => new Patient("John Doe", null!));
        }

        [Test]
        public void Constructor_ValidParameters_CreatesPatient()
        {
            // Arrange
            string name = "John Doe";
            CleanTeeth.Domain.ValueObjects.Email email = new CleanTeeth.Domain.ValueObjects.Email("validemail@gmail.com");
            // Act and assert
            Assert.DoesNotThrow(() => new Patient(name, email));
        }
    }
}