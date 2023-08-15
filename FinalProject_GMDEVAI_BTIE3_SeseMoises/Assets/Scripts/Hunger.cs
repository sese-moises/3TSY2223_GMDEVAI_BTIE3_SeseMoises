using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    public Slider _slider;

    public void SetMaxHunger(int hunger)
    {
        _slider.maxValue = hunger;
        _slider.value = hunger;
    }

    public void SetHunger(int hunger)
    {
        _slider.value = hunger;
    }
}
