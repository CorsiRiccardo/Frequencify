using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using WordsManagement.AudioReactiveComponents;
using WordsManagement.AudioReactiveComponents.PostProcess;

public class AudioPostProcess : AudioReactiveComponent {
	[SerializeField] private AudioPostProcessStruct[] modifiers;

	private List<SE_PostProcess> units;
	private Dictionary<PostProcessUnit, Type> unitClasses;
	private Camera cam;
	private Volume cameraVolume;

	public enum PostProcessUnit {
		ChromaticAberration,
	}

	[Serializable]
	private struct AudioPostProcessStruct {
		public PostProcessUnit unit;
		public AudioEnvironmentModifier.Freq linkedFrequency;

		public float increment;
		public float decrement;

		[Range(0, 100)] public float minValue;
		[Range(0, 100)] public float maxValue;
	}

	private void Awake() {
		cam = GetComponent<Camera>();
		cameraVolume = cam.GetComponent<Volume>();
		unitClasses = new Dictionary<PostProcessUnit, Type>()
		{
			{ PostProcessUnit.ChromaticAberration, typeof(SE_ChromaticAberration) },
		};
	}

	public override void Start() {
		base.Start();
		InitUnits();
	}

	private void InitUnits() {
		units = new List<SE_PostProcess>();
		foreach (AudioPostProcessStruct s in modifiers) {
			Type classType = unitClasses[s.unit];
			ConstructorInfo ctor = classType.GetConstructor(new[] { typeof(Volume) });
			var o = ctor?.Invoke(new object[] { cameraVolume });
			if (o is SE_PostProcess seUnit) {
				seUnit.SetUnit(s.unit);
				seUnit.SetRange(s.minValue, s.maxValue);
				seUnit.SetIncrement(s.increment);
				seUnit.SetDecrement(s.decrement);
				seUnit.freq = s.linkedFrequency;
				units.Add(seUnit);
			}
		}
		// Debug.Log($"Units count:{units.Count}");
	}

	public override void SoundUpdate() {
		var bassAmount = audioEnvironmentModifier.GetFrequency(AudioEnvironmentModifier.Freq.Bass);
		var midAmount = audioEnvironmentModifier.GetFrequency(AudioEnvironmentModifier.Freq.Mid);
		var highAmount = audioEnvironmentModifier.GetFrequency(AudioEnvironmentModifier.Freq.High);
		float myAmount = default;
		foreach (SE_PostProcess unit in units) {
			var f = unit.freq;
			switch (f) {
				case AudioEnvironmentModifier.Freq.Bass:
					myAmount = bassAmount;
					break;
				case AudioEnvironmentModifier.Freq.Mid:
					myAmount = midAmount;
					break;
				case AudioEnvironmentModifier.Freq.High:
					myAmount = highAmount;
					break;
			}
			unit.Update(myAmount);
		}
	}

}