using System.Collections.Generic;
using NUnit.Framework;
using Moq;

// По идее проект и пространство имён с тестами должено называться 21_game.Tests
namespace _21_game.Tests
{
    // Класс с тестами именуется так: <ClassUnderTest>Tests
	[TestFixture]
    public class MemberTests
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

			//act
			player.Calculate(); 

			//assert
			Assert.AreEqual(player.Points, 21);
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

			//act
			player.Calculate();

			//assert
			Assert.AreEqual(player.Points, 16);
		}

		[Test]
		public void StartCashTest()
		{
			//act
			var player = new Player();

			//assert
			Assert.AreEqual(player.Cash, 500);
		}

		[Test]
		public void StartPointsTest()
		{
			//act
			var player = new Player();

			//assert
			Assert.AreEqual(player.Points, 0);
		}

		[Test]
		public void MakeBetTest()
		{
			//arrange
			var player = new Player();

			//act
			player.MakeBet(30.0);

			//assert
			Assert.AreEqual(player.Bet, 30.0);
		}

		[Test]
		public void CashChangeAfterBetTest()
		{
			//arrange
			var player = new Player();

			//act
			player.MakeBet(30.0);

			//assert
			Assert.AreEqual(player.Cash, 470.0);
		}

	}
}
