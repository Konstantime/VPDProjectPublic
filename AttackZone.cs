using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField] private Player player;
    private int damagePlayer;
    private List<GameObject> touchedEnemys = new List<GameObject>();
    private void OnCollisionEnter2D(Collision2D other)
    {
        if( other.gameObject.CompareTag("Enemy") )
        {
            ReportAnAttack( other.gameObject );
        }
    }
    private void ReportAnAttack( GameObject enemy )
    {
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.TakeDamage( player.GetAmountDamage() );
        player.IncreaceHealth( player.GetAmountDamage() );
    }
    private IEnumerator ActivateObjectWithDelay( GameObject objToActivate, float timeDelay )
    {
        objToActivate.SetActive(true);
        yield return new WaitForSeconds(timeDelay);
        objToActivate.SetActive(false);
    }
}
