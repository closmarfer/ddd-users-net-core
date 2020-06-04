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
    public class DeleteUserTests
    {
        [Test]
        public void TestUserShouldBeDeleted()
        {
            var repositoryMock = GetRepositoryMock();

            var deleteUser = new DeleteUser(repositoryMock.Object);

            deleteUser.Handle(
                new UserUuid("abc123")
            );

            Assert.Pass();
        }

        [Test]
        public void TestUserShouldNotBeFound()
        {
            var repositoryMock = new Mock<IUserRepository>();

            repositoryMock.Setup(m => m.GetUser(It.IsAny<UserUuid>())).Returns((User) null);

            var deleteUser = new DeleteUser(repositoryMock.Object);

            Assert.Throws<UserNotFoundException>(
                delegate
                {
                    deleteUser.Handle(
                        new UserUuid("abcd123")
                    );
                }
            );
        }

        private static Mock<IUserRepository> GetRepositoryMock()
        {
            var repositoryMock = new Mock<IUserRepository>();

            repositoryMock.Setup(m => m.GetUser(It.IsAny<UserUuid>())).Returns(UserMother.BasicUser());

            repositoryMock.Setup(m => m.Delete(It.IsAny<User>()));
            return repositoryMock;
        }
    }
}