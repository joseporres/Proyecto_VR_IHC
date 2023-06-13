using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : VRShoot
{
    private bool isShooting = false;

    protected override void Shoot()
    {
        if(grabbable.grabbedBy){
            Animator animator = simpleShoot.GetAnimator();
            OVRInput.Controller controller = grabbable.grabbedBy.GetController();
            float frequency = 0.05f;
            float amplitude = 1f;

            if (grabbable.isGrabbed && OVRInput.Get(shootButton, controller) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            {
                if (!isShooting)
                {
                    StartCoroutine(ShootWithDelay());
                    OVRInput.SetControllerVibration(frequency, amplitude, controller);
                    isShooting = true;
                }
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

        float shootingDuration = 0.05f; // Duration of shooting sound and vibration
        float vibrationDuration = 0.1f; // Duration of vibration after shooting
        float frequency = 0.05f; // Vibration frequency
        float amplitude = 1f; // Vibration intensity

        yield return new WaitForSeconds(shootingDuration);

        // Stop the shooting sound and vibration after the specified duration
        audio.Stop();
        OVRInput.Controller controller = grabbable.grabbedBy.GetController();
        OVRInput.SetControllerVibration(0, 0, controller);

        yield return new WaitForSeconds(vibrationDuration - shootingDuration);

        isShooting = false;
    }
}
