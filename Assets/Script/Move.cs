using UnityEngine;

public class Move {

	//variable
	Transform trans;
	Area area;

	public Move(Transform trans, Area area) {
		this.trans = trans;
		this.area = area;
	}

	public void MoveToDest(Vector2 dest) {
		trans.position = dest;
	}

	public void MoveToDestInArea(Vector2 dest) {
		trans.position = area.GetFixedPosInArea(dest);
	}

	public bool IsPosInArea(Vector2 pos) {
		return area.IsPosInArea(pos);
	}
}
