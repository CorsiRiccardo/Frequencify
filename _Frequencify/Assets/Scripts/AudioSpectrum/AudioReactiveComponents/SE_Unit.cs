using UnityEngine;

namespace WordsManagement.AudioReactiveComponents {

	public abstract class SE_Unit {
		
		public AudioEnvironmentModifier.Freq freq;

		protected float minValue;
		protected float maxValue;
		
		protected float clampedAmount;
		
		public void Update(float startingAmount) {
			clampedAmount = Mathf.Clamp(startingAmount, minValue, maxValue);
			PostClampUpdate(startingAmount);
		}

		protected virtual void PostClampUpdate(float amount) { }
	}

}