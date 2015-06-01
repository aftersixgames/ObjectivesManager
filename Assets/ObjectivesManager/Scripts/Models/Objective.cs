using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Objective {

	public string key;
	public string description;
	public float targetProgress;
	public bool saveEveryProgress = false;
	public Sprite enabledImage;
	public Sprite disabledImage;

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

	public Sprite Image {
		get {
			return earned ? enabledImage : disabledImage;
		}
	}

	public bool AddProgress(float progress) {
		return SetProgress(currentProgress + progress);
	}

	public bool SetProgress(float progress) {
		if (earned) return false;
		currentProgress = progress;
		if (saveEveryProgress) Save();
		return Earn();
	}

	public void Load() {
		SetProgress(PlayerPrefs.GetFloat(StoreKey, 0.0f));
	}

	public void Save() {
		PlayerPrefs.SetFloat(StoreKey, currentProgress);
		PlayerPrefs.Save();
	}

	private bool Earn() {
		if (currentProgress >= targetProgress) {
			earned = true;
			currentProgress = targetProgress;
			Save();
			return true;
		}
		return false;
	}
}
