using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ColorPicker
{
    [System.Serializable] public class UnityEventOneInt : UnityEvent<int> { }
    [System.Serializable] public class UnityEventTowInt : UnityEvent<int, int> { }
    [System.Serializable] public class UnityEventForInt : UnityEvent<int, int,int,int> { }

    public class ColorPalette : MonoBehaviour
    {

        public BlockContainer NuanceContainer;
        public BlockContainer HUEContainer;
        public BlockContainer PresetContainer;

        public int numberOfNuance;
        public int numberOfHUE;
        public int numberOfPreset;
        private int oldNumberOfNuance;
        private int oldNumberOfHUE;
        private int oldNumberOfPreset;

        public Color curHUE;
        public Color curNuance;
        public Color curPreset;

        public int curH = 0;
        public int curS = 0;
        public int curV = 0;
        public int curP = 0;

        public UnityEvent<int> OnHUEChange = new UnityEventOneInt();
        public UnityEvent<int,int> OnNuanceChange = new UnityEventTowInt();
        public UnityEvent<int> OnPresetChange = new UnityEventOneInt();
        public UnityEvent<int,int,int,int> OnSelectChange = new UnityEventForInt();

        public List<ColorPreset> colorPresets;
            

        private void Awake()
        {
            HUEContainer.colorPalette = this;
            NuanceContainer.colorPalette = this;
            PresetContainer.colorPalette = this;
            UpdateContainers();
        }

        private void UpdateContainers()
        {
            HUEContainer.numberOfBlocks = numberOfHUE;
            HUEContainer.UpdateChildren();
            oldNumberOfHUE = numberOfHUE;
            NuanceContainer.numberOfBlocks = numberOfNuance;
            oldNumberOfNuance = numberOfNuance;
            NuanceContainer.UpdateChildren();
            PresetContainer.numberOfBlocks = numberOfPreset;
            PresetContainer.UpdateChildren();
            oldNumberOfPreset = numberOfPreset;
            colorPresets = new List<ColorPreset>();
            for (int i = 0; i < numberOfPreset; i++)
                colorPresets.Add(new ColorPreset(Color.white, 0, 0, 0));
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (oldNumberOfHUE != numberOfHUE || oldNumberOfNuance != numberOfNuance || oldNumberOfPreset != numberOfPreset)
                UpdateContainers();
        }

#endif

        public void ChangeHUE(Color col, int H)
        {
            curHUE = col;
            curH = H;
            if (OnHUEChange != null)
                OnHUEChange.Invoke(H);
            if (OnSelectChange != null)
                OnSelectChange.Invoke(curH, curS, curV, curP);
        }

        public void ChangeNuance(Color col, int S, int V)
        {
            curS = S;
            curV = V;
            curNuance = col;
            if (OnNuanceChange != null)
                OnNuanceChange.Invoke(S,V);
            if (OnSelectChange != null)
                OnSelectChange.Invoke(curH, curS, curV, curP);
        }

        public void ChangePreset(int np)
        {
            curP = np;
            curPreset = colorPresets[curP].getColor();
            if (OnPresetChange != null)
                OnPresetChange.Invoke(curP);
            if (OnSelectChange != null)
                OnSelectChange.Invoke(curH, curS, curV, curP);
        }
    }
}
