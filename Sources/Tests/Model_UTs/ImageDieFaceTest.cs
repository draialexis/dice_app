﻿using Model.Dice.Faces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Model_UTs
{
    public class ImageDieFaceTest
    {
        [Fact]
        public void TestCreatImageFace()
        {
            //Arrange
            ImageDieFace face;
            int expected = 11;

            //Act
            face = new ImageDieFace(expected);
            int actuel = (int)face.GetPracticalValue();

            //Assert
            Assert.Equal(expected, actuel);
        }

        [Fact]
        public void TestGetPracticalValueImageFace()
        {
            //Arrange
            ImageDieFace face;
            int expected = 11;

            //Act
            face = new ImageDieFace(expected);
            int actuel = (int)face.GetPracticalValue();

            //Assert
            Assert.Equal(expected, actuel);
        }

        [Fact]
        public void TestImageFaceToString()
        {
            //Arrange
            ImageDieFace face;
            int expected = 11;

            //Act
            face = new ImageDieFace(expected);
            string actuel = face.ToString();

            //Assert
            Assert.Equal(expected.ToString(), actuel);

        }
    }
}