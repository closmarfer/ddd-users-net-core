using NUnit.Framework;
using Moq;
using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.Service;
using Users.Domain.ValueObject;

namespace Tests.Domain.Service
{
    public class CreateUserTests
    {
        [Test]
        public void TestValidUserShouldBePassedToRepository()
        {
            var repositoryMock = new Mock<IUserRepository>();

            repositoryMock.Setup(m => m.Create(It.IsAny<User>())).Callback(
                ((User user) =>
                {
                    Assert.IsNotEmpty(user.UserUuid.Value);
                    Assert.AreEqual("test@test.com", user.Email.Value);
                    Assert.AreEqual("Test", user.Name.Value);
                    Assert.AreEqual("Test Surname", user.Surname.Value);
                    Assert.AreEqual(987234321, user.PhoneNumber.Value);
                    Assert.AreEqual(12345, user.PostalCode.Value);
                    Assert.AreEqual("es", user.CountryCode.Value);
                    Assert.False(user.IsSamePassword(new HashedPassword("testpass")));
                    
                }));
            
            var createUser = new CreateUser(repositoryMock.Object);

            createUser.handle(
                new Email("test@test.com"),
                new Password("abc123"),
                new Name("Test"), 
                new Surname("Test Surname"),
                new PhoneNumber(987234321),
                new PostalCode(12345),
                new CountryCode("es")
                );
            
            Assert.Pass();
        }
    }
}