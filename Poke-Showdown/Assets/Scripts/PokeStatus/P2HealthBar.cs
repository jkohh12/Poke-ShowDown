using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider sliderP2;
    public Gradient gradientP2;
    public Image fillP2;
    public void SetMaxHealthP2(int health)
    {
        sliderP2.maxValue = health;
        sliderP2.value = health;

        //fill.color = gradient.Evaluate(1f);
    }
    public void SetHealthP2(int health)
    {
        sliderP2.value = health;
        // fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void Start()
    {
        fillP2.color = gradientP2.Evaluate(1f);

    }
    private void Update()
    {
        fillP2.color = gradientP2.Evaluate(sliderP2.normalizedValue);
    }
}
