using System;
using System.Collections.Generic;
using UnityEngine;
using static AudioEnvironmentModifier;

namespace WordsManagement.AudioReactiveComponents {

	[RequireComponent(typeof(Transform))]
	public class AudioTransform : AudioReactiveComponent {
		private Transform t;
		private Dictionary<TransformUnit, SE_Unit> components;

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
			[SerializeField]private TransformUnit unit;
			[SerializeField]private Freq linkedFrequency;
		}

		private TransformUnit[] units;
		[SerializeField]private AudioTransformStruct[] modifiers;

		private void Awake() {
			t = GetComponent<Transform>();
			components = new Dictionary<TransformUnit, SE_Unit>()
			{
				{ TransformUnit.XPosition, new SE_TransformPosition() },
				{ TransformUnit.YPosition,  new SE_TransformPosition()},
				{ TransformUnit.ZPosition,  new SE_TransformPosition()},
				{ TransformUnit.XRotation, new SE_TransformRotation(t) },
				{ TransformUnit.YRotation, new SE_TransformRotation(t) },
				{ TransformUnit.ZRotation, new SE_TransformRotation(t) },
				{ TransformUnit.XScale, new SE_TransformScale() },
				{ TransformUnit.YScale, new SE_TransformScale() },
				{ TransformUnit.ZScale, new SE_TransformScale()},
			};
		}

		public override void SoundUpdate() {
			var value = audioEnvironmentModifier.GetFrequency(freq);
			var clampedValue = Mathf.Clamp(value, minValue, maxValue);
			t.localScale = Vector3.one * clampedValue;
		}
	}
}