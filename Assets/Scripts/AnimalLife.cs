using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalLife : ObjectLife
{


    public override void TakeDamage(int damage)
    {
        Animator animator= GetComponent<Animator>();
        currentHp -= damage;
        if (currentHp <= 0)
        {
            animator.SetBool("Death", true); // Set the bool parameter in the Animator
            Destroy(gameObject, 1f);
//            DisableMovement();
        }
    }

    private void DisableMovement()
    {
        CubeScript cubeScript = GetComponent<CubeScript>();
        cubeScript.enabled = false; // Disable the CubeScript component to stop movement
    
    }
}
