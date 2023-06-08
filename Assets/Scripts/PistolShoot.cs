using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : VRShoot
{
    protected override void Shoot()
    {
        Animator animator = simpleShoot.GetAnimator();

        if (grabbable.isGrabbed && OVRInput.GetDown(shootButton,grabbable.grabbedBy.GetController()) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0)){
            simpleShoot.StartShoot();
            audio.Play();
        }
        
    }
}
