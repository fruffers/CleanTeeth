using System;
using NUnit.Framework;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Tests.Domain.ValueObjects
{
    [TestFixture]
    public class EmailTests
    {
        [Test]
        public void Constructor_NullEmail_ThrowsBusinessRuleException()
        {
            Assert.Throws<BusinessRuleException>(() => new Email(null!));
        }

        [Test]
        public void Constructor_EmailWithoutAtSymbol_ThrowsBusinessRuleException()
        {
            Assert.Throws<BusinessRuleException>(() => new Email("invalidemail.com"));
        }

        [Test]
        public void Constructor_ValidEmail_NoExceptionsThrown()
        {
            Assert.DoesNotThrow(() => new Email("validemail@example.com"));
        }
    }
}
