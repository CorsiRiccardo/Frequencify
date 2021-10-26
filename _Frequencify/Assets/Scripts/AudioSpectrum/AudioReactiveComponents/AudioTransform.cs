using System;
using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	[RequireComponent(typeof(Transform))]
	public class AudioTransform : AudioReactiveComponent {
		private Transform transform;

		private void Awake() {
			transform = GetComponent<Transform>();
		}

		public override void SoundUpdate() {
			var value = audioEnvironmentModifier.GetFrequency(freq);
			var clampedValue = Mathf.Clamp(value, minValue, maxValue);
			transform.localScale = Vector3.one * clampedValue;
		}
	}
}