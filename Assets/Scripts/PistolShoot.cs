using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : VRShoot
{
    void Awake() {
        maxAmmo = 10;
    }

    protected override void Shoot()
    {
        Animator animator = simpleShoot.GetAnimator();
        OVRInput.Controller controller = grabbable.grabbedBy.GetController();

        if (OVRInput.GetDown(shootButton, controller) && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && 
            !animator.IsInTransition(0) && currentAmmo > 0 && 
            !isShooting &&
            !isReloading)
        {
            StartCoroutine(ShootWithDelay());
            OVRInput.SetControllerVibration(frequency, amplitude, controller);
            isShooting = true;
        } else if(OVRInput.GetDown(shootButton, controller) && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && 
            !animator.IsInTransition(0) && currentAmmo == 0 && 
            !isShooting &&
            !isReloading){
            AudioSource audioSource = GetComponent<AudioSource>();
            if (!audioSource.isPlaying) {
                audioSource.clip = noAmmoSound;
                audioSource.Play();
            }
        }
    }

    protected override void SetAmmoTransform() {
        RectTransform rectTransform = textMeshPro.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0.05f, 0.03f, -0.05f);
        rectTransform.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
