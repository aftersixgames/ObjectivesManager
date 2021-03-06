﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class ObjectivesManager {

	public int simultaneousObjectives = 2;
	public List<Objective> objectives;
	public List<Objective> current;
	public List<Objective> completed;

	public void Init() {
		Reload();
	}

	public void Reload() {
		LoadObjectives();
		PrepareCurrentObjectives();
	}

	public Objective AddProgress(string key, float progress) {
		Objective objective = GetObjective(key);
		if (objective != null && objective.AddProgress(progress)) {
			completed.Add(objective);
			return objective;
		}
		return null;
	}

	public Objective GetObjective(string key) {
		return current.Find(a => a.key == key);
	}

	private void LoadObjectives() {
				
		foreach (Objective objective in objectives)	{
			objective.Load();
			if (objective.Earned) completed.Add(objective);
		}
		
		foreach (Objective objective in completed) {
			objectives.Remove(objective);
		}
	}
	
	private void PrepareCurrentObjectives() {
		for (int i = 0; i < simultaneousObjectives; i++) {
			Next();
		}
	}

	private void Next() {
		if (objectives.Count > 0) {
			current.Add(objectives[0]);
			objectives.RemoveAt(0);
		}
	}
}
