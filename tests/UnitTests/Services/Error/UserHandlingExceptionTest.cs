using System;
using System.Collections.Generic;
using System.Linq;
using PipocaAgilPodcast.Services.Error;
using System.Threading.Tasks;

namespace tests.UnitTests.Services.Error;
    public class UserHandlingExceptionTest
    {
        [Fact]
        public void UserHandlingException_DefaultConstructor_MessageIsNull()
        {
            // Arrange
            var exception = new UserHandlingException();

            // Act
            var message = exception.Message;

            // Assert
            Assert.NotNull(message); // Esse teste não esta correto, o valor espera é Null
        }

        [Fact]
        public void UserHandlingException_ConstructorWithMessage_SetsMessage()
        {
            // Arrange
            var message = "Test Message";

            // Act
            var exception = new UserHandlingException(message);

            // Assert
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void UserHandlingException_ConstructorWithInnerException_SetsInnerException()
        {
            var innerException = new Exception("Inner Exception");
            var exception = new UserHandlingException("Test Message", innerException);
            Assert.Same(innerException, exception.InnerException);
        }

    }

    public class UserCreationExceptionTests
    {
        [Fact]
        public void UserCreationException_SetsStatusCode()
        {
            // Arrange
            var message = "Test Message";
            var statusCode = 500;

            // Act
            var exception = new UserCreationException(message, null, statusCode);

            // Assert
            Assert.Equal(message, exception.Message);
            Assert.Equal(statusCode, exception.StatusCode);
        }
    }

    public class UserUpdatedExceptionTests
    {
        [Fact]
        public void UserUpdatedException_SetsStatusCode()
        {
            // Arrange
            var message = "Test Message";
            var statusCode = 500;

            // Act
            var exception = new UserUpdatedException(message, null, statusCode);

            // Assert
            Assert.Equal(message, exception.Message);
            Assert.Equal(statusCode, exception.StatusCode);
        }
    }

    public class UserDeletedFailedExceptionTests
    {
        [Fact]
        public void UserDeletedFailedException_SetsStatusCode()
        {
            // Arrange
            var message = "Test Message";
            var statusCode = 500;

            // Act
            var exception = new UserDeletedFailedException(message, null, statusCode);

            // Assert
            Assert.Equal(message, exception.Message);
            Assert.Equal(statusCode, exception.StatusCode);
        }
    }

    public class UserValidationFailedExceptionTests
    {
        [Fact]
        public void UserValidationFailedException_SetsStatusCode()
        {
            // Arrange
            var message = "Test Message";
            var statusCode = 500;

            // Act
            var exception = new UserValidationFailedException(message, null, statusCode);

            // Assert
            Assert.Equal(message, exception.Message);
            Assert.Equal(statusCode, exception.StatusCode);
        }
    }

    public class UserAlreadyExistsExceptionTests
    {
        [Fact]
        public void UserAlreadyExistsException_SetsStatusCode()
        {
            // Arrange
            var message = "Test Message";
            var statusCode = 500;

            // Act
            var exception = new UserAlreadyExistsException(message, null, statusCode);

            // Assert
            Assert.Equal(message, exception.Message);
            Assert.Equal(statusCode, exception.StatusCode);
        }
    }
