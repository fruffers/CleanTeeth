using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Domain.Entities
{
    [TestFixture]
    public class AppointmentTests
    {
        private readonly Guid _patientId = Guid.NewGuid();
        private readonly Guid _dentistId = Guid.NewGuid();
        private readonly Guid _dentalOfficeId = Guid.NewGuid();
        private readonly TimeInterval _interval = new TimeInterval(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

        [Test]
        public void Constructor_ValidAppointment_StatusIsScheduled()
        {
            // Act
            var appointment = new CleanTeeth.Domain.Entities.Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(appointment.PatientId, Is.EqualTo(_patientId));
                Assert.That(appointment.DentistId, Is.EqualTo(_dentistId));
                Assert.That(appointment.DentalOfficeId, Is.EqualTo(_dentalOfficeId));
                Assert.That(appointment.TimeInterval, Is.EqualTo(_interval));
                Assert.That(appointment.Status, Is.EqualTo(AppointmentStatus.Scheduled));
                Assert.That(appointment.Id, Is.Not.EqualTo(Guid.Empty));
            });
        }

        [Test]
        public void Constructor_StartTimeInThePast_ThrowsBusinessRuleException()
        {
            // Arrange
            TimeInterval pastInterval = new TimeInterval(DateTime.UtcNow.AddDays(-2), DateTime.UtcNow.AddDays(-1));
            // Act & Assert
            Assert.Throws<CleanTeeth.Domain.Exceptions.BusinessRuleException>(() =>
                new CleanTeeth.Domain.Entities.Appointment(_patientId, _dentistId, _dentalOfficeId, pastInterval));
        }

        [Test]
        public void Cancel_CancellingAppointment_ChangesStatusToCancelled()
        {
            // Arrange
            Appointment appointment = new CleanTeeth.Domain.Entities.Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            // Act
            appointment.Cancel();
            // Assert
            Assert.That(appointment.Status, Is.EqualTo(AppointmentStatus.Cancelled));
        }

        [Test]
        public void Cancel_CancellingAppointment_ThrowsBusinessRuleExceptionIfStatusIsNotScheduled()
        {
            // Arrange
            Appointment appointment = new CleanTeeth.Domain.Entities.Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            // Act
            /// First cancel to change status to Cancelled
            appointment.Cancel();
            // Assert & Act
            /// No appointment is scheduled so it should throw an exception if we try to cancel again
            Assert.Throws<CleanTeeth.Domain.Exceptions.BusinessRuleException>(() => appointment.Cancel());
        }

        [Test]
        public void Complete_CompletingAppointment_ChangesStatusToCompleted()
        {
            // Arrange
            Appointment appointment = new CleanTeeth.Domain.Entities.Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            // Act
            appointment.Complete();
            // Assert
            Assert.That(appointment.Status, Is.EqualTo(AppointmentStatus.Completed));
        }

        [Test]
        public void Complete_CompletingAppointment_ThrowsBusinessRuleExceptionIfStatusIsNotScheduled()
        {
            // Arrange
            Appointment appointment = new CleanTeeth.Domain.Entities.Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            // Act
            /// First cancel to change status to Cancelled
            appointment.Cancel();
            // Assert & Act
            /// No appointment is scheduled so it should throw an exception if we try to complete again
            Assert.Throws<CleanTeeth.Domain.Exceptions.BusinessRuleException>(() => appointment.Complete());
        }
    }
}
