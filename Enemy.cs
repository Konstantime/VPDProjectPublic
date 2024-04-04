using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speedMovement;
    [SerializeField] protected float timeAttackDelay;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private GameObject explosion;
    private GameObject attackTarget;
    private void FixedUpdate()
    {
        if( attackTarget != null)
        {
            Vector3 direction = attackTarget.transform.position - transform.position;
            direction.Normalize();
            transform.position += direction * speedMovement * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D( Collision2D other )
    {
        if( other.gameObject.CompareTag("Player") )
        {
            explosion.SetActive(true);
            particles.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if( other.gameObject.CompareTag("Player") )
        {
            attackTarget = GameObject.FindGameObjectWithTag("Player");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if( other.gameObject.CompareTag("Player") )
        {
            attackTarget = null;
        }
    }
    public void TakeDamage( int amountDamage )
    {
        Debug.Log("Враг знает об атаке");
        if( health - amountDamage > 0 )
        {
            health -= amountDamage;
        }
        else
        {
            Death();
        }
    }
    private void Death()
    {
        health = 0;
        Destroy(gameObject);
    }
}
