using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongUI : MonoBehaviour
{
    public static SongUI inst;

    public GameObject songPrefab;
    public GameObject songVisuals;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else
            Destroy(gameObject);

        songVisuals.SetActive(false);
    }

    public void LoadSongs(List<AudioClip> clips)
    {
        for (int i = 0; i < clips.Count; i++)
        {
            var clip = clips[i];

            var song = Instantiate(songPrefab);

            song.transform.parent = songVisuals.transform;

            var songButton = song.GetComponent<SongButton>();               
            songButton.songTitle = clip.name;
            songButton.index = i;
        }
    }

    public void Toggle()
    {
        songVisuals.SetActive(!songVisuals.activeSelf);
    }
}
