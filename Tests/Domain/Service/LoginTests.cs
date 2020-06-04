using Moq;
using NUnit.Framework;
using Tests.Domain.Stub;
using Tests.Mother;
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

            var user = UserMother.BasicUser();
            user.HashedPassword = new HashedPassword("MyPasswordHashed--");
            
            repositoryMock.Setup(m => m.GetByEmail(It.IsAny<Email>())).Returns(user);

            return repositoryMock;
        }
    }
}