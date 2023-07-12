using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalLife : ObjectLife
{
    CubeScript cubeScript;
    NavMeshAgent nav;
    bool isDead = false; // Flag to track if the object is already dead

    public override void TakeDamage(int damage)
    {
        if (isDead) // Check if the object is already dead
            return;

        Animator animator = GetComponent<Animator>();
        currentHp -= damage;
        if (currentHp <= 0)
        {
            animator.SetBool("Death", true); // Set the bool parameter in the Animator
            animator.SetBool("WalkForward",false);
            Destroy(gameObject, 30f);
            DisableMovement();
            isDead = true; // Flag the object as dead
        }
    }

    private void DisableMovement()
    {
        cubeScript = GetComponent<CubeScript>();
        cubeScript.enabled = false; // Disable the CubeScript component to stop movement
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = false;
    }
}
