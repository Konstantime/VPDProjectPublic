using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum Direction
{
    Up,
    Down,
    Right,
    Left
}

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] public float speedHorizontal = 3f;
    [SerializeField] public float jumpFirstPower = 10f;
    [SerializeField] public float jumpSecondPower = 7.5f;
    [SerializeField] private int maxNumberAllowedJumps = 2;
    [SerializeField] private int maxNumberAllowedJerk = 1;
    [SerializeField] private int amountDamage = 20;
    [SerializeField] private GameObject attackZoneAside;
    [SerializeField] private GameObject attackZoneDown;
    [SerializeField] private GameObject[] attackZones;
    private int health = 100;
    private int damage = 20;
    private bool isFlipRight = true;
    private int numberAllowedJumps = 0;
    private float movementHorizontal = 0;
    private void Awake()
    {
        MovePlayerToCheckpoint();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2( movementHorizontal * speedHorizontal, GetComponent<Rigidbody2D>().velocity.y );
    }
    public void Attack( bool isAsideAttack )
    {
        GameObject currentAttackZone = attackZoneAside;
        if( isAsideAttack )
        {
            currentAttackZone = attackZoneAside;
        }
        else
        {
            currentAttackZone = attackZoneDown;
        }
        StartCoroutine(ActivateObjectWithDelay( currentAttackZone, 0.2f ));
    }
    public void IncreaceHealth( int value )
    {
        health += value;
        Debug.Log( "Игрок знает об атаке" );
        Debug.Log("health = " + health);
    }
    public int GetAmountDamage()
    {
        return damage;
    }
    private IEnumerator ActivateObjectWithDelay( GameObject objToActivate, float timeDelay )
    {
        objToActivate.SetActive(true);
        yield return new WaitForSeconds(timeDelay);
        objToActivate.SetActive(false);
    }
    public void setMovementPlayer( bool isDirectionRight )
    {
        if( isDirectionRight )
        {
            if( isFlipRight == false )
            {
                Flip();
            }
            movementHorizontal = speedHorizontal;
        }
        else
        {
            if( isFlipRight == true )
            {
                Flip();
            }
            movementHorizontal = -speedHorizontal;
        }  
    }
    public void removeMovementPlayer()
    {
        movementHorizontal = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            numberAllowedJumps = maxNumberAllowedJumps;
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if( other.gameObject.tag == "Water" )
        {
            speedHorizontal /= 2;
            movementHorizontal = 0;
            Debug.Log("Зашёл в воду");
        }
        else if( other.gameObject.tag == "AttackZone" )
        {
            
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if( other.gameObject.tag == "Water" )
        {
            speedHorizontal *= 2;
            movementHorizontal = 0;
            Debug.Log("Вышел из воды");
        }
    }

    public void Jerk()
    {
        
    }
    public void Jump()
    {
        if( numberAllowedJumps == 2 )
        {
            rb.velocity = new Vector2( rb.velocity.x, 0);
            numberAllowedJumps -= 1;
            rb.AddForce( new Vector2(0, jumpFirstPower), ForceMode2D.Impulse );
        }
        else if( numberAllowedJumps == 1 )
        {
            rb.velocity = new Vector2( rb.velocity.x, 0);
            numberAllowedJumps -= 1;
            rb.AddForce( new Vector2(0, jumpSecondPower + rb.velocity.y/2), ForceMode2D.Impulse );
        }
    }
    private void MovePlayerToCheckpoint()
    {
        string[] _NumberSceneAndCheckpoint = PlayerPrefs.GetString("NumberSceneAndCheckpoint").Split('.');
        
        int indexLastCheckpoint = Convert.ToInt32(_NumberSceneAndCheckpoint[1]);
        GameObject[] respawns = GameObject.FindGameObjectsWithTag("Respawn");
        foreach( GameObject i in respawns )
        {
            CheckPoint scriptCheckPoint = i.GetComponent<CheckPoint>();
            if( scriptCheckPoint.numberPoint == indexLastCheckpoint )
            {
                transform.position = i.transform.position;
            }
        }
    }
    private void Flip()
    {
        isFlipRight = !isFlipRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
