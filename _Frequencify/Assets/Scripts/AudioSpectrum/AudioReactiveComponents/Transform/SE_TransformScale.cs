using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	public class SE_TransformScale : SE_Transform {

		protected override void PostClampUpdate(float amount) {
			var lScale = transform.localScale;
			switch (unit) {
				case AudioTransform.TransformUnit.XScale:
					transform.localScale = (new Vector3(clampedAmount, lScale.y, lScale.z));
					break;
				case AudioTransform.TransformUnit.YScale:
					transform.localScale = (new Vector3(lScale.x, clampedAmount, lScale.z));
					break;
				case AudioTransform.TransformUnit.ZScale:
					transform.localScale = (new Vector3(lScale.x, lScale.y, clampedAmount));
					break;
			}

		}

		public SE_TransformScale(Transform transform) : base(transform) { }
	}

}