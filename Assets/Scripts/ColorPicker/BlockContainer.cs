using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorPicker
{
    public class BlockContainer : MonoBehaviour
    {
        [HideInInspector]
        public ColorPalette colorPalette;

        [HideInInspector]
        public int numberOfBlocks = 20;

        public GameObject blockPrefab;

        // Start is called before the first frame update
        void Start()
        {
            if (blockPrefab == null)
            {
                Debug.LogWarning(name + " contient un blockPrefab invalide");
                return;
            }

            if (blockPrefab.GetComponent<Block>() == null)
            {
                Debug.LogWarning(name + " contient un blockPrefab invalide : " + blockPrefab.name);
                return;
            }

            UpdateChildren();
        }


        public void UpdateChildren()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < numberOfBlocks; i++)
            {
                GameObject blObj = GameObject.Instantiate(blockPrefab, transform);
                Block bl = blObj.GetComponent<Block>();
                bl.SetIndex(i,numberOfBlocks,colorPalette);
            }
        }
    }
}
