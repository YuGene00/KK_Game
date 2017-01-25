using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	//variable
	Move move;
	EffectorMgr effectorMgr;

	//property
	int effectorListVer = 0;
	public int EffectorListVer { get { return effectorListVer; } }

	private void Awake() {
		InitVariable();
	}

	void InitVariable() {
		InitMove();
		InitEffectorMgr();
	}

	void InitMove() {
		Area area = new Area(new Vector2(-360f, -640f), new Vector2(360f, 640f));
		move = new Move(transform, area);
	}

	void InitEffectorMgr() {
		effectorMgr = new EffectorMgr(this);
	}

	private void Start() {
		StartCoroutine("DropSelf");
	}

	IEnumerator DropSelf() {
		while(true) {

			yield return null;
		}
	}

	public void RunEffectors(MonoBehaviour target) {
		effectorMgr.RunEffectors(target);
	}

	public void SynchronizeWith(EffectorMgr target) {
		effectorMgr.SynchronizeWith(target);
	}

	public void UpdateEffectors(params Effector[] effectors) {
		effectorMgr.UpdateEffectors(effectors);
	}
}
