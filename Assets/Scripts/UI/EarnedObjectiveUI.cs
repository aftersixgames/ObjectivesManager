using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EarnedObjectiveUI : MonoBehaviour {

	public ObjectiveUI objectiveUI;
	public AudioSource audioSource;

	private Queue<Objective> objectivesToShow = new Queue<Objective>();
	private bool show = true;

	void Update() {
		if (show && objectivesToShow.Count > 0) {
			ShowNext();
		}
	}

	public void Show(Objective objective) {
		objectivesToShow.Enqueue(objective);
	}

	private void ShowNext() {
		show = false;
		objectiveUI.objective = objectivesToShow.Dequeue();
		objectiveUI.gameObject.SetActive(true);
		audioSource.Play();
		Invoke("HideObjective", 5);
	}

	private void HideObjective() {
		objectiveUI.gameObject.SetActive(false);
		show = true;
	}
}
