using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : ObjectLife
{
    public override void TakeDamage(int damage){
        if (currentHp <= 0 || currentHp - damage <= 0) {
            currentHp = 0;
            // Debug.Log("MORISTE");
            // Debug.Log(SceneTransitionManager.singleton);
            SceneTransitionManager.singleton.GoToSceneAsync(0);
        }
        else {
            currentHp -= damage;
        }
    }
}