﻿using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace Tests.Model_UTs
{
    public class PlayerManagerTest
    {
        [Fact]
        public void TestConstructorReturnsEmptyEnumerable()
        {
            // Arrange
            PlayerManager playerManager = new();
            IEnumerable<Player> expected;
            IEnumerable<Player> actual;

            // Act
            expected = new Collection<Player>();
            actual = playerManager.GetAll();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAddIfPlayersThenDoAddAndReturnPlayers()
        {
            // Arrange
            PlayerManager playerManager = new();
            Player alice = new("Alice");
            Player bob = new("Bob");

            // Act
            Collection<Player> expected = new() { alice, bob };
            Collection<Player> actual = new()
            {
                playerManager.Add(alice),
                playerManager.Add(bob)
            };

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAddIfNullThenDontAddAndReturnNull()
        {
            // Arrange
            PlayerManager playerManager = new();
            Player expected;
            Player actual;

            // Act
            expected = null;
            actual = playerManager.Add(expected);// Add() returns the added element if succesful

            // Assert
            Assert.Equal(expected, actual);
            Assert.DoesNotContain(expected, playerManager.GetAll());
        }

        [Fact]
        public void TestGetOneByIdThrowsNotImplemented()
        {
            // Arrange
            PlayerManager playerManager = new();

            // Act
            void action() => playerManager.GetOneById(1);

            // Assert
            Assert.Throws<NotImplementedException>(action);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void TestGetOneByNameIfInvalidThenReturnNull(string name)
        {
            // Arrange
            PlayerManager playerManager = new();
            Player player = new("Bob");
            playerManager.Add(player);

            // Act
            Player result = playerManager.GetOneByName(name);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void TestGetOneByNameIfValidButNotExistThenReturnNull()
        {
            // Arrange
            PlayerManager playerManager = new();
            Player player = new("Bob");
            playerManager.Add(player);

            // Act
            Player result = playerManager.GetOneByName("Clyde");

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Bob")]
        [InlineData("bob")]
        [InlineData("bob ")]
        [InlineData(" boB ")]
        public void TestGetOneByNameIfValidThenReturnPlayer(string name)
        {
            // Arrange
            PlayerManager playerManager = new();
            Player expected = new("Bob");
            playerManager.Add(expected);

            // Act
            Player actual = playerManager.GetOneByName(name);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRemoveWorksIfExists()
        {
            // Arrange
            PlayerManager playerManager = new();
            Player p1 = new("Dylan");
            playerManager.Add(p1);

            // Act
            playerManager.Remove(p1);

            // Assert
            Assert.DoesNotContain(p1, playerManager.GetAll());
        }

        [Fact]
        public void TestRemoveFailsSilentlyIfGivenNull()
        {
            // Arrange
            PlayerManager playerManager = new();
            Player player = new("Dylan");
            playerManager.Add(player);
            Player notPlayer = null;
            IEnumerable<Player> expected = new Collection<Player> { player };

            // Act
            playerManager.Remove(notPlayer);
            IEnumerable<Player> actual = playerManager.GetAll();

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void TestRemoveFailsSilentlyIfGivenNonExistent()
        {
            // Arrange
            PlayerManager playerManager = new();
            Player player = new("Dylan");
            playerManager.Add(player);
            Player notPlayer = new("Eric");
            IEnumerable<Player> expected = new Collection<Player> { player };

            // Act
            playerManager.Remove(notPlayer);
            IEnumerable<Player> actual = playerManager.GetAll();

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void TestUpdateWorksIfValid()
        {
            // Arrange
            PlayerManager playerManager = new();
            Player oldPlayer = new("Dylan");
            playerManager.Add(oldPlayer);
            Player newPlayer = new("Eric");

            // Act
            playerManager.Update(oldPlayer, newPlayer);

            // Assert
            Assert.DoesNotContain(oldPlayer, playerManager.GetAll());
            Assert.Contains(newPlayer, playerManager.GetAll());
            Assert.True(playerManager.GetAll().Count() == 1);
        }

        [Theory]
        [InlineData("Filibert", "filibert")]
        [InlineData("Filibert", " fiLibert")]
        [InlineData("Filibert", "FIlibert ")]
        [InlineData(" Filibert", " filiBErt ")]
        public void TestUpdateDiscreetlyUpdatesCaseAndIgnoresExtraSpaceIfOtherwiseSame(string n1, string n2)
        {
            // Arrange
            PlayerManager playerManager = new();
            Player oldPlayer = new(n1);
            playerManager.Add(oldPlayer);
            Player newPlayer = new(n2);

            // Act
            playerManager.Update(oldPlayer, newPlayer);

            // Assert
            Assert.Contains(oldPlayer, playerManager.GetAll());
            Assert.Contains(newPlayer, playerManager.GetAll());
            Assert.Equal(n2.Trim(), playerManager.GetAll().First().Name);
            // uses Equals(), which is made to be case-insensitive
        }
    }
}
