using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	public ObjectivesController objectivesController;

	void Update () {

		if (Input.GetKeyDown(KeyCode.A)) {
			objectivesController.AddProgress("a_key", 1);
		}

		if (Input.GetKeyDown(KeyCode.S)) {
			objectivesController.AddProgress("s_key", 1);
		}

    if (Input.GetKeyDown(KeyCode.Space)) {
      objectivesController.AddProgress("space_key_1", 1);
      objectivesController.AddProgress("space_key_2", 1);
    }

    if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S)) {
      objectivesController.AddProgress("as_keys", 1);
    }

		if (Input.GetKeyDown(KeyCode.F1)) {
			objectivesController.ShowCurrentObjectives();
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

		if (Input.GetKeyDown(KeyCode.Escape)) {
			objectivesController.HideCurrentObjectives();
			objectivesController.HideCompletedObjectives();
		}

	}

  public void OnButtonCLicked() {
    objectivesController.AddProgress("button", 1);
  }
}
