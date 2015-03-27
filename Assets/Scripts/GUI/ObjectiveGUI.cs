using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ObjectiveGUI : MonoBehaviour {

	public Objective objective;
	public Text description;
	public Text progress;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		description.text = objective.description;
		progress.text = objective.CurrentProgress + " / " + objective.targetProgress;
	}
}
