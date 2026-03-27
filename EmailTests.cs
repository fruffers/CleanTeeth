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
		public void Constructor_NullEmail_Throws()
		{
			Assert.Throws<BusinessRuleException>(() => new Email(null!));
		}
	}
}
