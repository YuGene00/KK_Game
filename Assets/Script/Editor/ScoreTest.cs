using NUnit.Framework;

public class ScoreTest {

	[TearDown]
	public void DeleteHighScore() {
		Score score = new Score();
		score.DeleteHighScore();
	}

	[Test]
	public void UpdateHighScoreTestTrue() {
		//Arrange
		Score score = new Score();

		//Act
		score.HighScore = 100;
		score.CurrentScore += 200;
		score.UpdateHighScore();

		//Assert
		Assert.AreEqual(200, score.HighScore);
	}

	[Test]
	public void UpdateHighScoreTestFalse() {
		//Arrange
		Score score = new Score();

		//Act
		score.HighScore = 200;
		score.CurrentScore += 100;
		score.UpdateHighScore();

		//Assert
		Assert.AreEqual(200, score.HighScore);
	}
}
