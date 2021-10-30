using System;
using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	[RequireComponent(typeof(Transform))]
	public class AudioTransform : AudioReactiveComponent {
		private Transform t;

		private void Awake() {
			t = GetComponent<Transform>();
		}

		public override void SoundUpdate() {
			var value = audioEnvironmentModifier.GetFrequency(freq);
			var clampedValue = Mathf.Clamp(value, minValue, maxValue);
			t.localScale = Vector3.one * clampedValue;
		}
	}
}