using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValue : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;

    private void Start() {
        UpdateValue();
    }

    public void UpdateValue() {
        text.text = slider.value.ToString("F2");
    }
}
