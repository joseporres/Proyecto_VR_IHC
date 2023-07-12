using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : ObjectLife
{
    public override void TakeDamage(int damage){
        if (currentHp <= 0) return;
        if (currentHp - damage <= 0) {
            currentHp = 0;
            Debug.Log("MORISTE");
        }
        else {
            currentHp -= damage;
        }
    }
}
