using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGT_Coroutine : MonoBehaviour {

	static SGT_Coroutine instance = null;
	public static SGT_Coroutine Instance {
		get {
			if(!instance) {
				GameObject gameObj = new GameObject("SGT_Coroutine");
				instance = gameObj.AddComponent<SGT_Coroutine>();
				DontDestroyOnLoad(gameObj);
			}
			return instance;
		}
	}
}
