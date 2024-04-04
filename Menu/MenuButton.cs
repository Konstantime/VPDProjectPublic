using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private int[] NumberSceneAndCheckpoint = new int[2];
    void Awake()
    {
        if( PlayerPrefs.HasKey("NumberSceneAndCheckpoint") )
        {
            string[] _NumberSceneAndCheckpoint = PlayerPrefs.GetString("NumberSceneAndCheckpoint").Split('.');
            for( int i = 0; i < _NumberSceneAndCheckpoint.Length; i++)
            {
                NumberSceneAndCheckpoint[i] = Convert.ToInt32(_NumberSceneAndCheckpoint[i]);
            }
        }
        else
        {
            NumberSceneAndCheckpoint[0] = 2;
            NumberSceneAndCheckpoint[1] = 1;
            PlayerPrefs.SetString( "NumberSceneAndCheckpoint", "2.1" );
        }
    }
    public void GoToLevels()
    {
        Debug.Log( NumberSceneAndCheckpoint[0] );
        SceneManager.LoadScene( NumberSceneAndCheckpoint[0] );
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene( 0 );
    }

    public void GoToSelectedScene( int numberScenes )
    {
        SceneManager.LoadScene( numberScenes );
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void DeleteAllSave()
    {
        PlayerPrefs.DeleteAll();
    }

}
