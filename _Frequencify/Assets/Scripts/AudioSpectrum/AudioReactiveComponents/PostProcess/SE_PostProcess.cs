using UnityEngine;
using UnityEngine.Rendering;

namespace WordsManagement.AudioReactiveComponents.PostProcess {

	public class SE_PostProcess : SE_Unit{
		protected Volume cameraVolume;
		protected AudioPostProcess.PostProcessUnit unit; 
		
		public float increment;
		public float decrement;
		
		public SE_PostProcess(Volume cameraVolume) {
			this.cameraVolume = cameraVolume;
		}

		public void SetIncrement(float increment) {
			this.increment = increment;
		}
		public void SetDecrement(float decrement) {
			this.decrement = decrement;
		}
		public void SetUnit(AudioPostProcess.PostProcessUnit unit) {
			this.unit = unit;
		}
		public void SetRange(float rangeMin,float rangeMax) {
			minValue = rangeMin;
			maxValue = rangeMax;
		}
	}
}