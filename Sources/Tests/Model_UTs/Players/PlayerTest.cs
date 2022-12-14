using Model.Players;
using System;
using Xunit;

namespace Tests.Model_UTs.Players
{
    public class PlayerTest
    {
        [Fact]
        public void TestConstructorIfNameThenCorrectName()
        {
            // Arrange
            Player player;
            string expected = "Alice";

            // Act
            player = new(expected);
            string actual = player.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestConstructorIfNameUntrimmedThenTrimmedName()
        {
            // Arrange
            Player player;
            string expected = "Alice";

            // Act
            player = new(" Alice ");
            string actual = player.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void TestConstructorIfWhitespaceOrBlankThenException(string name)
        {
            // Arrange
            Player player;

            // Act
            void action() => player = new(name);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void TestConstructorIfNullThenException()
        {
            // Arrange
            Player player;
            string name = null;

            // Act
            void action() => player = new Player(name);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void TestEqualsFalseIfNotPlayer()
        {
            // Arrange
            Point point;
            Player player;

            // Act
            point = new(1, 2);
            player = new("Clyde");

            // Assert
            Assert.False(point.Equals(player));
            Assert.False(player.Equals(point));
        }

        [Fact]
        public void TestGoesThruToSecondMethodIfObjIsTypePlayer()
        {
            // Arrange
            object p1;
            Player p2;

            // Act
            p1 = new Player("Marvin");
            p2 = new("Clyde");

            // Assert
            Assert.False(p1.Equals(p2));
            Assert.False(p2.Equals(p1));
        }


        [Fact]
        public void TestEqualsFalseIfNotSameName()
        {
            // Arrange
            Player p1;
            Player p2;

            // Act
            p1 = new("Panama");
            p2 = new("Clyde");

            // Assert
            Assert.False(p1.Equals(p2));
            Assert.False(p2.Equals(p1));
        }

        [Fact]
        public void TestEqualsFalseIfNull()
        {
            // Arrange
            Player player;

            // Act
            player = new("Panama");

            // Assert
            Assert.False(player.Equals(null));
        }

        [Theory]
        [InlineData("devoN")]
        [InlineData(" devon")]
        [InlineData("deVon ")]
        public void TestEqualsTrueIfSameNameDifferentCaseOrSpace(string name)
        {
            // Arrange
            Player p1;
            Player p2;

            // Act
            p1 = new("Devon");
            p2 = new(name);

            // Assert
            Assert.True(p1.Equals(p2));
            Assert.True(p2.Equals(p1));
        }

        [Fact]
        public void TestEqualsTrueIfExactlySameName()
        {
            // Arrange
            Player p1;
            Player p2;
            string name = "Elyse";

            // Act
            p1 = new(name);
            p2 = new(name);

            // Assert
            Assert.True(p1.Equals(p2));
            Assert.True(p2.Equals(p1));
        }

        [Fact]
        public void TestSameHashFalseIfNotSameName()
        {
            // Arrange
            Player p1;
            Player p2;

            // Act
            p1 = new("Panama");
            p2 = new("Clyde");

            // Assert
            Assert.False(p1.GetHashCode().Equals(p2.GetHashCode()));
            Assert.False(p2.GetHashCode().Equals(p1.GetHashCode()));
        }

        [Theory]
        [InlineData("devoN", "devon")]
        [InlineData(" devon", "devon")]
        [InlineData("DevoN ", "devon")]
        [InlineData(" dEvoN ", "devon")]
        public void TestSameHashTrueIfSameNameDifferentCase(string name1, string name2)
        {
            // Arrange
            Player p1;
            Player p2;

            // Act
            p1 = new(name1);
            p2 = new(name2);

            // Assert
            Assert.True(p1.GetHashCode().Equals(p2.GetHashCode()));
            Assert.True(p2.GetHashCode().Equals(p1.GetHashCode()));
        }

        [Fact]
        public void TestSameHashTrueIfExactlySameName()
        {
            // Arrange
            Player p1;
            Player p2;
            string name = "Elyse";

            // Act
            p1 = new(name);
            p2 = new(name);

            // Assert
            Assert.True(p1.GetHashCode().Equals(p2.GetHashCode()));
            Assert.True(p2.GetHashCode().Equals(p1.GetHashCode()));
        }

        [Fact]
        public void TestCopyConstructorExactCopy()
        {
            // Arrange
            Player p1;
            Player p2;

            // Act
            p1 = new(" Elyse ");
            p2 = new(p1);

            // Assert
            Assert.True(p1.Equals(p2));
        }

        [Fact]
        public void TestCopyConstructorIfNullThenException()
        {
            // Arrange
            Player p1;
            Player p2 = null;

            // Act
            void action() => p1 = new Player(p2);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
