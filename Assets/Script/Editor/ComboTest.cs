using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ComboTest {

	[Test]
	public void IncreaseTest() {
		//Arrange
		Combo combo = new Combo(3);

		//Act
		combo.Increase();
		combo.Increase(2);

		//Assert
		Assert.AreEqual(3, combo.CurrentCombo);
	}

	[Test]
	public void IsComboTest() {
		//Arrange
		Combo combo = new Combo(3);

		//Act
		combo.Increase();

		//Assert
		Assert.IsTrue(combo.IsCombo);
	}

	[Test]
	public void StopTest() {
		//Arrange
		Combo combo = new Combo(3);

		//Act
		combo.Increase(3);
		combo.Stop();

		//Assert
		Assert.AreEqual(0, combo.CurrentCombo);
	}
}
