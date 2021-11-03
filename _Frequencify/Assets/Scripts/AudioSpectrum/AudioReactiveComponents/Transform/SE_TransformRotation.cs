using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	public class SE_TransformRotation : SE_Transform {

		protected override void PostClampUpdate(float amount) {
			switch (unit) {
				case AudioTransform.TransformUnit.XRotation:
					transform.RotateAround(transform.position,Vector3.right,clampedAmount );
					break;
				case AudioTransform.TransformUnit.YRotation:
					transform.RotateAround(transform.position,Vector3.up,clampedAmount );
					break;
				case AudioTransform.TransformUnit.ZRotation:
					transform.RotateAround(transform.position,Vector3.forward,clampedAmount );
					break;
			}
			
		}

		public SE_TransformRotation(Transform transform) : base(transform) { }
	}

}