using UnityEngine;

public class Life {

	//variable
	float currentLife;
	float maxLife;

	//property
	public float CurrentLife {
		get { return currentLife; }
		set {
			currentLife = Mathf.Max(0, value);
			currentLife = Mathf.Min(value, maxLife);
		}
	}

	public Life(float maxLife) {
		this.maxLife = maxLife;
		currentLife = maxLife;
	}
}
