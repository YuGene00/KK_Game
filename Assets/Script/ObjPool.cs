using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjPool {

	//struct
	struct Root {
		public MonoBehaviour mono;
		public Transform trans;
	}

	//variable
	Stack<GameObject> poolStack = new Stack<GameObject>();
	Root root;
	GameObject origin;
	int unitNo;

	public ObjPool(GameObject gameObj, int unitNo = 20) {
		InitVariable(gameObj, unitNo);
		CreateRoot();
		AllocateMemory(unitNo);
	}

	void InitVariable(GameObject gameObj, int unitNo) {
		origin = gameObj;
		this.unitNo = unitNo;
	}

	void CreateRoot() {
		GameObject rootObj = new GameObject(origin.name);
		root.mono = rootObj.GetComponent<MonoBehaviour>();
		root.trans = rootObj.transform;
	}

	void AllocateMemory(int allocateNo) {
		for (int i = 0; i < allocateNo; ++i) {
			GameObject newObj = CreateNewObjectIntoStack();
			newObj.SetActive(false);
		}
	}

	GameObject CreateNewObjectIntoStack() {
		GameObject newObj = Object.Instantiate(origin);
		newObj.transform.SetParent(root.trans);
		newObj.AddComponent<Releaser>().ObjPool = this;
		poolStack.Push(newObj);
		return newObj;
	}

	public GameObject Retain(Vector3 position = default(Vector3), Quaternion? rotation = null) {
		if (rotation == null) {
			rotation = Quaternion.identity;
		}

		if (IsStackEmpty()) {
			AllocateMemory(unitNo);
		}

		GameObject retainedObj = GetObjFromStackTo(position, rotation.Value);
		retainedObj.SetActive(true);
		return retainedObj;
	}

	bool IsStackEmpty() {
		return poolStack.Count == 0;
	}

	GameObject GetObjFromStackTo(Vector3 position, Quaternion rotation) {
		GameObject gameObj = poolStack.Pop();
		Transform trans = gameObj.transform;
		trans.position = position;
		trans.rotation = rotation;
		return gameObj;
	}

	public static void Release(GameObject gameObj) {
		gameObj.GetComponent<Releaser>().Release();
	}

	public static void Release(GameObject gameObj, float time) {
		gameObj.GetComponent<Releaser>().Release(time);
	}

	void ReturnToObjPool(GameObject obj) {
		obj.SetActive(false);
		poolStack.Push(obj);
	}

	void ReturnToObjPool(GameObject gameObj, float time) {
		root.mono.StartCoroutine(ReturnAfterTime(gameObj, time));
	}

	IEnumerator ReturnAfterTime(GameObject gameObj, float time) {
		yield return new WaitForSeconds(time);
		ReturnToObjPool(gameObj);
	}

	public class Releaser : MonoBehaviour {

		//caching
		GameObject gameObj;

		//variable
		ObjPool objPool;
		public ObjPool ObjPool { set { objPool = value; } }

		private void Awake() {
			InitCaching();
		}

		void InitCaching() {
			gameObj = gameObject;
		}

		public void Release() {
			objPool.ReturnToObjPool(gameObj);
		}

		public void Release(float time) {
			objPool.ReturnToObjPool(gameObj, time);
		}
	}
}