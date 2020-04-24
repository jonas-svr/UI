using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorPicker
{
    public class NuanceLine : MonoBehaviour, Block
    {

        public float lineVal;
        public int V;
             

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void SetIndex(int i,int tot, ColorPalette palette)
        {
            V = i;
            lineVal = i * 1.0f / (tot-1);
            lineVal = 1 - lineVal;
            BlockContainer bc = GetComponent<BlockContainer>();
            bc.colorPalette = palette;
            bc.numberOfBlocks = tot;
        }

    }
}
