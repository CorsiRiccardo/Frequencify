using System;
using UnityEngine;
using UnityEngine.UI;

namespace WordsManagement {

    public class AudioUIVisualizer : MonoBehaviour {
        
        private Image image;
        private float highestValue;
        private float maxValue;
        public AudioEnvironmentModifier.Freq freq;
        private static AudioEnvironmentModifier audioEnvironmentModifier;
        
        private void Awake() {
            image = GetComponent<Image>();
            image.fillAmount = 0;
        }

        private void Start() {
            if (audioEnvironmentModifier == null) audioEnvironmentModifier = FindObjectOfType<AudioEnvironmentModifier>();
        }

        private void Update() {
            UpdateImage();
        }

        public void UpdateImage() {
            maxValue = audioEnvironmentModifier.GetThreshold(freq);
            var value = audioEnvironmentModifier.GetFrequency(freq);
            if (value > highestValue) {
                highestValue = value;
            }
            float delta = value / maxValue;
            image.fillAmount = delta;
        }
    }

}