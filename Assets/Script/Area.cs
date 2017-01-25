using UnityEngine;

public class Area {

	//variable
	public Vector2 leftBot;
	public Vector2 rightUp;

	public Area(Vector2 leftBot, Vector2 rightUp) {
		this.leftBot = leftBot;
		this.rightUp = rightUp;
	}

	public Vector2 GetFixedPosInArea(Vector2 pos) {
		Vector2 result;
		result.x = Mathf.Max(leftBot.x, pos.x);
		result.x = Mathf.Min(pos.x, rightUp.x);
		result.y = Mathf.Max(leftBot.y, pos.y);
		result.y = Mathf.Min(pos.y, rightUp.y);
		return result;
	}

	public bool IsPosInArea(Vector2 pos) {
		return (leftBot.x <= pos.x && rightUp.x >= pos.x) &&
			(leftBot.y <= pos.y && rightUp.y >= pos.y);
	}

	public Vector2 GetRandomPosInArea() {
		return new Vector2(Random.Range(leftBot.x, rightUp.x), 
			Random.Range(leftBot.y, rightUp.y));
	}
}
