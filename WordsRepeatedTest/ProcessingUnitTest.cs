using Application;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Xunit.Sdk;

namespace WordsRepeatedTest
{
    [TestClass]
    public class ProcessingUnitTest
    {
        [TestMethod]
        public void FindWordsRepeated_ShouldPrueba3()
        {
            //Arrange
            var text = "prueba, PRUEBA, pruEBa unitaria. Tata Consulting.";
            var wordsRepeatedResult = new Word
            {
                Amount = 3,
                Name = "prueba"
            };
            var expectedResult = new List<Word>();
            expectedResult.Add(wordsRepeatedResult);
            Processing find = new Processing();

            //Act
            var result = find.FindWordsRepeated(text);

            //Assert
            Assert.AreEqual(expectedResult.Count, result.Count);
            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Name, result[i].Name);
                Assert.AreEqual(expectedResult[i].Amount, result[i].Amount);
            }
        }

        [TestMethod]
        public void WithOutWordsRepeated_ShouldCount0()
        {
            //Arrange
            var text = "Pruebas Unitarias. Tata Consulting.";
            var expectedResult = new List<Word>();
            Processing find = new Processing();

            //Act
            var result = find.FindWordsRepeated(text);

            //Assert
            Assert.AreEqual(expectedResult.Count, result.Count);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void WithOutListValidWords_ShouldCount0()
        {
            //Arrange
            var text = ",        . .";
            var expectedResult = new List<Word>();
            Processing find = new Processing();

            //Act
            var result = find.FindWordsRepeated(text);

            //Assert
            Assert.AreEqual(expectedResult.Count, result.Count);
            Assert.IsTrue(result.Count == 0);
        }
    }
}
