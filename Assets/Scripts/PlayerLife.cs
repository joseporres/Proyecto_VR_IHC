using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : ObjectLife
{
    public override void TakeDamage(int damage){
        currentHp -= damage;
        if(currentHp <= 0){
            Debug.Log("MORISTE");
        }
    }
}
