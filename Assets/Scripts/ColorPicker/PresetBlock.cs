using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorPicker
{
    [RequireComponent(typeof(Button))]
    public class PresetBlock : MonoBehaviour, Block
    {
        public Image selected;
        private Image img;
        private Button btn;
        private ColorPalette colorPalette;
        private int P;

        private void Awake()
        {
            img = GetComponent<Image>();
            btn = GetComponent<Button>();
        }

        private void OnEnable()
        {
            btn.onClick.AddListener(SetPreset);
        }

        private void OnDisable()
        {
            if (colorPalette)
            {
                colorPalette.OnSelectChange.RemoveListener(OnSelect);
            }
            btn.onClick.RemoveListener(SetPreset);

        }

        public void SetIndex(int index, int tot, ColorPalette palette)
        {
            colorPalette = palette;
            P = index;
            colorPalette.OnSelectChange.AddListener(OnSelect);
            img.color = colorPalette.colorPresets[P].getColor();
        }

        public void SetPreset()
        {
            colorPalette.ChangePreset(P);
        }

        public void OnSelect(int nH, int nS, int nV, int nP)
        {
            if (P == nP)
            {
                selected.gameObject.SetActive(true);
                img.color = colorPalette.colorPresets[P].getColor();
            }
            else
                selected.gameObject.SetActive(false);
        }
    }
}
