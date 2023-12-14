using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SongSlider : MonoBehaviour
{
    Slider slider;
    bool autoSlide = true;

    private void Start()
    {
        slider = GetComponent<Slider>();

        AudioAnalyzer.inst.onPlay.AddListener(UpdateSlider);
        slider.onValueChanged.AddListener(SkipThru);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && IsMouseOverSlider())
        {
            autoSlide = false;
        }
        else if(Input.GetMouseButtonUp(0) && IsMouseOverSlider())
        {
            autoSlide = true;
        }
    }

    public void UpdateSlider(float now, float duration)
    {
        if(autoSlide)
            slider.value = now / duration;
    }

    bool IsMouseOverSlider()
    {
        var sliderRect = slider.GetComponent<RectTransform>();
        var mousePos = Input.mousePosition;

        return RectTransformUtility.RectangleContainsScreenPoint(sliderRect, mousePos);
    }

    public void SkipThru(float value)
    {
        if (!autoSlide)
            AudioAnalyzer.inst.Adjust(value);
    }
}
