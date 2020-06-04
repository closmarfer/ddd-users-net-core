using Moq;
using NUnit.Framework;
using Tests.Mother;
using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.Exception;
using Users.Domain.Service;
using Users.Domain.ValueObject;

namespace Tests.Domain.Service
{
    public class UpdateUserTest
    {
        [Test]
        public void TestUserShouldBeModified()
        {
            var repositoryMock = GetRepositoryMock();

            var updateUser = new UpdateUser(repositoryMock.Object);

            updateUser.Handle(
                new UserUuid("abc123"),
                new Email("test_modified@test.com"),
                new Name("TestModified"),
                new Surname("Test Surname Modified"),
                new PhoneNumber(987234322),
                new PostalCode(12346),
                new CountryCode("fr")
            );

            Assert.Pass();
        }

        [Test]
        public void TestUserShouldNotBeFound()
        {
            var repositoryMock = new Mock<IUserRepository>();

            repositoryMock.Setup(m => m.GetUser(It.IsAny<UserUuid>())).Returns((User) null);

            var updateUser = new UpdateUser(repositoryMock.Object);

            Assert.Throws<UserNotFoundException>(
                delegate
                {
                    updateUser.Handle(
                        new UserUuid("abc123"),
                        new Email("test_modified@test.com"),
                        new Name("TestModified"),
                        new Surname("Test Surname Modified"),
                        new PhoneNumber(987234322),
                        new PostalCode(12346),
                        new CountryCode("fr")
                    );
                }
            );
        }

        private static Mock<IUserRepository> GetRepositoryMock()
        {
            var repositoryMock = new Mock<IUserRepository>();

            repositoryMock.Setup(m => m.GetUser(It.IsAny<UserUuid>())).Returns(
                UserMother.BasicUser()
            );

            repositoryMock.Setup(m => m.Update(It.IsAny<User>())).Callback(
                ((User user) =>
                {
                    Assert.IsNotEmpty(user.UserUuid.Value);
                    Assert.AreEqual("test_modified@test.com", user.Email.Value);
                    Assert.AreEqual("TestModified", user.Name.Value);
                    Assert.AreEqual("Test Surname Modified", user.Surname.Value);
                    Assert.AreEqual(987234322, user.PhoneNumber.Value);
                    Assert.AreEqual(12346, user.PostalCode.Value);
                    Assert.AreEqual("fr", user.CountryCode.Value);
                    Assert.False(user.IsSamePassword(new HashedPassword("testpass")));
                }));
            return repositoryMock;
        }
    }
}