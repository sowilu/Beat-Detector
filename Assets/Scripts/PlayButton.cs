using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayButton : MonoBehaviour
{
    public Sprite pauseSprite;
    public Sprite playSprite;

    Button button;
    bool isPaused = false;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnPause);
    }

    
    void OnPause()
    {
        isPaused = !isPaused;
        AudioAnalyzer.inst.Pause(isPaused);
        button.image.sprite = isPaused ? pauseSprite : playSprite;
    }
}
