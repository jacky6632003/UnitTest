using FluentAssertions;
using Level01.Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level01.SampleTests
{
    [TestClass()]
    public class CalculatorTests_FluentAssertions
    {
        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("Calculator")]
        [TestProperty("Calculator", "Add")]
        public void Add_first輸入1_second輸入2_結果應為3()
        {
            // arrange
            var sut = new Calculator(); // sut, system under test

            var first = 1;
            var second = 2;
            var expected = 3;

            // act
            var actual = sut.Add(first, second);

            // assert
            actual.Should().Be(expected);
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("Calculator")]
        [TestProperty("Calculator", "Mix")]
        public void Mix_first輸入1_second輸入2_third輸入3_結果應為1()
        {
            // arrange
            var sut = new Calculator(); // sut, system under test

            var first = 1;
            var second = 2;
            var third = 3;
            var expected = 1;

            // act
            var actual = sut.Mix(first, second, third);

            // assert
            actual.Should().Be(expected);
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("Calculator")]
        [TestProperty("Calculator", "Mix")]
        public void MixTest_first輸入1_second輸入2_third輸入0_應拋出ArgumentException()
        {
            // arrange
            var sut = new Calculator();

            var first = 1;
            var second = 2;
            var third = 0;
            var expected = 1;

            // act
            Action action = () => sut.Mix(first, second, third);

            // assert
            action.Should().Throw<ArgumentException>();
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("Calculator")]
        [TestProperty("Calculator", "Mix")]
        public void MixTest_first輸入1_second輸入2_third輸入0_驗證ArgumentException訊息()
        {
            // arrange
            var sut = new Calculator();

            var first = 1;
            var second = 2;
            var third = 0;
            var expectedMessage = "third 不可為零";

            // act
            Action action = () => sut.Mix(first, second, third);

            // assert
            action.Should().Throw<ArgumentException>()
                  .WithMessage(expectedMessage);
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("Calculator")]
        [TestProperty("Calculator", "Mix")]
        public void Mix_first輸入0_second輸入0_third輸入0_應拋出ArgumentException()
        {
            // arrange
            var sut = new Calculator();

            var first = 0;
            var second = 0;
            var third = 0;
            var expected = 1;

            // act
            Action action = () => sut.Mix(first, second, third);

            // assert
            action.Should().Throw<ArgumentException>();
        }

        [TestMethod()]
        [Owner("User_Name")]
        [TestCategory("Calculator")]
        [TestProperty("Calculator", "Mix")]
        public void Mix_first輸入0_second輸入0_third輸入0_驗證ArgumentException訊息()
        {
            // arrange
            var sut = new Calculator();

            var first = 0;
            var second = 0;
            var third = 0;
            var expectedMessage = "first + second 總和不可為零";

            // act
            Action action = () => sut.Mix(first, second, third);

            // assert
            action.Should().Throw<ArgumentException>()
                  .WithMessage(expectedMessage);
        }
    }
}