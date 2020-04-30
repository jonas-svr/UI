using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorPicker
{
    [RequireComponent(typeof(Image), typeof(Button))]
    public class NuanceBlock : MonoBehaviour, Block
    {
        private Image im;
        public Image selected;
        private Button btn;
        private float val = 1.0f;
        private ColorPalette colorPalette = null;

        public Color lineColor;
        private int S;
        private int V;

        void Awake()
        {
            im = GetComponent<Image>();
            btn = GetComponent<Button>();
        }

        private void OnEnable()
        {
            btn.onClick.AddListener(SetNuance);
        }

        private void OnDisable()
        {
            if (colorPalette != null)
            {
                colorPalette.OnHUEChange.RemoveListener(SetColor);
                colorPalette.OnSelectChange.RemoveListener(OnSelect);
            }
            btn.onClick.RemoveListener(SetNuance);

        }

        public void SetIndex(int index, int tot, ColorPalette palette)
        {
            S = index;
            colorPalette = palette;
            colorPalette.OnHUEChange.AddListener(SetColor);
            colorPalette.OnSelectChange.AddListener(OnSelect);
            val = 1.0f - 1.0f * index / (tot - 1);
            SetColor();
        }

        public void SetColor(int H = 0)
        {
            if (colorPalette != null)
            {
                NuanceLine nl = GetComponentInParent<NuanceLine>();
                lineColor = colorPalette.curHUE * nl.lineVal;
                V = nl.V;
            }
            else
            {
                lineColor = Color.black;
                V = 0;
            }
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

        public void SetNuance()
        {
            colorPalette.ChangeNuance(im.color, S, V);
        }

        public void OnSelect(int nH, int nS, int nV, int nP)
        {
            if (S == nS && V == nV)
            {
                selected.gameObject.SetActive(true);
            }
            else
                selected.gameObject.SetActive(false);
        }
    }
}
