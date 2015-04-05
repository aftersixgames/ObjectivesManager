using UnityEngine;
using System.Collections;

public class ObjectivesController : MonoBehaviour {

	public ObjectivesManager objectivesManager;
	public ObjectiveGUI objectiveGUI;

	void Start () {
		PlayerPrefs.DeleteAll ();
		objectivesManager.Init();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			addProgress ("test", 1);
			addProgress ("test2", 1);
		}
	}

	void addProgress(string key, float progress) {
		Objective earnedObjective = objectivesManager.AddProgress(key, progress);
		if (earnedObjective != null) {
			objectiveGUI.Show(earnedObjective);
		}
	}

	public static ObjectivesController getCurrent() {
		return getCurrent("ObjectivesController");
	}

	public static ObjectivesController getCurrent(string name) {
		return GameObject.Find(name).GetComponent<ObjectivesController>();
	}
}
