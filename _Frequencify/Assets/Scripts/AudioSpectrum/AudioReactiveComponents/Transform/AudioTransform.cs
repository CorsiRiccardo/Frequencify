using System;
using System.Collections.Generic;
using System.Reflection;
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
			
			[Range(0,100)]public float minValue;
			[Range(0,100)]public float maxValue;
		}

		[SerializeField] private AudioTransformStruct[] modifiers;
		private Dictionary<TransformUnit, Type> unitClasses;

		private void Awake() {
			t = GetComponent<Transform>();
			unitClasses = new Dictionary<TransformUnit, Type>()
			{
				{ TransformUnit.XPosition, typeof(SE_TransformPosition) },
				{ TransformUnit.YPosition, typeof(SE_TransformPosition) },
				{ TransformUnit.ZPosition, typeof(SE_TransformPosition) },
				{ TransformUnit.XRotation, typeof(SE_TransformRotation) },
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
				Type classType = unitClasses[transformStruct.unit];
				ConstructorInfo ctor = classType.GetConstructor(new []{typeof(Transform)});
				var o = ctor?.Invoke(new object[]{transform});
				if (o is SE_Transform seUnit) {
					seUnit.SetTransform(t);
					seUnit.SetUnit(transformStruct.unit);
					seUnit.SetRange(transformStruct.minValue,transformStruct.maxValue);
					seUnit.freq = transformStruct.linkedFrequency;
					units.Add(seUnit);
				}
			}
			Debug.Log($"Units count:{units.Count}");
		}

		public override void SoundUpdate() {
			var bassAmount = audioEnvironmentModifier.GetFrequency(Freq.Bass);
			var midAmount = audioEnvironmentModifier.GetFrequency(Freq.Mid);
			var highAmount = audioEnvironmentModifier.GetFrequency(Freq.High);
			float myAmount = default;
			foreach (SE_Transform unit in units) {
				var f = unit.freq;
				switch (f) {
					case Freq.Bass:
						myAmount = bassAmount;
						break;
					case Freq.Mid:
						myAmount = midAmount;
						break;
					case Freq.High:
						myAmount = highAmount;
						break;
				}
				unit.Update(myAmount);
			}
		}
	}

}