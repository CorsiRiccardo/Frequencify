using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	public class SE_TransformRotation : SE_Transform {
		

		public override void Update(Vector3 frequencies) {
			
			switch (unit) {
				case AudioTransform.TransformUnit.XRotation:
					break;
				case AudioTransform.TransformUnit.YRotation:
					break;
				case AudioTransform.TransformUnit.ZRotation:
					break;
			}
			
		}

		public SE_TransformRotation(Transform transform) : base(transform) { }
	}

}