using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    private float _maxValue;
    private float recoveryRate = 0.01f;

    private void Awake()
    {
        _maxValue = Slider.maxValue;
    }

    protected void OnValueChanged(int value, int maxValue)
    {
        StartCoroutine(BarSlider(value, maxValue));
    }

    IEnumerator BarSlider(int value, int maxValue)
    {
        Slider slider = Slider;

        var normalizeValue = (float)value / maxValue;

        var delta = recoveryRate * Time.deltaTime;

        _maxValue = Slider.value;
        while (slider.value != normalizeValue && normalizeValue <= 1)
        {
            Slider.value = Mathf.MoveTowards(_maxValue, normalizeValue, delta);
            delta += Time.deltaTime;
            yield return null;
        }
    }
}
