using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class AnimalLife : ObjectLife
{
    CubeScript cubeScript;
    NavMeshAgent nav;
    public AudioClip clip;
    private AudioSource audio;
    bool isDead = false; // Flag to track if the object is already dead
    private WinCondition winCondition;

    private void Start(){
        audio = gameObject.AddComponent<AudioSource>();
        winCondition = FindObjectOfType<WinCondition>();

    }

    public override void TakeDamage(int damage)
    {
        if (isDead) // Check if the object is already dead
            return;

        Animator animator = GetComponent<Animator>();
        currentHp -= damage;
        if (!audio.isPlaying) // Check if the audio source is not currently playing
        {
            audio.clip = clip;
            audio.Play(); // Play the audio once
        }
        if (currentHp <= 0)
        {
            animator.SetBool("Death", true); // Set the bool parameter in the Animator
            animator.SetBool("WalkForward",false);
            Destroy(gameObject, 7f);
            winCondition.animalsKilled += 1;
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
