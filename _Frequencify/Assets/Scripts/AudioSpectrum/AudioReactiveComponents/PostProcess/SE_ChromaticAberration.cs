using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace WordsManagement.AudioReactiveComponents.PostProcess {

	public class SE_ChromaticAberration : SE_PostProcess {
		private ChromaticAberration ca;

		public SE_ChromaticAberration(Volume cameraVolume) : base(cameraVolume) {
			cameraVolume.profile.TryGet(out ChromaticAberration ca);
			if (ca) {
				this.ca = ca;
			}
			else {
				Debug.LogWarning("Chromatic Aberration not found");
			}
		}

		protected override void PostClampUpdate(float startingAmount) {

			if (startingAmount <= minValue) {
				//Decrease
				if (ca.intensity.value > 0) {
					ca.intensity.value -= decrement;
				}
			}
			else {
				//Increase
				if (ca.intensity.value < 1) {
					ca.intensity.value += increment;
				}
			}
		}
	}

}