using NUnit.Framework;
using Core.Discounts;
using Core;

namespace ShopModel
{

    public class Tests
    {

        [Test]
        public void TestClassShoppingCartCalculateTotalDiscount_1()
        {
            Product[] products =
            {
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            Discount_1 discount1 = new Discount_1();

            ValueCalculator calculator = new ValueCalculator();

            ShoppingCart cart1 = new ShoppingCart(discount1, calculator) { Products = products };

            var actualResult = cart1.CalculateTotal();
            var expectedResult = 59.4;

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void TestClassShoppingCartCalculateTotalDiscount_5()
        {
            Product[] products =
            {
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            Discount_5 discount5 = new Discount_5();

            ValueCalculator calculator = new ValueCalculator();

            ShoppingCart cart2 = new ShoppingCart(discount5, calculator) { Products = products };

            var actualResult = cart2.CalculateTotal();
            var expectedResult = 57;

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void TestClassProductEquals()
        {
            Product[] products =
            {
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 1, Name = "Pringles", Price = 40}
            };

            var actualResult = products[0].ProductID.Equals(products[1].ProductID);

            Assert.IsTrue(actualResult);
        }


        [Test]
        public void TestClassProductToString()
        {
            string expectedResult;

            Product[] products =
            {
                new Product {ProductID = 1, Name = "Lays", Price = 20},
            };

            var actualResult = products[0].ToString();
            expectedResult = "Product ID: 1, Name: Lays, Price: 20";

            Assert.AreEqual(actualResult, expectedResult);
        }


        [Test]
        public void TestClassValueCalculator()
        {
            Product[] products =
            {
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            ValueCalculator calculator = new ValueCalculator();

            var actualResult = calculator.ValueCalc(products);
            var expectedResult = 60;

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void TestClassDiscount_1()
        {
            Discount_1 discount1 = new Discount_1();

            var actualResult = discount1.PercentageValue(20);
            var expectedResult = 19.8;

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void TestClassDiscount_5()
        {
            Discount_5 discount5 = new Discount_5();

            decimal actualResult = discount5.PercentageValue(40);
            decimal expectedResult = 38;

            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}