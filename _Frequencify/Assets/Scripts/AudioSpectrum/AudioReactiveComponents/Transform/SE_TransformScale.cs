using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	public class SE_TransformScale : SE_Transform {

		public override void Update(float amount) {
			var lScale = transform.localScale;
			switch (unit) {
				case AudioTransform.TransformUnit.XScale:
					transform.localScale = (new Vector3(amount, lScale.y, lScale.z));
					break;
				case AudioTransform.TransformUnit.YScale:
					transform.localScale = (new Vector3(lScale.x, amount, lScale.z));
					break;
				case AudioTransform.TransformUnit.ZScale:
					transform.localScale = (new Vector3(lScale.x, lScale.y, amount));
					break;
			}

		}

		public SE_TransformScale(Transform transform) : base(transform) { }
	}

}