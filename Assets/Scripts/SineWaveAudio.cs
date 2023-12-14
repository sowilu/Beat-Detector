using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SineWaveAudio : MonoBehaviour
{
    public float frequency = 440;
    public float duration = 2f;
    public float amplitude = 0.5f;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        GenerateSineWave();
        audio.Play();
    }

    void GenerateSineWave()
    {
        var sampleRate = 44100;
        var numSamples = (int)(duration * sampleRate);
        var samples = new float[numSamples];

        for (int i = 0; i < numSamples; i++)
        {
            var t = i / (float)sampleRate;
            samples[i] = amplitude * Mathf.Sin(2f * Mathf.PI * frequency * t);
        }

        audio.clip = AudioClip.Create("Sine Wave", numSamples, 1, sampleRate, false);
        audio.clip.SetData(samples, 0);
    }
}
