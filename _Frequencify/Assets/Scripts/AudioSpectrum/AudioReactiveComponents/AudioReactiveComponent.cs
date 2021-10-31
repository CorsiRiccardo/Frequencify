using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsManagement.AudioReactiveComponents;

public class AudioReactiveComponent : MonoBehaviour,ISoundUpdated {
	protected AudioEnvironmentModifier audioEnvironmentModifier;
	[SerializeField]protected AudioEnvironmentModifier.Freq freq;
	[SerializeField,Range(0,100)]protected float minValue;
	[SerializeField,Range(0,100)]protected float maxValue;

	public virtual void Start() {
		audioEnvironmentModifier = FindObjectOfType<AudioEnvironmentModifier>();
	}

	private void Update() {
		SoundUpdate();
	}

	public virtual void SoundUpdate() { }
}
