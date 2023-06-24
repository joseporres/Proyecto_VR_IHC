using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : VRShoot
{
    void Awake() {
        maxAmmo = 30;
    }

    protected override void Shoot()
    {
        Animator animator = simpleShoot.GetAnimator();
        OVRInput.Controller controller = grabbable.grabbedBy.GetController();

        if (OVRInput.Get(shootButton, controller) && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && 
            !animator.IsInTransition(0) && currentAmmo > 0 && 
            !isShooting &&
            !isReloading)
        {
            StartCoroutine(ShootWithDelay());
            OVRInput.SetControllerVibration(frequency, amplitude, controller);
            isShooting = true;
        } else if (OVRInput.Get(shootButton, controller) && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && 
            !animator.IsInTransition(0) && currentAmmo == 0 && 
            !isShooting &&
            !isReloading)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (!audioSource.isPlaying) {
                audioSource.clip = noAmmoSound;
                audioSource.Play();
            }

        }
    }

    protected override void SetAmmoTransform() {
        RectTransform rectTransform = textMeshPro.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0.266f,0.505f, -1.15f);
        rectTransform.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
