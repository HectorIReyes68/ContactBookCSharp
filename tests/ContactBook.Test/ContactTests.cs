using Xunit;
using ContactBook;

namespace ContactBook.Tests
{
    public class ContactTests
    {
        // -----------------------------
        // Constructor Tests
        // -----------------------------

        [Fact]
        public void DefaultConstructor_ShouldInitializeEmptyStrings()
        {
            // Arrange & Act
            var contact = new Contact();

            // Assert
            Assert.Equal(string.Empty, contact.GetFName());
            Assert.Equal(string.Empty, contact.GetLName());
            Assert.Equal(string.Empty, contact.GetPhone());
            Assert.Equal(string.Empty, contact.GetEmail());
        }

        [Fact]
        public void Constructor_WithParameters_ShouldInitializePropertiesCorrectly()
        {
            // Arrange & Act
            var contact = new Contact(
                "John",
                "Doe",
                "787-555-1234",
                "john@example.com");

            // Assert
            Assert.Equal("John", contact.GetFName());
            Assert.Equal("Doe", contact.GetLName());
            Assert.Equal("787-555-1234", contact.GetPhone());
            Assert.Equal("john@example.com", contact.GetEmail());
        }

        // -----------------------------
        // Getter and Setter Tests
        // -----------------------------

        [Fact]
        public void SetFName_ShouldUpdateFirstName()
        {
            var contact = new Contact();

            contact.SetFName("Alice");

            Assert.Equal("Alice", contact.GetFName());
        }

        [Fact]
        public void SetLName_ShouldUpdateLastName()
        {
            var contact = new Contact();

            contact.SetLName("Smith");

            Assert.Equal("Smith", contact.GetLName());
        }

        [Fact]
        public void SetPhone_ShouldUpdatePhone()
        {
            var contact = new Contact();

            contact.SetPhone("939-111-2222");

            Assert.Equal("939-111-2222", contact.GetPhone());
        }

        [Fact]
        public void SetEmail_ShouldUpdateEmail()
        {
            var contact = new Contact();

            contact.SetEmail("alice@test.com");

            Assert.Equal("alice@test.com", contact.GetEmail());
        }

        // -----------------------------
        // ToString Tests
        // -----------------------------

        [Fact]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            var contact = new Contact(
                "Jane",
                "Doe",
                "1234567890",
                "jane@test.com");

            // Act
            var result = contact.ToString();

            // Assert
            Assert.Equal(
                "Contact[fname=Jane, lname=Doe, phone=1234567890, email=jane@test.com]",
                result);
        }

        // -----------------------------
        // Equals(Contact) Tests
        // -----------------------------

        [Fact]
        public void Equals_ShouldReturnTrue_WhenSameReference()
        {
            var contact = new Contact("John", "Doe", "111", "john@test.com");

            Assert.True(contact.Equals(contact));
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenOtherIsNull()
        {
            var contact = new Contact("John", "Doe", "111", "john@test.com");

            Assert.False(contact.Equals(null));
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenAllFieldsMatch()
        {
            var c1 = new Contact("John", "Doe", "111", "john@test.com");
            var c2 = new Contact("John", "Doe", "111", "john@test.com");

            Assert.True(c1.Equals(c2));
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenFirstNameDiffers()
        {
            var c1 = new Contact("John", "Doe", "111", "john@test.com");
            var c2 = new Contact("Jane", "Doe", "111", "john@test.com");

            Assert.False(c1.Equals(c2));
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenLastNameDiffers()
        {
            var c1 = new Contact("John", "Doe", "111", "john@test.com");
            var c2 = new Contact("John", "Smith", "111", "john@test.com");

            Assert.False(c1.Equals(c2));
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenPhoneDiffers()
        {
            var c1 = new Contact("John", "Doe", "111", "john@test.com");
            var c2 = new Contact("John", "Doe", "222", "john@test.com");

            Assert.False(c1.Equals(c2));
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenEmailDiffers()
        {
            var c1 = new Contact("John", "Doe", "111", "john@test.com");
            var c2 = new Contact("John", "Doe", "111", "jane@test.com");

            Assert.False(c1.Equals(c2));
        }

        // -----------------------------
        // Equals(object) Tests
        // -----------------------------

        [Fact]
        public void Equals_Object_ShouldReturnFalse_WhenDifferentType()
        {
            var contact = new Contact("John", "Doe", "111", "john@test.com");

            Assert.False(contact.Equals("Not a contact"));
        }

        [Fact]
        public void Equals_Object_ShouldReturnTrue_WhenSameValues()
        {
            object obj = new Contact("John", "Doe", "111", "john@test.com");
            var contact = new Contact("John", "Doe", "111", "john@test.com");

            Assert.True(contact.Equals(obj));
        }

        // -----------------------------
        // Operator == Tests
        // -----------------------------

        [Fact]
        public void EqualityOperator_ShouldReturnTrue_WhenBothNull()
        {
            Contact? c1 = null;
            Contact? c2 = null;

            Assert.True(c1 == c2);
        }

        [Fact]
        public void EqualityOperator_ShouldReturnFalse_WhenOneIsNull()
        {
            Contact? c1 = new Contact("John", "Doe", "111", "john@test.com");
            Contact? c2 = null;

            Assert.False(c1 == c2);
        }

        [Fact]
        public void EqualityOperator_ShouldReturnTrue_WhenObjectsAreEqual()
        {
            var c1 = new Contact("John", "Doe", "111", "john@test.com");
            var c2 = new Contact("John", "Doe", "111", "john@test.com");

            Assert.True(c1 == c2);
        }

        // -----------------------------
        // Operator != Tests
        // -----------------------------

        [Fact]
        public void InequalityOperator_ShouldReturnFalse_WhenObjectsAreEqual()
        {
            var c1 = new Contact("John", "Doe", "111", "john@test.com");
            var c2 = new Contact("John", "Doe", "111", "john@test.com");

            Assert.False(c1 != c2);
        }

        [Fact]
        public void InequalityOperator_ShouldReturnTrue_WhenObjectsAreDifferent()
        {
            var c1 = new Contact("John", "Doe", "111", "john@test.com");
            var c2 = new Contact("Jane", "Doe", "111", "john@test.com");

            Assert.True(c1 != c2);
        }

        // -----------------------------
        // GetHashCode Tests
        // -----------------------------

        [Fact]
        public void GetHashCode_ShouldBeSame_ForEqualObjects()
        {
            var c1 = new Contact("John", "Doe", "111", "john@test.com");
            var c2 = new Contact("John", "Doe", "111", "john@test.com");

            Assert.Equal(c1.GetHashCode(), c2.GetHashCode());
        }

        [Fact]
        public void GetHashCode_ShouldUsuallyDiffer_ForDifferentObjects()
        {
            var c1 = new Contact("John", "Doe", "111", "john@test.com");
            var c2 = new Contact("Jane", "Smith", "999", "jane@test.com");

            Assert.NotEqual(c1.GetHashCode(), c2.GetHashCode());
        }
    }
}