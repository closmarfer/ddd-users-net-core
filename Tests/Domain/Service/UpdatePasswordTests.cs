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
    public class UpdatePasswordTests
    {
        [Test]
        public void TestPasswordShouldBeModified()
        {
            var repositoryMock = GetRepositoryMock();

            var hashPasswordMock = new HashPasswordStub();

            var updatePassword = new UpdatePassword(repositoryMock.Object, hashPasswordMock);

            updatePassword.handle(
                new Email("test_modified@test.com"),
                new Password("MyOldPassword"),
                new Password("MyNewPassword")
            );

            Assert.Pass();
        }

        [Test]
        public void TestUserShouldNotBeFound()
        {
            var repositoryMock = new Mock<IUserRepository>();

            repositoryMock.Setup(m => m.GetUser(It.IsAny<UserUuid>())).Returns((User) null);

            var updatePassword = new UpdatePassword(repositoryMock.Object, new HashPasswordStub());

            Assert.Throws<UserNotFoundException>(
                delegate
                {
                    updatePassword.handle(
                        new Email("test_modified@test.com"),
                        new Password("MyOldPassword"),
                        new Password("MyNewPassword")
                    );
                }
            );
        }

        [Test]
        public void TestOldPasswordShouldNotBeValid()
        {
            var repositoryMock = new Mock<IUserRepository>();

            repositoryMock.Setup(m => m.GetByEmail(It.IsAny<Email>())).Returns(
                User.create(
                    new UserUuid("abc123"),
                    new Email("test@test.com"),
                    new HashedPassword("MyOldPasswordHashed--"),
                    new Name("Test"),
                    new Surname("abc123"),
                    new PhoneNumber(123456789),
                    new PostalCode(12345),
                    new CountryCode("es")
                )
            );

            var updatePassword = new UpdatePassword(repositoryMock.Object, new HashPasswordStub());

            Assert.Throws<InvalidPasswordException>(
                delegate
                {
                    updatePassword.handle(
                        new Email("test_modified@test.com"),
                        new Password("MyOldPasswordError"),
                        new Password("MyNewPassword")
                    );
                }
            );
        }

        private static Mock<IUserRepository> GetRepositoryMock()
        {
            var repositoryMock = new Mock<IUserRepository>();

            var user = UserMother.BasicUser();
            user.HashedPassword = new HashedPassword("MyOldPasswordHashed--");
            
            repositoryMock.Setup(m => m.GetByEmail(It.IsAny<Email>())).Returns(user);

            repositoryMock.Setup(m => m.Update(It.IsAny<User>())).Callback(
                ((User user) => { Assert.True(user.IsSamePassword(new HashedPassword("MyNewPasswordHashed--"))); }));
            return repositoryMock;
        }
    }
}