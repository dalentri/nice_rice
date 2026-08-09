using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using rice_ecommerce.Application.Common.Behaviours;
using rice_ecommerce.Application.Common.Interfaces;
using rice_ecommerce.Application.RiceItems.Commands.CreateRiceItem;

namespace rice_ecommerce.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<CreateRiceItemCommand>> _logger = null!;
    private Mock<IUser> _user = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreateRiceItemCommand>>();
        _user = new Mock<IUser>();
        _identityService = new Mock<IIdentityService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _user.Setup(x => x.Id).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreateRiceItemCommand>(
            _logger.Object,
            _user.Object,
            _identityService.Object
        );

        await requestLogger.Process(
            new CreateRiceItemCommand { Title = "title" },
            new CancellationToken()
        );

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateRiceItemCommand>(
            _logger.Object,
            _user.Object,
            _identityService.Object
        );

        await requestLogger.Process(
            new CreateRiceItemCommand { Title = "title" },
            new CancellationToken()
        );

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
    }
}
