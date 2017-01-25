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
		int result = emptyIdx;
		emptyIdx = FindEmptyIdx();
		return result;
	}

	IEnumerator RunCreatorWithDuration(ItemCreator itemCreator, WaitForSeconds forDuration) {
		while(true) {
			GameObject itemObj = itemCreator.CreateItem();
			itemObj.transform.position = area.GetRandomPosInArea();
			yield return forDuration;
		}
	}

	int FindEmptyIdx() {
		for(int i = 1; i < coroutineList.Count; ++i) {
			if(coroutineList[emptyIdx + i] == null) {
				return emptyIdx + i;
			}
		}
		return emptyIdx + coroutineList.Count;
	}
}
