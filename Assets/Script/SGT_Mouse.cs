using System.Collections;
using UnityEngine;

public class SGT_Mouse : MonoBehaviour {

	//singleton
	static SGT_Mouse instance = null;
	public static SGT_Mouse Instance { get { return instance; } }

	//variable
	public bool Active { get; set; }
	static bool isClick;
	WaitUntil untilLeftUp = new WaitUntil(() => (Input.GetMouseButtonUp(0)));
	WaitUntil untilLeftDown = new WaitUntil(() => (Input.GetMouseButtonDown(0)));
	WaitUntil untilIsClick = new WaitUntil(() => (isClick));
	Vector2 clickPos = Vector2.zero;
	Vector2 playerPos = Vector2.zero;

	private void Awake() {
		instance = this;
	}

	private void Start() {
		StartCoroutine("CheckClick");
		StartCoroutine("MovePlayer");
	}

	IEnumerator CheckClick() {
		isClick = Input.GetMouseButtonDown(0);
		while (Active) {
			if(isClick) {
				yield return untilLeftUp;
			} else {
				yield return untilLeftDown;
				clickPos = Input.mousePosition;
				playerPos = SGT_Player.Instance.Position;
			}
			isClick = !isClick;
		}
	}

	IEnumerator MovePlayer() {
		while(Active) {
			yield return untilIsClick;
			Vector2 distFromClick = (Vector2)Input.mousePosition - clickPos;
			SGT_Player.Instance.Move(playerPos + distFromClick);
		}
	}
}
