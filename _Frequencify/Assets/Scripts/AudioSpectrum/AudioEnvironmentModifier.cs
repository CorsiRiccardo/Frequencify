using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using WordsManagement;

public class AudioEnvironmentModifier : Singleton<AudioEnvironmentModifier> {


	public enum Freq {
		Bass,
		Mid,
		High
	}
	private AudioSource audioSource;

	public ActiveTrack activeTrack;
	public bool isActive;

	private float bassIntensity = 0;
	private float midsIntensity = 0;
	private float highsIntensity = 0;
	
	[SerializeField]private float bassIntensityMultiplier = 0;
	[SerializeField]private float midsIntensityMultiplier = 0;
	[SerializeField]private float highsIntensityMultiplier = 0;

	[SerializeField] private bool debug;

	private AudioUIVisualizer[] audioUis;

	protected override void Awake() {
		audioSource = GetComponent<AudioSource>();
		audioUis = GetComponentsInChildren<AudioUIVisualizer>();
		base.Awake();
		audioSource.clip = activeTrack.audioClip;
	}

	private void Start() {
		if (isActive) {
			audioSource.Play();
		}
	}

	void Update() {
		if (isActive) {
			bassIntensity = 0;
			midsIntensity = 0;
			highsIntensity = 0;

			bassIntensity = AudioAnalizer.bandBuffer[0];
			midsIntensity = AudioAnalizer.bandBuffer[1];
			highsIntensity = AudioAnalizer.bandBuffer[2];


			//Normalization
			bassIntensity *= bassIntensityMultiplier * activeTrack.bassDbsMultiplier;
			midsIntensity *= midsIntensityMultiplier * activeTrack.midsDbsMultiplier;
			highsIntensity *= highsIntensityMultiplier * activeTrack.highsDbsMultiplier;

			// Debug.Log($"Deepest bass intensity : {deepestBass}");
			// Debug.Log($"Mid intensity : {middlestMid}");
			// Debug.Log($"High intensity : {loudestHigh}");

			if (debug) {
				EnableUI();
			}
			else {
				DisableUI();
			}
		}
	}

	private void DisableUI() {
		foreach (AudioUIVisualizer ui in audioUis) {
			ui.gameObject.SetActive(false);
		}
	}

	private void EnableUI() {
		foreach (AudioUIVisualizer ui in audioUis) {
			ui.gameObject.SetActive(true);
		}
	}
	

	public float GetFrequency(Freq freq) {
		switch (freq) {
			case Freq.Bass:
				return bassIntensity;
			case Freq.Mid:
				return midsIntensity;
			case Freq.High:
				return highsIntensity;
		}
		return 0;
	}

	public float GetThreshold(Freq freq) {
		switch (freq) {
			case Freq.Bass:
				return activeTrack.bassThreshold;
			case Freq.Mid:
				return activeTrack.midsThreshold;
			case Freq.High:
				return activeTrack.highsThreshold;
		}
		return 0;
	}
}