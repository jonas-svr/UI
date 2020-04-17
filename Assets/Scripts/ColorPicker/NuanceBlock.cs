using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorPicker
{
    [RequireComponent(typeof(Image))]
    public class NuanceBlock : MonoBehaviour, Block
    {
        private Image im;
        private float val = 1.0f;

        public Color lineColor;



        void Awake()
        {
            im = GetComponent<Image>();
        }

        private void OnEnable()
        {
            ColorManager.instance.OnColorChange.AddListener(SetColor);
        }

        private void OnDisable()
        {
            ColorManager.instance.OnColorChange.RemoveListener(SetColor);
        }

        public void SetIndex(int index, int tot)
        {
            val = 1.0f - 1.0f * index / (tot - 1);
            SetColor();
        }

        public void SetColor()
        {
            lineColor = ColorManager.instance.colorPickerCurColor * GetComponentInParent<NuanceLine>().lineVal;
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

            im.color = new Color(r, g, b, 1.0f);         

        }

    }
}
