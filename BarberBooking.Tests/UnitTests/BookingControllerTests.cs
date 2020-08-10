using System;
using System.Threading.Tasks;
using BarberBooking.Controllers;
using BarberBooking.Models.ViewModels;
using BarberBooking.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BarberBooking.Tests
{
    public class BookingControllerTests
    {

        [Fact]
        public void Index_ReturnsRedirectToRegisterPage_WhenUserIsNotSignedIn()
        {
            var controller = new BookingController(new Mock<ILogger<BookingController>>().Object, new Mock<MockSignInManager>().Object, null);

            var mockUrlHelper = new Mock<IUrlHelper>(MockBehavior.Strict);

            mockUrlHelper
                .Setup(
                    x => x.Action(It.IsAny<UrlActionContext>())
                )
                .Returns("callbackUrl");

            controller.Url = mockUrlHelper.Object;

            var model = new BookingViewModel();
            model.ResourceId = Guid.NewGuid();
            model.ServicesId.Add(Guid.NewGuid());
            model.Time = DateTime.Now;

            var result = controller.Index(model);

            Assert.True(controller.ModelState.IsValid);

            var viewResult = Assert.IsType<RedirectToPageResult>(result);

            Assert.Equal("/Account/Register", viewResult.PageName);
            Assert.Equal("callbackUrl", viewResult.RouteValues["returnUrl"]);
        }

        [Fact]
        public void Index_ReturnsToCreateBookingPage_WhenUserIsSignedIn()
        {
            var signInManager = new Mock<MockSignInManager>();

            signInManager.Setup(
                s => s.IsSignedIn(null)
            ).Returns(true);

            var controller = new BookingController(new Mock<ILogger<BookingController>>().Object, signInManager.Object, null);

            var model = new BookingViewModel();
            model.ResourceId = Guid.NewGuid();
            model.ServicesId.Add(Guid.NewGuid());
            model.Time = DateTime.Now;

            var result = controller.Index(model);

            Assert.True(controller.ModelState.IsValid);

            var viewResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Create", viewResult.ActionName);
            Assert.Equal(model.ResourceId, viewResult.RouteValues["resourceId"]);
            Assert.Equal(model.ServicesId, viewResult.RouteValues["servicesId"]);
            Assert.Equal(model.Time, viewResult.RouteValues["time"]);

        }
    }
}