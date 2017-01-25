using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator {

	//variable
	ObjPool objPool;
	EffectorMgr effectorMgr;

	public ItemCreator(string path, params Effector[] effectors) {
		InitObjPool(path);
		InitEffectorMgr(effectors);
	}

	void InitObjPool(string path) {
		GameObject gameObj = Resources.Load<GameObject>(path);
		objPool = new ObjPool(gameObj);
	}

	void InitEffectorMgr(Effector[] effectors) {
		effectorMgr = new EffectorMgr(effectors);
	}
	
	public GameObject CreateItem() {
		GameObject gameObj = objPool.Retain();
		gameObj.GetComponent<Item>().SynchronizeWith(effectorMgr);
		return gameObj;
	}

	public void UpdateEffectors(params Effector[] effectors) {
		effectorMgr.UpdateEffectors(effectors);
	}
}