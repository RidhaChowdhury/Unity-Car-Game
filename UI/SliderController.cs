using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider leftSlider;
    public Slider rightSlider;
    public Gradient colorGradient;
    public Image leftFill;
    public Image rightFill;

    public CarController car;
    public float maxValue = 100.0f;
    private float sliderValue = 0.0f;


    private void Start()
    {
        leftSlider.maxValue = maxValue;
        rightSlider.maxValue = maxValue;
        reset();
    }

    private void FixedUpdate()
    {

        sliderValue += Time.deltaTime*4;
        setValue(sliderValue);

        leftFill.color = colorGradient.Evaluate(leftSlider.normalizedValue);
        rightFill.color = colorGradient.Evaluate(leftSlider.normalizedValue);
    }

    public void setValue(float value)
    {
        if(value >= maxValue)
        {
            leftSlider.value = maxValue;
            leftSlider.value = maxValue;
        }
        leftSlider.value = value;
        rightSlider.value = value;
    }

    public void reset()
    {
        leftSlider.value = 0.0f;
        rightSlider.value = 0.0f;
    }
}
