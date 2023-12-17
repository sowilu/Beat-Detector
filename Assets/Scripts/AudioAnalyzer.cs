using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyzer : MonoBehaviour
{
    public static AudioAnalyzer inst;

    [Header("Song player settings")]
    public List<AudioClip> songs;
    public TextMeshProUGUI titleBox;

    [Header("Audio analyzis")]
    public int sampleRate = 1000;
    public UnityEvent<float> onBeat;
    public UnityEvent<float, float> onPlay;

    AudioSource audio;
    float[] samples;
    float average;
    int current = 0;

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

        Play(0);
        SongUI.inst.LoadSongs(songs);

        SongButton.onSongSelected.AddListener(Play);
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

    public void Pause(bool pause)
    {
        if (pause)
            audio.Pause();
        else
            audio.Play();
    }

    public void Play(int index)
    {
        current = index;

        audio.clip = songs[current];
        audio.time = 0;
        audio.Play();

        titleBox.text = audio.clip.name;
    }

    public void Next()
    {
        current++;

        if (current >= songs.Count) 
            current = 0;

        Play(current);
    }

    public void Prev()
    {
        current--;

        if (current <= songs.Count)
            current = songs.Count-1;

        Play(current);
    }
}
