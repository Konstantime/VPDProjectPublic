using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSettings : MonoBehaviour
{
    private int targetFPS = 60;
    private void Awake()
    {
        Application.targetFrameRate = targetFPS;
    }

}
