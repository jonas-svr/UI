using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorPicker
{
    public class NuanceLine : MonoBehaviour, Block
    {

        public float lineVal;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void SetIndex(int i,int tot)
        {
            lineVal = i * 1.0f / (tot-1);
            lineVal = 1 - lineVal;
            GetComponent<BlockContainer>().numberOfBlocks = tot;
        }

    }
}
