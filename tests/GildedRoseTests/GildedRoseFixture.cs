using FluentAssertions;
using GildedRose;
using System.Collections.Generic;
using GildedRose.Builders;
using Xunit;

namespace GildedRoseTests
{
    public class GildedRoseFixture
    {
        [Fact]
        public void UpdateQuality_AgedBrieWithPositiveSellin_IncreaseQualityDecreasesSellin()
        {
            //Arrange
            var agedBrieItem = new Item() { Name = "Aged Brie", Quality = 1, SellIn = 10 };
            var sut = new GildedRose.GildedRose(new List<Item>() { agedBrieItem }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            agedBrieItem.Quality.Should().Be(2);
            agedBrieItem.SellIn.Should().Be(9);
        }

        [Fact]
        public void UpdateQuality_AgedBrieWithSellinZero_IncreaseQualityBy2DecreasesSellin()
        {
            //Arrange
            var agedBrieItem = new Item() { Name = "Aged Brie", Quality = 1, SellIn = 0 };
            var sut = new GildedRose.GildedRose(new List<Item>() { agedBrieItem }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            agedBrieItem.Quality.Should().Be(3);
            agedBrieItem.SellIn.Should().Be(-1);
        }

        [Fact]
        public void UpdateQuality_AgedBrieWithQuality50AndPositiveSellin_QualityNotIncreasedAndDecreasesSellin()
        {
            //Arrange
            var agedBrieItem = new Item() { Name = "Aged Brie", Quality = 50, SellIn = 1 };
            var sut = new GildedRose.GildedRose(new List<Item>() { agedBrieItem }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            agedBrieItem.Quality.Should().Be(50);
            agedBrieItem.SellIn.Should().Be(0);
        }

        [Fact]
        public void UpdateQuality_AgedBrieWithQuality50AndZeroSellin_QualityNotIncreasedAndDecreasesSellin()
        {
            //Arrange
            var agedBrieItem = new Item() { Name = "Aged Brie", Quality = 50, SellIn = 0 };
            var sut = new GildedRose.GildedRose(new List<Item>() { agedBrieItem }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            agedBrieItem.Quality.Should().Be(50);
            agedBrieItem.SellIn.Should().Be(-1);
        }

        [Fact]
        public void UpdateQuality_DexterityVestWithPositiveSellin_QualityAndSellinDecreased()
        {
            //Arrange
            var vest = new Item() { Name = "+5 Dexterity Vest", Quality = 10, SellIn = 2 };
            var sut = new GildedRose.GildedRose(new List<Item>() { vest }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            vest.Quality.Should().Be(9);
            vest.SellIn.Should().Be(1);
        }

        [Fact]
        public void UpdateQuality_DexterityVestWithZeroSellin_QualityDecreasedByTwoAndSellinDecreased()
        {
            //Arrange
            var vest = new Item() { Name = "+5 Dexterity Vest", Quality = 10, SellIn = 0 };
            var sut = new GildedRose.GildedRose(new List<Item>() { vest }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            vest.Quality.Should().Be(8);
            vest.SellIn.Should().Be(-1);
        }

        [Fact]
        public void UpdateQuality_DexterityVestWithNegativeSellin_QualityDecreasedByTwoAndSellinDecreased()
        {
            //Arrange
            var vest = new Item() { Name = "+5 Dexterity Vest", Quality = 10, SellIn = -1 };
            var sut = new GildedRose.GildedRose(new List<Item>() { vest }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            vest.Quality.Should().Be(8);
            vest.SellIn.Should().Be(-2);
        }

        [Fact]
        public void UpdateQuality_DexterityVestWithQualityZero_QualityNotDecreasedAndSellinDecreased()
        {
            //Arrange
            var vest = new Item() { Name = "+5 Dexterity Vest", Quality = 0, SellIn = 1 };
            var sut = new GildedRose.GildedRose(new List<Item>() { vest }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            vest.Quality.Should().Be(0);
            vest.SellIn.Should().Be(0);
        }

        [Fact]
        public void UpdateQuality_Sulfuras_QualityNotDecreasedAndSellinNotDecreased()
        {
            //Arrange
            var sulfuras = new Item() { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 1 };
            var sut = new GildedRose.GildedRose(new List<Item>() { sulfuras }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            sulfuras.Quality.Should().Be(80);
            sulfuras.SellIn.Should().Be(1);
        }

        [Theory]
        [InlineData(1, 20)]
        [InlineData(1, 11)]
        public void UpdateQuality_BackstagePassSellinGreaterThanTen_QualityIncreasedByOneAndSellinDecreased(int quality, int sellin)
        {
            //Arrange
            var backstagePass = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = quality, SellIn = sellin };
            var sut = new GildedRose.GildedRose(new List<Item>() { backstagePass }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            backstagePass.Quality.Should().Be(quality + 1);
            backstagePass.SellIn.Should().Be(sellin - 1);
        }

        [Theory]
        [InlineData(1, 10)]
        [InlineData(1, 9)]
        [InlineData(1, 6)]
        public void UpdateQuality_BackstagePassSellinLessThanEqual10GreaterThan5_QualityIncreasedBy2AndSellinDecreased(int quality, int sellin)
        {
            //Arrange
            var backstagePass = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = quality, SellIn = sellin };
            var sut = new GildedRose.GildedRose(new List<Item>() { backstagePass }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            backstagePass.Quality.Should().Be(quality + 2);
            backstagePass.SellIn.Should().Be(sellin - 1);
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(1, 4)]
        [InlineData(1, 1)]
        public void UpdateQuality_BackstagePassSellinLessThan5r_QualityIncreasedByTwoAndSellinDecreased(int quality, int sellin)
        {
            //Arrange
            var backstagePass = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = quality, SellIn = sellin };
            var sut = new GildedRose.GildedRose(new List<Item>() { backstagePass }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            backstagePass.Quality.Should().Be(quality + 3);
            backstagePass.SellIn.Should().Be(sellin - 1);
        }

        [Fact]
        public void UpdateQuality_BackstagePassSellinNegative_QualityZeroAndSellinDecreased()
        {
            //Arrange
            var backstagePass = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = -1 };
            var sut = new GildedRose.GildedRose(new List<Item>() { backstagePass }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            backstagePass.Quality.Should().Be(0);
            backstagePass.SellIn.Should().Be(-2);
        }


        [Fact]
        public void UpdateQuality_ConjuredItem_QualityDecreasesBy2()
        {
            //Arrange
            var backstagePass = new Item() { Name = "Conjured Mana Cake", Quality = 10, SellIn = 1 };
            var sut = new GildedRose.GildedRose(new List<Item>() { backstagePass }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            backstagePass.Quality.Should().Be(8);
            backstagePass.SellIn.Should().Be(0);
        }

        [Fact]
        public void UpdateQuality_ConjuredItemWithNegativeSellin_QualityDecreasesBy4()
        {
            //Arrange
            var backstagePass = new Item() { Name = "Conjured Mana Cake", Quality = 10, SellIn = -1 };
            var sut = new GildedRose.GildedRose(new List<Item>() { backstagePass }, new HandlerBuilder());

            //Act
            sut.UpdateQuality();

            //Assert
            backstagePass.Quality.Should().Be(6);
            backstagePass.SellIn.Should().Be(-2);
        }

    }
}
