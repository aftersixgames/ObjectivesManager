using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class CompletedObjectivesUI : ListObjectivesUI {

	public RectTransform scrollBarHandle;

	void Start() {
		FixScrollBarHandlePosition();
	}

	protected override void LoadObjectives() {
		ResizeContainer();
		base.LoadObjectives();
	}

	private void ResizeContainer() {
		Vector2 size = container.sizeDelta;
		size.y = 75 * objectives.Count;

		container.sizeDelta = size;
	}

	private void FixScrollBarHandlePosition() {
		scrollBarHandle.offsetMin = new Vector2(-10, -10);
		scrollBarHandle.offsetMax = new Vector2(10, 10);
	}
}
