using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SongButton : MonoBehaviour
{
    public static UnityEvent<int> onSongSelected = new();

    //[HideInInspector]
    public string songTitle;
    //[HideInInspector]
    public int index;

    TextMeshProUGUI titleBox;
    Button button;

    void Start()
    {
        titleBox = GetComponent<TextMeshProUGUI>();
        titleBox.text = songTitle;

        button = GetComponent<Button>();
        button.onClick.AddListener(() => onSongSelected.Invoke(index));
    }
}
