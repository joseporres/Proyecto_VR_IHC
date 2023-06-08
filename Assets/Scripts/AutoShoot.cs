using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : VRShoot
{
    private bool isShooting = false;

    protected override void Shoot()
    {
        Animator animator = simpleShoot.GetAnimator();

        if (grabbable.isGrabbed && OVRInput.Get(shootButton, grabbable.grabbedBy.GetController()) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            if (!isShooting)
            {
                StartCoroutine(ShootWithDelay());
                isShooting = true;
            }
        }
    }

    private IEnumerator ShootWithDelay()
    {
        simpleShoot.StartShoot();

        if (!audio.isPlaying)
        {
            audio.Play();
        }

        yield return new WaitForSeconds(0.2f); // Adjust the delay between shots here

        isShooting = false;
    }
}
