using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMgr {

	//variable
	List<IEnumerator> coroutineList = new List<IEnumerator>(5);
	int emptyIdx = 0;
	static Area area = new Area(new Vector2(-310f, 700f), new Vector2(310f, 700f));

	public int SetCreatorWithDuration(ItemCreator itemCreator, float duration) {
		if(coroutineList.Count <= emptyIdx) {
			coroutineList.Add(RunCreatorWithDuration(itemCreator, new WaitForSeconds(duration)));
		} else {
			coroutineList[emptyIdx] = RunCreatorWithDuration(itemCreator, new WaitForSeconds(duration));
		}
		
		return GetSettedIdx();
	}

	IEnumerator RunCreatorWithDuration(ItemCreator itemCreator, WaitForSeconds forDuration) {
		while(true) {
			GameObject itemObj = itemCreator.CreateItem();
			itemObj.transform.position = area.GetRandomPosInArea();
			yield return forDuration;
		}
	}

	int GetSettedIdx() {
		int result = emptyIdx;
		emptyIdx = FindEmptyIdx();
		return result;
	}

	int FindEmptyIdx() {
		for(int i = emptyIdx + 1; i < coroutineList.Count; ++i) {
			if(coroutineList[i] == null) {
				return i;
			}
		}
		return coroutineList.Count;
	}

	public void RemoveCreatorWithIdx(int index) {
		try {
			TryAccessCoroutineListWithIdx(index);
			coroutineList[index] = null;
			SetEmptyIdx(index);
		} finally { }
	}

	void TryAccessCoroutineListWithIdx(int index) {
		if (index > coroutineList.Count) {
			throw new System.Exception("Out of Coroutine List Range");
		}
	}

	void SetEmptyIdx(int index) {
		if(index < emptyIdx) {
			emptyIdx = index;
		}
	}
}
