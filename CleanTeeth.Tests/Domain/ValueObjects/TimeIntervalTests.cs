using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Domain.ValueObjects
{
    [TestFixture]
    internal class TimeIntervalTests
    {
        [Test]
        public void Constructor_StartTimeAfterEndTime_ThrowsBusinessRuleException()
        {
            // Arrange
            DateTime startTime = new System.DateTime(1, 1, 1, 14, 0, 0);
            DateTime endTime = new System.DateTime(1, 1, 1, 13, 0, 0);
            // Act & Assert
            Assert.Throws<BusinessRuleException>(() => new TimeInterval(startTime, endTime));
        }

        [Test]
        public void Constructor_ValidTimeInterval_NoExceptionsThrown()
        {
            // Arrange
            DateTime startTime = new System.DateTime(1, 1, 1, 13, 0, 0);
            DateTime endTime = new System.DateTime(1, 1, 1, 14, 0, 0);
            // Act & Assert
            Assert.DoesNotThrow(() => new TimeInterval(startTime, endTime));
        }
    }
}
