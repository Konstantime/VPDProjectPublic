using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public float fps;
    public Text fpsText;
    void Update()
    {
        fps = 1f / Time.deltaTime;
        fpsText.text = "FPS: " + (int)fps;
    }
}
