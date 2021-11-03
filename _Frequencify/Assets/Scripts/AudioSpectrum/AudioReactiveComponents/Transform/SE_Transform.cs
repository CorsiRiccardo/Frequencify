using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	public class SE_Transform : SE_Unit{
		
		protected Transform transform;
		protected AudioTransform.TransformUnit unit;
		
		protected SE_Transform(Transform transform) {
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
		
	}
}