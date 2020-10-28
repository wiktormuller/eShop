using eShop.Domain.Entities;
using System;
using Xunit;

namespace eShop.Tests
{
    public class UserTests
    {
        private User _testUser;

        public UserTests()
        {
            _testUser = new User("test@email.com", "John", "Smith", "JohnNickName", "user", "password", "veryComplicatedSalt123");
        }

        [Fact]
        public void SetEmail_ThrowsArgumentNullExceptionGivenEmptyOrNullEmail()
        {
            string empty = "";
            string none = null;

            Assert.Throws<ArgumentNullException>(() => _testUser.SetEmail(empty));
            Assert.Throws<ArgumentNullException>(() => _testUser.SetEmail(none));
        }

        [Fact]
        public void SetUserName_ThrowsArgumentNullExceptionGivenEmptyOrNullEmail()
        {
            string empty = "";
            string none = null;

            Assert.Throws<ArgumentNullException>(() => _testUser.SetUsername(empty));
            Assert.Throws<ArgumentNullException>(() => _testUser.SetUsername(none));
        }

        [Fact]
        public void SetUserName_ThrowsArgumentExceptionGivenUsernameUncompatibleWithRegex()
        {
            string actual = "@ UserName !";

            Assert.Throws<ArgumentException>(() => _testUser.SetUsername(actual));
        }
    }
}
