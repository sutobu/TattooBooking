//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TattooBookingManager.Data;
//using TattooBookingManager.Models;
//using TattooBookingManager.ViewModels;

//namespace TattooBookingManager.Tests
//{
//    [TestClass]
//    public class EditViewModelTests
//    {
//        [TestMethod]
//        public void CanSave_ValidAppointment_ReturnsTrue()
//        {
//            // Arrange
//            var options = new DbContextOptionsBuilder<TattooBookingContext>()
//                .UseInMemoryDatabase(databaseName: "TestDatabase")
//                .Options;

//            using var context = new TattooBookingContext(options);
//            context.Clients.Add(new Client { ClientId = 1, FirstName = "John", LastName = "Doe" });
//            context.Artists.Add(new Artist { ArtistId = 1, Name = "Jane" });
//            context.TattooStyles.Add(new TattooStyle { StyleId = 1, StyleName = "Traditional" });
//            context.SaveChanges();

//            var viewModel = new EditViewModel
//            {
//                Appointment = new Appointment
//                {
//                    ClientId = 1,
//                    ArtistId = 1,
//                    StyleId = 1,
//                    Duration = 60,
//                    AppointmentDateTime = DateTime.Now.AddDays(1)
//                }
//            };

//            // Act
//            bool canSave = viewModel.SaveCommand.CanExecute(null);

//            // Assert
//            Assert.IsTrue(canSave);
//        }
//    }
//}