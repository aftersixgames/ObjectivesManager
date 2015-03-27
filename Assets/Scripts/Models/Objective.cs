﻿using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Objective {

	public string key;
	public string description;
	public float targetProgress;
	public bool saveEveryProgress = false;

	public float currentProgress;
	public bool earned = false;

	public bool Earned { 
		get { return earned; } 
	}

	public float CurrentProgress {
		get { return currentProgress; }
	}

	public string StoreKey {
		get { return "objectives_manager:objective:" + key; }
	}

	public void AddProgress(float progress) {
		SetProgress(currentProgress + progress);
	}

	public void SetProgress(float progress) {
		if (earned) return;
		currentProgress = progress;
		if (saveEveryProgress) Save();
		Earn();
	}

	public void Load() {
		SetProgress(PlayerPrefs.GetFloat(StoreKey, 0.0f));
	}

	public void Save() {
		PlayerPrefs.SetFloat(StoreKey, currentProgress);
		PlayerPrefs.Save();
	}

	private void Earn() {
		if (currentProgress >= targetProgress) {
			earned = true;
			currentProgress = targetProgress;
			Save();
		}
	}
}
