using UnityEngine;
using NUnit.Framework;

public class AreaTest {

	[Test]
	public void GetFixedPosInAreaTest() {
		//Arrange
		Area area = new Area(new Vector2(1f, 1f), new Vector2(3f, 3f));

		//Act
		Vector2 pos = new Vector2(4f, 7f);
		pos = area.GetFixedPosInArea(pos);

		//Assert
		Assert.AreEqual(new Vector2(3f, 3f), pos);
	}

	[Test]
	public void IsPosInAreaTestTrue() {
		//Arrange
		Area area = new Area(new Vector2(1f, 1f), new Vector2(3f, 3f));

		//Act
		Vector2 pos = new Vector2(2f, 2f);
		bool isInArea = area.IsPosInArea(pos);

		//Assert
		Assert.IsTrue(isInArea);
	}

	[Test]
	public void IsPosInAreaTestFalse() {
		//Arrange
		Area area = new Area(new Vector2(1f, 1f), new Vector2(3f, 3f));

		//Act
		Vector2 pos = new Vector2(0f, 2f);
		bool isInArea = area.IsPosInArea(pos);

		//Assert
		Assert.IsFalse(isInArea);
	}
}
