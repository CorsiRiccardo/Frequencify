using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalizer : MonoBehaviour {

    
    private AudioSource audioSource;

    private float bufferDecreaseAmount = 0.0005f;
    [SerializeField,Range(0,100)]private float bufferDecreaseDivider = 8;

    private readonly float[] samples = new float[512];

    public static readonly float[] bandBuffer = new float[3];
    private readonly float[] bufferDecrease = new float[3];

    public static float[] audioBandBuffer = new float[3];
    public static float[] audioBand = new float[3];

    public static float[] myCustomBands = new float[3];

    private static float trackFrequency;
    private static float hertzPerBin;
    public bool isActive;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
#if UNITY_EDITOR
        if (isActive) {
            trackFrequency = audioSource.clip.frequency;
            hertzPerBin = trackFrequency / 2 / samples.Length;
            // Debug.Log($"hertzPerBin: {hertzPerBin}");
        }
#endif
    }

    // Update is called once per frame
    private void Update() {
#if UNITY_EDITOR
        if (isActive) {
            GetSpectrumAudioSource();
            MakeFrequencyBands();
            BandBuffer();
        }
#endif
    }

    private void SliderAdjuster() { }

    private void GetSpectrumAudioSource() {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    private void MakeFrequencyBands() {
        /* 46,875 Hz per sample
         * [0] = 46,875 * 6 = 0-281
         * [1] = 46,875 * 78 = 282-3.656
         * [2] = 46,875 * 400 = 3.657-18750
         */
        
        
        float[] temp = new float[3];
        for (int i = 0; i < 6; i++) {
            temp[0] += samples[i];
        }
        temp[0] /= 6;
        for (int i = 6; i < 78; i++) {
            temp[1] += samples[i];
        }
        temp[1] /= 72;
        for (int i = 81; i < 400; i++) {
            temp[2] += samples[i];
        }
        temp[2] /= 319;
        myCustomBands = temp;
    }

    private void BandBuffer() {
        for (int i = 0; i < 3; i++) {
            if (myCustomBands[i] > bandBuffer[i]) {
                bandBuffer[i] = myCustomBands[i];
                bufferDecrease[i] = bufferDecreaseAmount;
            }
            else {
                bufferDecrease[i] = (bandBuffer[i] - myCustomBands[i]) / bufferDecreaseDivider;
                bandBuffer[i] -= bufferDecrease[i];
            }
        }
    }
    
}