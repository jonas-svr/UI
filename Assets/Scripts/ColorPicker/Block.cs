using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorPicker
{
    public interface Block
    {
        void SetIndex(int index, int tot, ColorPalette palette);
    }
}
