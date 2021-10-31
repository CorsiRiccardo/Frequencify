using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	public class SE_Transform : SE_Unit{
		
		protected Transform transform;
		protected AudioTransform.TransformUnit unit;

		public SE_Transform(Transform transform) {
			this.transform = transform;
		}

		public void SetTransform(Transform t) {
			transform = t;
		}
		public void SetUnit(AudioTransform.TransformUnit unit) {
			this.unit = unit;
		}

		public virtual void Update(Vector3 frequencies) {
			
		}
	}
}