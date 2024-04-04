using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Health
{
    public int health {get; set;}

    public void TakeDamage(int amountDamage)
    {
        if( health - amountDamage < 0 )
        {
            health -= amountDamage;
        }
        else
        {
            Death();
        }
    }
    private void Death()
    {}
}
