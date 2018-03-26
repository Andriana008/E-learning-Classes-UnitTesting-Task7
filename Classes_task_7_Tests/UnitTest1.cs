using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Classes_task_7;

namespace Classes_task_7_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContext;

        public TestContext TestContext { get => testContext; set => testContext = value; }

        [TestMethod]
        public void GetConjugateTest()
        {
            //arrange
            ComplexNumber complex = new ComplexNumber(1, 1);
            ComplexNumber expected = new ComplexNumber(1, -1);
            //act
            ComplexNumber actual = complex.GetConjugate();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlusOperatorTest()
        {
            //arrange
            ComplexNumber complex1 = new ComplexNumber(1, 1);
            ComplexNumber complex2 = new ComplexNumber(1, 3);
            ComplexNumber expected = new ComplexNumber(2, 4);
            //act
            ComplexNumber actual = complex1 + complex2;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinusOperatorTest()
        {
            //arrange
            ComplexNumber complex1 = new ComplexNumber(1, 1);
            ComplexNumber complex2 = new ComplexNumber(1, 3);
            ComplexNumber expected = new ComplexNumber(0, -2);
            //act
            ComplexNumber actual = complex1 - complex2;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyOperatorTest()
        {
            //arrange
            ComplexNumber complex1 = new ComplexNumber(1, 1);
            ComplexNumber complex2 = new ComplexNumber(1, 3);
            ComplexNumber expected = new ComplexNumber(-2, 4);
            //act
            ComplexNumber actual = complex1 * complex2;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DivisionOperatorTestException()
        {
            //arrange
            ComplexNumber complex1 = new ComplexNumber(2, 1);
            ComplexNumber complex2 = new ComplexNumber(0, 0);
            //act
            ComplexNumber res = new ComplexNumber();
            res = complex1 / complex2;
            //assert
             Assert.AreEqual(res, new ComplexNumber());
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
           "|DataDirectory|\\data.csv",
           "data#csv", DataAccessMethod.Sequential),
           DeploymentItem("data.csv")]
        public void DivisionOperatorTest()
        {
            //Arrange
            double re1 = Double.Parse(TestContext.DataRow["re1"].ToString());
            double im1 = Double.Parse(TestContext.DataRow["im1"].ToString());
            double re2 = Double.Parse(TestContext.DataRow["re2"].ToString());
            double im2 = Double.Parse(TestContext.DataRow["im2"].ToString());
            ComplexNumber c1 = new ComplexNumber(re1, im1);
            ComplexNumber c2 = new ComplexNumber(re2, im2);
            double resultRe = Double.Parse(TestContext.DataRow["resultRe"].ToString());
            double resultIm = Double.Parse(TestContext.DataRow["resultIm"].ToString());
            ComplexNumber expected = new ComplexNumber(resultRe,resultIm);
            //Act
            ComplexNumber actual = c1 / c2;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SumListTest()
        {
            //arrange
            List<ComplexNumber> a = new List<ComplexNumber>();
            a.Add(new ComplexNumber(1, 1));
            a.Add(new ComplexNumber(1, 3));
            List<ComplexNumber> b = new List<ComplexNumber>();
            b.Add(new ComplexNumber(1, 1));
            b.Add(new ComplexNumber(1, 3));
            List<ComplexNumber> expected = new List<ComplexNumber>();
            expected.Add(new ComplexNumber(2, 2));
            expected.Add(new ComplexNumber(2, 6));
            //act
            List<ComplexNumber> actual = Program.Sum(a, b);
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionListTest()
        {
            //arrange
            List<ComplexNumber> a = new List<ComplexNumber>();
            a.Add(new ComplexNumber(1, 1));
            a.Add(new ComplexNumber(3, 1));
            List<ComplexNumber> b = new List<ComplexNumber>();
            b.Add(new ComplexNumber(1, 1));
            b.Add(new ComplexNumber(1, 2));
            List<ComplexNumber> expected = new List<ComplexNumber>();
            expected.Add(new ComplexNumber(0, 0));
            expected.Add(new ComplexNumber(2, -1));
            //act
            List<ComplexNumber> actual = Program.Subtraction(a, b);
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationListTest()
        {
            //arrange
            List<ComplexNumber> a = new List<ComplexNumber>();
            a.Add(new ComplexNumber(1, 1));
            a.Add(new ComplexNumber(1, 3));
            List<ComplexNumber> b = new List<ComplexNumber>();
            b.Add(new ComplexNumber(1, 1));
            b.Add(new ComplexNumber(1, 3));
            ComplexNumber expected = new ComplexNumber(12, 0);
            //act
            ComplexNumber actual = Program.Multiplication(a, b);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
