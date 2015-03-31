using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveGUI : MonoBehaviour {

	[HideInInspector]
	public Objective objective = null;
	public Text description;
	public Text progress;
	private Queue<Objective> objectivesToShow = new Queue<Objective>();
	private bool show = true;


	void Update () {
		description.text = objective.description;
		progress.text = objective.CurrentProgress + " / " + objective.targetProgress;
	}

	public void Show(Objective objective) {
		objectivesToShow.Enqueue(objective);
		ShowNext();
	}

	private void ShowNext() {
		if (show && objectivesToShow.Count > 0) {
			show = false;
			objective = objectivesToShow.Dequeue();
			gameObject.SetActive(true);
			Invoke("HideObjective", 5);
		}
	}

	private void HideObjective() {
		gameObject.SetActive(false);
		show = true;
		ShowNext();
	}
}
