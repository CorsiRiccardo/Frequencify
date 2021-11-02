using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	public class SE_TransformRotation : SE_Transform {
		

		public override void Update(float amount) {
			
			switch (unit) {
				case AudioTransform.TransformUnit.XRotation:
					transform.RotateAround(transform.position,Vector3.right,amount );
					break;
				case AudioTransform.TransformUnit.YRotation:
					transform.RotateAround(transform.position,Vector3.up,amount );
					break;
				case AudioTransform.TransformUnit.ZRotation:
					transform.RotateAround(transform.position,Vector3.forward,amount );
					break;
			}
			
		}

		public SE_TransformRotation(Transform transform) : base(transform) { }
	}

}