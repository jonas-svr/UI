using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ColorPicker
{
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

        public UnityEvent OnHUEChange;
        public UnityEvent OnNuanceChange;
        public UnityEvent OnPresetChange;

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
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (oldNumberOfHUE != numberOfHUE || oldNumberOfNuance != numberOfNuance || oldNumberOfPreset != numberOfPreset)
                UpdateContainers();
        }

#endif

        public void ChangeHUE(Color col)
        {
            curHUE = col;
            if (OnHUEChange != null)
                OnHUEChange.Invoke();
        }

        public void ChangeNuance(Color col)
        {
            curNuance = col;
            if (OnNuanceChange != null)
                OnNuanceChange.Invoke();
        }

        public void ChangePreset(Color col)
        {
            curPreset = col;
            if (OnPresetChange != null)
                OnPresetChange.Invoke();
        }
    }
}
