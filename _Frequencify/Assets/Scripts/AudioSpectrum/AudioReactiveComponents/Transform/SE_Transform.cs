using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	public class SE_Transform : SE_Unit{
		
		protected Transform transform;
		protected AudioTransform.TransformUnit unit;
		public AudioEnvironmentModifier.Freq freq;

		private float minValue;
		private float maxValue;

		protected float amount;

		public SE_Transform(Transform transform) {
			this.transform = transform;
		}

		public void SetTransform(Transform t) {
			transform = t;
		}
		public void SetUnit(AudioTransform.TransformUnit unit) {
			this.unit = unit;
		}
		public void SetRange(float rangeMin,float rangeMax) {
			minValue = rangeMin;
			maxValue = rangeMax;
		}
		
		public void Update(float amount) {
			this.amount = Mathf.Clamp(amount, minValue, maxValue);
			PostClampUpdate();
		}

		protected virtual void PostClampUpdate() {
			
		}
	}
}