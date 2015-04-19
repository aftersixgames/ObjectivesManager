using UnityEngine;
using System.Collections;
using System;

public class ObjectivesController : MonoBehaviour {

	public ObjectivesManager objectivesManager;
	public EarnedObjectiveUI earnedObjectiveUI;
	public CurrentObjectivesUI currentObjectivesUI;
	public CompletedObjectivesUI completedObjectivesUI;

	void Start () {
		PlayerPrefs.DeleteAll ();
		objectivesManager.Init();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			AddProgress ("test", 1);
			AddProgress ("test2", 1);
		}

		if (Input.GetKeyDown(KeyCode.F2)) {
			ShowCompletedObjectives(() => { print("Hide completed"); });
		}

		if (Input.GetKeyDown(KeyCode.F1)) {
			ShowCurrentObjectives(() => { print("Hide current"); });
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			HideCurrentObjectives();
			HideCompletedObjectives();
		}

		if (Input.GetKeyDown(KeyCode.Return)) {
			ShowCurrentObjectives();
		}
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

	public static ObjectivesController getCurrent() {
		return getCurrent("ObjectivesController");
	}

	public static ObjectivesController getCurrent(string name) {
		return GameObject.Find(name).GetComponent<ObjectivesController>();
	}
}
