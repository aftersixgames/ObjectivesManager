using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	private ObjectivesController objectivesController;

	void Start () {
		objectivesController = ObjectivesController.GetCurrent();	
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.A)) {
			objectivesController.AddProgress("a_key", 1);
			objectivesController.AddProgress("a_key_2", 1);
			objectivesController.AddProgress("a_key_3", 1);
		} 

		if (Input.GetKeyDown(KeyCode.S)) {
			objectivesController.AddProgress("s_key", 1);
		}

		if (Input.GetKeyDown(KeyCode.F1)) {
			objectivesController.ShowCurrentObjectives(() => { print("Current Objectives Closed"); });
		}

		if (Input.GetKeyDown(KeyCode.F2)) {
			objectivesController.ShowCompletedObjectives();
		}

		if (Input.GetKeyDown(KeyCode.F3)) {
			Application.LoadLevel(Application.loadedLevelName);
		}

		if (Input.GetKeyDown(KeyCode.F4)) {
			PlayerPrefs.DeleteAll();
			Application.LoadLevel(Application.loadedLevelName);
		}

	}
}
