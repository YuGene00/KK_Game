using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour {

	//const
	const int WIDTH_RATE = 9;
	const int HEIGHT_RATE = 16;

	private void Awake() {
		SetResolution();
	}

	void SetResolution() {
		int screenWidth = Screen.width;
		int screenHeight = Screen.height;
		if(screenWidth / screenHeight >= WIDTH_RATE / HEIGHT_RATE) {
			screenWidth = GetFixedWidthToHeight();
		} else {
			screenHeight = GetFixedHeightToWidth();
		}
		Screen.SetResolution(screenWidth, screenHeight, false);
	}

	int GetFixedWidthToHeight() {
		return Screen.height * WIDTH_RATE / HEIGHT_RATE;
	}

	int GetFixedHeightToWidth() {
		return Mathf.CeilToInt(Screen.width * HEIGHT_RATE / WIDTH_RATE);
	}
}
