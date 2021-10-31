using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	public class SE_TransformRotation : SE_Unit {
		
		private Transform transform;
		public SE_TransformRotation(Transform t) {
			transform = t;
		}

		public void Update(AudioTransform.TransformUnit unit,float amount) {
			
			switch (unit) {
				case AudioTransform.TransformUnit.XRotation:
					break;
				case AudioTransform.TransformUnit.YRotation:
					break;
				case AudioTransform.TransformUnit.ZRotation:
					break;
			}
			
		}
	}

}