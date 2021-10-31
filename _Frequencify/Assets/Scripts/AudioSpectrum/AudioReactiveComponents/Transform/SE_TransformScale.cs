using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	public class SE_TransformScale : SE_Transform {
		
		public override void Update(Vector3 frequencies) {
			
			switch (unit) {
				case AudioTransform.TransformUnit.XScale:
					break;
				case AudioTransform.TransformUnit.YScale:
					break;
				case AudioTransform.TransformUnit.ZScale:
					break;
			}
			
		}

		public SE_TransformScale(Transform transform) : base(transform) { }
	}

}