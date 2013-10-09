using System.Collections.Generic;
using NUnit.Framework;
using _21_game;
using Moq;

// По идее проект и пространство имён с тестами должено называться 21_game.Tests
namespace PointsCalculateTest
{
    // Класс с тестами именуется так: <ClassUnderTest>Tests
	[TestFixture]
    public class PointsTests
	{
        // Названия тестовых методов должно заканчиваться на Test 
		[Test]
		public void AceIsElevenTest()
		{
            /* Resharper подсказывает:
             * 1 - если из правой части объявления переменной очевиден её тип, лучше использовать var
             * 2 - если используется выражение инициализатор, скобки у вызова конструктора необязательны
             * 
             * Алсо:
             * 1 - масть карты не играет никакой роли в алгоритме подсчёта, в тестах это лишние данные
             * 2 - 
             */

			//arrange
			var hand = new List<Card>
			{
				new Card
				{
					Rank = 1
				},
				new Card
				{
					Rank = 13
				}
			};

			var player = Mock.Of<Player>(p => p.Hand == hand);
			var points = new Points();

			//act
			int sumPoints = points.Calculate(player); 

			//assert
			Assert.AreEqual(sumPoints, 21);
		}

		[Test]
        public void AceIsOneTest()
		{
			//arrange
			var hand = new List<Card>
			{
				new Card
				{
					Rank = 10
				},
				new Card
				{
					Rank = 5
				},
				new Card
				{
					Rank = 1
				}
			};

			var player = Mock.Of<Player>(p => p.Hand == hand);
			var points = new Points();

			//act
			int sumPoints = points.Calculate(player);

			//assert
			Assert.AreEqual(sumPoints, 16);
		}	

	}
}
