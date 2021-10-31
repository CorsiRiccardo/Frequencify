using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static AudioEnvironmentModifier;

namespace WordsManagement.AudioReactiveComponents {

	[RequireComponent(typeof(Transform))]
	public class AudioTransform : AudioReactiveComponent {
		private Transform t;
		private List<SE_Transform> units;
		public enum TransformUnit {
			XPosition,
			YPosition,
			ZPosition,
			XRotation,
			YRotation,
			ZRotation,
			XScale,
			YScale,
			ZScale,
		}

		[Serializable]
		private struct AudioTransformStruct {
			public TransformUnit unit;
			public Freq linkedFrequency;
		}

		[SerializeField] private AudioTransformStruct[] modifiers;
		private Dictionary<TransformUnit,Type> unitClasses;

		private void Awake() {
			t = GetComponent<Transform>();
			unitClasses = new Dictionary<TransformUnit, Type>()
			{
				{ TransformUnit.XPosition, typeof(SE_TransformPosition) },
				{ TransformUnit.YPosition,typeof(SE_TransformPosition) },
				{ TransformUnit.ZPosition, typeof(SE_TransformPosition) },
				{ TransformUnit.XRotation,typeof(SE_TransformRotation) },
				{ TransformUnit.YRotation, typeof(SE_TransformRotation) },
				{ TransformUnit.ZRotation, typeof(SE_TransformRotation) },
				{ TransformUnit.XScale, typeof(SE_TransformScale) },
				{ TransformUnit.YScale, typeof(SE_TransformScale) },
				{ TransformUnit.ZScale, typeof(SE_TransformScale) },
			};
		}

		public override void Start() {
			base.Start();
			InitUnits();
		}

		private void InitUnits() {
			units = new List<SE_Transform>();
			foreach (AudioTransformStruct transformStruct in modifiers) {
				Type type = unitClasses[transformStruct.unit];
				var instance = Activator.CreateInstance(type);
				if (instance is SE_Transform seUnit) {
					seUnit.SetTransform(t);
					seUnit.SetUnit(transformStruct.unit);
					units.Add(seUnit);
				}
			}
			Debug.Log($"Units count:{units.Count}");
		}

		public override void SoundUpdate() {
			// var value = audioEnvironmentModifier.GetFrequency(freq);
			// var clampedValue = Mathf.Clamp(value, minValue, maxValue);
			// t.localScale = Vector3.one * clampedValue;
			var bassAmount = Mathf.Clamp(audioEnvironmentModifier.GetFrequency(Freq.Bass),minValue,maxValue);
			var midAmount = Mathf.Clamp(audioEnvironmentModifier.GetFrequency(Freq.Mid),minValue,maxValue);
			var highAmount =  Mathf.Clamp(audioEnvironmentModifier.GetFrequency(Freq.High),minValue,maxValue);
			foreach (SE_Transform unit in units) {
				unit.Update(new Vector3(bassAmount,midAmount,highAmount));
			}
		}
	}

}