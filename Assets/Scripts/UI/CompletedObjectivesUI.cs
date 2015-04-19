using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class CompletedObjectivesUI : ListObjectivesUI {

	protected override void LoadObjectives() {
		ResizeContainer();
		base.LoadObjectives();
	}

	private void ResizeContainer() {
		Vector2 size = container.sizeDelta;
		size.y = 75 * objectives.Count;

		container.sizeDelta = size;
	}
}
