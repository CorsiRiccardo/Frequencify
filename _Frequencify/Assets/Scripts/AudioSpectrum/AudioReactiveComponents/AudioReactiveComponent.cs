using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsManagement.AudioReactiveComponents;

public class AudioReactiveComponent : MonoBehaviour,ISoundUpdated {
	protected AudioEnvironmentModifier audioEnvironmentModifier;

	public virtual void Start() {
		audioEnvironmentModifier = FindObjectOfType<AudioEnvironmentModifier>();
	}

	private void Update() {
		SoundUpdate();
	}

	public virtual void SoundUpdate() { }
}
