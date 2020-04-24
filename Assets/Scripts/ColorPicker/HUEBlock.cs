using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorPicker
{
    [RequireComponent(typeof(Image))]
    public class HUEBlock : MonoBehaviour, Block
    {
        private Image im;
        private Button btn;
        private ColorPalette colorPalette = null;
        private int H;
             

        void Awake()
        {
            im = GetComponent<Image>();
            btn = GetComponent<Button>();
        }

        private void OnEnable()
        {
            btn.onClick.AddListener(SetColor);
        }

        private void OnDisable()
        {
            btn.onClick.RemoveListener(SetColor);
        }

        public void SetColor()
        {
            if(colorPalette)
                colorPalette.ChangeHUE(im.color, H);
        }

        public void SetIndex(float val)
        {
            val = Mathf.Clamp(val, 0.0f, 1.0f);
            Color col;

            if (val <= 1 / 6.0f)
            {
                col = new Color(
                    1.0f,
                    0.0f,
                    Mathf.Lerp(0.0f, 1.0f, val * 6.0f)
                    );
            }
            else if (val <= 2 / 6.0f)
            {
                col = new Color(
                   Mathf.Lerp(1.0f, 0.0f, val * 6.0f - 1.0f),
                   0.0f,
                   1.0f
                   );
            }
            else if (val <= 3 / 6.0f)
            {
                col = new Color(
                     0.0f,
                     Mathf.Lerp(0.0f, 1.0f, val * 6.0f - 2.0f),
                     1.0f
                     );
            }
            else if (val <= 4 / 6.0f)
            {
                col = new Color(
                     0.0f,
                     1.0f,
                     Mathf.Lerp(1.0f, 0.0f, val * 6.0f - 3.0f)
                     );
            }
            else if (val <= 5 / 6.0f)
            {
                col = new Color(
                     Mathf.Lerp(0.0f, 1.0f, val * 6.0f - 4.0f),
                     1.0f,
                     0.0f
                     );
            }
            else
            {
                col = new Color(
                     1.0f,
                     Mathf.Lerp(1.0f, 0.0f, val * 6.0f - 5.0f),
                     0.0f
                     );
            }

            im.color = col;
        }

        public void SetIndex(int id, int tot, ColorPalette palette)
        {
            H = id;
            colorPalette = palette;
            SetIndex(id * 1.0f / tot);
        }
    }
}
