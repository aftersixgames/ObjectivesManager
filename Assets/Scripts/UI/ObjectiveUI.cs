using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveUI : MonoBehaviour {
	
	[HideInInspector]
	public Objective objective = null;
	public Text description;
	public Text progress;
	public Image image;

	void Update () {
		description.text = objective.description;
		progress.text = objective.CurrentProgress + " / " + objective.targetProgress;
		if (objective.Image != null) {
			image.sprite = objective.Image;
		}
	}
}
