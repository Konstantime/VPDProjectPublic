using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffUI : MonoBehaviour
{
    [SerializeField] private GameObject[] UIButtons;
    [SerializeField] private bool IsOffVelosityPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach( GameObject UIButton in UIButtons )
            {
                UIButton.SetActive(false);
            }
        }
        OffVelosityPlayer( IsOffVelosityPlayer );
    }
    public void OffVelosityPlayer( bool isOffVelosityPlayer )
    {
        // if( isOffVelosityPlayer )
        // {
        //     GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        //     player[0].rb.OffVelosityPlayer;
        // }
    }
}
