using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class CurrentObjectivesUI : MonoBehaviour {

	public List<Objective> objectives;
	public GameObject objectivePrefab;
	public RectTransform container;
	public GameObject panel;

	private Action onHide;

	public void Show() {
		Show(null);
	}

	public void Show(Action onHide) {
		this.onHide = onHide;
		LoadObjectives();
		panel.SetActive(true);
	}

	public void Hide() {
		panel.SetActive(false);
		if (onHide != null) {
			onHide();
		}
	}

	private void LoadObjectives() {
		Clear();
		for (int i = 0; i< objectives.Count; i++) {
			Create(i);
		}
	}

	private void Clear () {
		foreach (Transform objective in container) {
			GameObject.Destroy(objective.gameObject);
		}
	}

	private void Create(int i) {
		Objective objective = objectives[i];
		RectTransform obj = Instantiate(objectivePrefab).GetComponent<RectTransform>();		 

		obj.GetComponent<ObjectiveUI>().objective = objective;
		obj.SetParent(container);

		obj.localScale = container.localScale;

		float height = obj.sizeDelta.y;
		float x = 0;
		float y = (i * -height);

		obj.anchoredPosition = new Vector2(x, y);

	}
}


