using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingBossFight : MonoBehaviour
{
    [SerializeField] private GameObject[] gate;
    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.gameObject.CompareTag("Player") )
        {
            foreach( var i in gate )
            {
                i.SetActive(true);
            }
        }
    }
}
