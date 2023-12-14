using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyzer : MonoBehaviour
{
    public static AudioAnalyzer inst;

    public int sampleRate = 1000;
    public UnityEvent<float> onBeat;
    public UnityEvent<float, float> onPlay;

    AudioSource audio;
    float[] samples;
    float average;

    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.LogWarning("Sound analyzer duplicate was deleted");
        }
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
        samples = new float[sampleRate];
    }

   
    void Update()
    {
        if (audio.isPlaying)
        {
            audio.clip.GetData(samples, audio.timeSamples);

            average = 0;
            foreach (var sample in samples)
            {
                average += Mathf.Abs(sample);
            }
            average /= sampleRate;

            onBeat.Invoke(average);
            onPlay.Invoke(audio.time, audio.clip.length);
        }
    }

    public void Adjust(float value)
    {
        audio.time = value * audio.clip.length;
    }
}
