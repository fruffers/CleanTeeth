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
    public class DentalOfficeTests
    {
        [Test]
        public void Constructor_NullName_ThrowsBusinessRuleException()
        {
            Assert.Throws<BusinessRuleException>(() => new DentalOffice(null!));
        }
    }
}
