using UnityEngine;

namespace WordsManagement {

    [CreateAssetMenu(fileName = "ActiveTrack", menuName = "custom/ActiveTrack", order = 0)]
    public class ActiveTrack : ScriptableObject {
        public AudioClip audioClip;
    
        [Range(0,3),] public float bassDbsMultiplier = 1;
        [Range(0,100),] public float bassThreshold = 50;
        [Range(0,3),] public float midsDbsMultiplier = 1;
        [Range(0,100),] public float midsThreshold = 50;

        [Range(0,3),] public float highsDbsMultiplier = 1;
        [Range(0,100),] public float highsThreshold = 50;
    }

}