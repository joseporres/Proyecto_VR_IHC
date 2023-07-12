using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalWalk : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("WalkForward", true); // Set the bool parameter in the Animator
    }

    void Update()
    {
           
    }
}   
