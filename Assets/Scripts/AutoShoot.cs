using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : VRShoot
{
    private bool isShooting = false;
    private int currentAmmo; // Munición actual de la pistola
    public int maxAmmo = 30; // Munición máxima de la pistola
    private bool isReloading = false;

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

        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }

        float shootingDuration = 0.05f; // Duration of shooting sound and vibration
        float vibrationDuration = 0.1f; // Duration of vibration after shooting

        yield return new WaitForSeconds(shootingDuration);

        // Stop the shooting sound and vibration after the specified duration
        GetComponent<AudioSource>().Stop();
        OVRInput.Controller controller = grabbable.grabbedBy.GetController();
        OVRInput.SetControllerVibration(0, 0, controller);

        yield return new WaitForSeconds(vibrationDuration - shootingDuration);

        isShooting = false;
    }

    protected override void Reload()
    {
        if (isReloading || isShooting)
            return;

        Vector3 gunEulerAngles = transform.eulerAngles;
        float minAngle = -180f;
        float maxAngle = -80f;

        if (gunEulerAngles.x > minAngle || gunEulerAngles.x < maxAngle)
        {
            StartCoroutine(ReloadWithDelay());
        }
    }  

    private IEnumerator ReloadWithDelay()
    {
        isReloading = true;

        currentAmmo = maxAmmo;

        float reloadDuration = 0.2f; 

        yield return new WaitForSeconds(reloadDuration);

        isReloading = false;
    }
}
