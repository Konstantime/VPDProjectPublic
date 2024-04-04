using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] public int numberPoint;
    [SerializeField] public int numberNextScene;
    [SerializeField] private GameObject checkpointSetButton;
    [SerializeField] private bool automaticalSave = false;
    private int numberCurrentScene;
    private void Awake()
    {
        if( !PlayerPrefs.HasKey("NumberSceneAndCheckpoint") )
        {
            PlayerPrefs.SetString( "NumberSceneAndCheckpoint", "2.1" );
        }
        else
        {
            numberCurrentScene = SceneManager.GetActiveScene().buildIndex;
        }

        try
        {
            GameObject[] respawns = GameObject.FindGameObjectsWithTag("Respawn");
            CheckPoint[] scriptCheckPoints = new CheckPoint[respawns.Length];
            for( int i = 0; i < scriptCheckPoints.Length; i++ )
            {
                scriptCheckPoints[i] = respawns[i].GetComponent<CheckPoint>();
            }
            for( int i = 0; i < scriptCheckPoints.Length-1; i++ )
            {
                for( int j = i+1; j < scriptCheckPoints.Length; j++ )
                {
                    if( scriptCheckPoints[i].numberPoint == scriptCheckPoints[j].numberPoint )
                    {
                        throw new Exception("Для нескольких чекпоинтов задан один и тот же numberPoint");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Произошло исключение: " + ex.Message);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            if( automaticalSave )
            {
                SaveGame();
            }

            if( checkpointSetButton != null )
            {
                checkpointSetButton.SetActive(true);
                CheckpointButton script = checkpointSetButton.GetComponent<CheckpointButton>();
                script.indexCheckpoint = numberPoint;
            }

            if( numberNextScene != 0 )
            {
                PlayerPrefs.SetString( "NumberSceneAndCheckpoint", Convert.ToString(numberNextScene) + '.' + "1" );
                PlayerPrefs.Save();
                SceneManager.LoadScene( numberNextScene );
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if( checkpointSetButton != null )
            {
                checkpointSetButton.SetActive(false);
            }
        }
    }

    private void SaveGame()
    {
        PlayerPrefs.SetString( "NumberSceneAndCheckpoint", Convert.ToString(numberCurrentScene) + '.' + Convert.ToString(numberPoint) );
        PlayerPrefs.Save();
    }
}
