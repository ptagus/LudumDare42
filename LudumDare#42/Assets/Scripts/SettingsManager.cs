using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingsManager
{
    public static float volume = 0.5f;
    public static void Volume(float v)
    {
        volume = v;
    }
}
