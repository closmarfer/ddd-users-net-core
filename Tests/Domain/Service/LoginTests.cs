using Moq;
using NUnit.Framework;
using Tests.Domain.Stub;
using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.Exception;
using Users.Domain.Service;
using Users.Domain.ValueObject;

namespace Tests.Domain.Service
{
    [TestFixture]
    public class LoginTests
    {
        [Test]
        public void TestPasswordShouldBeValid()
        {
            var repositoryMock = GetRepositoryMock();

            var hashPasswordMock = new HashPasswordStub();

            var login = new Login(repositoryMock.Object, hashPasswordMock);

            login.Handle(
                new Email("test@test.com"),
                new Password("MyPassword")
            );

            Assert.Pass();
        }

        [Test]
        public void TestPasswordShouldNotBeValidOfUserNotFound()
        {
            var repositoryMock = new Mock<IUserRepository>();

            repositoryMock.Setup(m => m.GetUser(It.IsAny<UserUuid>())).Returns((User) null);

            var login = new Login(repositoryMock.Object, new HashPasswordStub());

            Assert.Throws<InvalidPasswordException>(
                delegate
                {
                    login.Handle(
                        new Email("test@test.com"),
                        new Password("MyPassword")
                    );
                }
            );
        }

        [Test]
        public void TestPasswordShouldNotBeValidOfInvalidPassword()
        {
            var repositoryMock = GetRepositoryMock();

            var login = new Login(repositoryMock.Object, new HashPasswordStub());

            Assert.Throws<InvalidPasswordException>(
                delegate
                {
                    login.Handle(
                        new Email("test@test.com"),
                        new Password("InvalidPassword")
                    );
                }
            );
        }

        private static Mock<IUserRepository> GetRepositoryMock()
        {
            var repositoryMock = new Mock<IUserRepository>();

            repositoryMock.Setup(m => m.GetByEmail(It.IsAny<Email>())).Returns(
                User.create(
                    new UserUuid("abc123"),
                    new Email("test@test.com"),
                    new HashedPassword("MyPasswordHashed--"),
                    new Name("Test"),
                    new Surname("abc123"),
                    new PhoneNumber(123456789),
                    new PostalCode(12345),
                    new CountryCode("es")
                )
            );
            
            return repositoryMock;
        }
    }
}