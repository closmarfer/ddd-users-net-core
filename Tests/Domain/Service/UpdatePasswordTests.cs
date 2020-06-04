using Moq;
using NUnit.Framework;
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

            var hashPasswordMock = new HashPasswordMock();

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

            var updatePassword = new UpdatePassword(repositoryMock.Object, new HashPasswordMock());

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

            var updatePassword = new UpdatePassword(repositoryMock.Object, new HashPasswordMock());

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

            repositoryMock.Setup(m => m.Update(It.IsAny<User>())).Callback(
                ((User user) => { Assert.True(user.IsSamePassword(new HashedPassword("MyNewPasswordHashed--"))); }));
            return repositoryMock;
        }
    }

    class HashPasswordMock : HashPassword
    {
        public override HashedPassword handle(Password password)
        {
            return new HashedPassword(password.Value + "Hashed--");
        }
    }
}