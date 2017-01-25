using UnityEngine;
using NUnit.Framework;

public class MoveTest {

	[Test]
	public void MoveToInAreaTestInArea() {
		//Arrange
		Transform trans = new GameObject().transform;
		trans.position = new Vector2(1f, 1f);
		Area area = new Area(new Vector2(1f, 1f), new Vector2(3f, 3f));
		Move move = new Move(trans, area);

		//Act
		Vector2 dest = new Vector2(2f, 2f);
		move.MoveToDestInArea(dest);

		//Assert
		Assert.AreEqual(dest, (Vector2)trans.position);
	}

	[Test]
	public void MoveToInAreaTestOutOfArea() {
		//Arrange
		Transform trans = new GameObject().transform;
		trans.position = new Vector2(1f, 1f);
		Area area = new Area(new Vector2(1f, 1f), new Vector2(3f, 3f));
		Move move = new Move(trans, area);

		//Act
		Vector2 dest = new Vector2(4f, 4f);
		move.MoveToDestInArea(dest);

		//Assert
		Assert.AreEqual(new Vector2(3f, 3f), (Vector2)trans.position);
	}

	[Test]
	public void MoveToTestOutOfArea() {
		//Arrange
		Transform trans = new GameObject().transform;
		trans.position = new Vector2(1f, 1f);
		Area area = new Area(new Vector2(1f, 1f), new Vector2(3f, 3f));
		Move move = new Move(trans, area);

		//Act
		Vector2 dest = new Vector2(4f, 4f);
		move.MoveToDest(dest);

		//Assert
		Assert.AreEqual(new Vector2(4f, 4f), (Vector2)trans.position);
	}
}
