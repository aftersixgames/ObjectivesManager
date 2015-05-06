using UnityEngine;
using System.Collections;
using System;

public class ObjectivesController : MonoBehaviour {

	public ObjectivesManager objectivesManager;
	public EarnedObjectiveUI earnedObjectiveUI;
	public CurrentObjectivesUI currentObjectivesUI;
	public CompletedObjectivesUI completedObjectivesUI;

	void Start () {
		objectivesManager.Init();
	}

	public void AddProgress(string key, float progress) {
		Objective earned = objectivesManager.AddProgress(key, progress);
		if (earned != null) {
			earnedObjectiveUI.Show(earned);
		}
	}

	public void ShowCurrentObjectives() {
		ShowCurrentObjectives(null);
	}

	public void ShowCurrentObjectives(Action onHide) {
		currentObjectivesUI.objectives = objectivesManager.current;
		currentObjectivesUI.Show(onHide);
	}

	public void HideCurrentObjectives() {
		currentObjectivesUI.Hide();
	}

	public void ShowCompletedObjectives() {
		completedObjectivesUI.Show(null);
	}

	public void ShowCompletedObjectives(Action onHide) {
		completedObjectivesUI.objectives = objectivesManager.completed;
		completedObjectivesUI.Show(onHide);
	}

	public void HideCompletedObjectives() {
		completedObjectivesUI.Hide();
	}

	public static ObjectivesController GetCurrent() {
		return GetCurrent("ObjectivesController");
	}

	public static ObjectivesController GetCurrent(string name) {
		return GameObject.Find(name).GetComponent<ObjectivesController>();
	}
}
