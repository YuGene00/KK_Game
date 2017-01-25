using NUnit.Framework;

public class LifeTest {

	[Test]
	public void AddToCurrentLifeTestTrue() {
		//Arrange
		Life life = new Life(5);

		//Act
		life.CurrentLife -= 3;

		//Assert
		Assert.AreEqual(2, life.CurrentLife);
	}

	[Test]
	public void AddToCurrentLifeTestFalse() {
		//Arrange
		Life life = new Life(5);

		//Act
		life.CurrentLife -= 1;
		life.CurrentLife += 2;

		//Assert
		Assert.AreEqual(5, life.CurrentLife);
	}
}
