using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorPicker
{
    [RequireComponent(typeof(Image), typeof(Button))]
    public class NuanceBlock : MonoBehaviour, Block
    {
        private Image colorPlace;
        private Button btn;
        private float val = 1.0f;
        private ColorPalette colorPalette = null;

        public Color lineColor;

        void Awake()
        {
            colorPlace = GetComponent<Image>();
            btn = GetComponent<Button>();
        }

        private void OnEnable()
        {
            btn.onClick.AddListener(SetNuance);
        }

        private void OnDisable()
        {
            if(colorPalette != null)
                colorPalette.OnHUEChange.RemoveListener(SetColor);
            btn.onClick.RemoveListener(SetNuance);

        }

        public void SetIndex(int index, int tot, ColorPalette palette)
        {
            colorPalette = palette;
            colorPalette.OnHUEChange.AddListener(SetColor);
            val = 1.0f - 1.0f * index / (tot - 1);
            SetColor();
        }

        public void SetColor()
        {
            if (colorPalette != null)
                lineColor = colorPalette.curHUE * GetComponentInParent<NuanceLine>().lineVal;
            else
                lineColor = Color.black;
            float r = lineColor.r;
            float g = lineColor.g;
            float b = lineColor.b;
            float max = 1.0f;

            if (r >= g && r >= b)
                max = r;
            if (g >= r && g >= b)
                max = g;
            if (b >= r && b >= g)
                max = b;

            r = Mathf.Lerp(r,max,val);
            g = Mathf.Lerp(g,max,val);
            b = Mathf.Lerp(b,max,val);

            colorPlace.color = new Color(r, g, b, 1.0f);         

        }

        public void SetNuance()
        {
            colorPalette.ChangeNuance(colorPlace.color);
        }
    }
}
