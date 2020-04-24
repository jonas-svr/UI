using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ColorPreset
{
    private float[] col = new float[4];
    public int H;
    public int S;
    public int V;

    public Color getColor()
    {
        return (new Color(col[0], col[1], col[2], col[3]));
    }

    public ColorPreset(Color color, int nH, int nS, int nV)
    {
        col[0] = color.r;
        col[1] = color.g;
        col[2] = color.b;
        col[3] = color.a;
        this.H = nH;
        this.S = nS;
        this.V = nV;
    }

    public void SetColor(Color color, int nH, int nS, int nV)
    {
        col[0] = color.r;
        col[1] = color.g;
        col[2] = color.b;
        col[3] = color.a;
        this.H = nH;
        this.S = nS;
        this.V = nV;
    }

}
    

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
