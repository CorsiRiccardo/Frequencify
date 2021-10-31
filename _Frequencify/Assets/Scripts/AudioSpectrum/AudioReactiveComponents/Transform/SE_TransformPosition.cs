using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	public class SE_TransformPosition : SE_Transform {
		public override void Update(Vector3 frequencies) {
			switch (unit) {
				case AudioTransform.TransformUnit.XPosition:
					break;
				case AudioTransform.TransformUnit.YPosition:
					break;
				case AudioTransform.TransformUnit.ZPosition:
					break;
			}
			
		}

		public SE_TransformPosition(Transform transform) : base(transform) { }
	}

}