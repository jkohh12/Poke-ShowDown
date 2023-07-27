using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P1HealthBar : MonoBehaviour
{

    public Slider sliderP1;
    public Gradient gradientP1;
    public Image fillP1;
    public void SetMaxHealthP1 (int health)
    {
        sliderP1.maxValue = health;
        sliderP1.value = health;

        //fill.color = gradient.Evaluate(1f);
    }
    public void SetHealthP1(int health)
    {
        sliderP1.value = health;
       // fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void Start()
    {
        fillP1.color = gradientP1.Evaluate(1f);

    }
    private void Update()
    {
        fillP1.color = gradientP1.Evaluate(sliderP1.normalizedValue);
    }
}
