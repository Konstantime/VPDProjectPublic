using System;
using UnityEngine;

public class CheckpointButton : MonoBehaviour
{
    public int indexCheckpoint;
    private string[] _NumberSceneAndCheckpoint;
    void Awake()
    {
        _NumberSceneAndCheckpoint = PlayerPrefs.GetString("NumberSceneAndCheckpoint").Split('.');
    }
    public void SaveGame()
    {
        PlayerPrefs.SetString( "NumberSceneAndCheckpoint", _NumberSceneAndCheckpoint[0] + '.' + Convert.ToString(indexCheckpoint) );
    }
}
