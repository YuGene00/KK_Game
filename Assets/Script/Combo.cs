using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo {

	//variable
	WaitForSeconds forComboTime;
	int currentCombo = 0;

	//property
	public int CurrentCombo { get { return currentCombo; } }
	public bool IsCombo { get { return currentCombo > 0; } }

	public Combo(float comboTime) {
		forComboTime = new WaitForSeconds(comboTime);
	}

	public void Increase(int combo = 1) {
		currentCombo += combo;
		SGT_Coroutine.Instance.StopCoroutine(WaitForComboTime());
		SGT_Coroutine.Instance.StartCoroutine(WaitForComboTime());
	}

	IEnumerator WaitForComboTime() {
		yield return forComboTime;
		Stop();
	}

	public void Stop() {
		currentCombo = 0;
		SGT_Coroutine.Instance.StopCoroutine(WaitForComboTime());
	}
}
