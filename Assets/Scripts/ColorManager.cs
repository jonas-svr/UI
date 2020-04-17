using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorManager : MonoBehaviour
{
    public static ColorManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public Color colorPickerCurColor;
    public Color colorPickerCurNuance;

    public UnityEvent OnColorChange;

    public void ChangeColor(Color col)
    {
        colorPickerCurColor = col;
        if (OnColorChange != null)
            OnColorChange.Invoke();
    }

   
}
