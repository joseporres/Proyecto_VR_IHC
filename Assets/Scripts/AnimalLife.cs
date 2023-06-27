using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalLife : ObjectLife
{
    public override void TakeDamage(int damage){
        currentHp -= damage;
        if(currentHp <= 0){
            Destroy(gameObject);
        }
    }
}
