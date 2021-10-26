using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCube : MonoBehaviour {
   
    public int index;
    public float startScale, scaleMultiplier;
    public bool useBuffer;
  
    void Update()
    {
        if (useBuffer) {
            transform.localScale = new Vector3(transform.localScale.x,(AudioAnalizer.audioBandBuffer[index] * scaleMultiplier) + startScale,transform.localScale.z);
        }
        else {
            transform.localScale = new Vector3(transform.localScale.x,(AudioAnalizer.audioBand[index] * scaleMultiplier) + startScale,transform.localScale.z);
        }
        transform.position = new Vector3(transform.position.x,transform.localScale.y / 2,transform.position.z) ;
    }
}
