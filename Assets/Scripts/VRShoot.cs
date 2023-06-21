using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VRShoot : MonoBehaviour
{
    public SimpleShoot simpleShoot;
    public OVRInput.Button shootButton;

    protected OVRGrabbable grabbable;
    protected AudioSource audioShoot;

    protected int currentAmmo;
    protected int maxAmmo;

    protected bool isShooting = false;
    protected bool isReloading = false;

    protected GameObject textObject;
    protected TextMeshPro textMeshPro;

    protected float frequency = 0.05f;
    protected float amplitude = 1f;

    public AudioClip shootSound;
    public AudioClip reloadSound;

    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        audioShoot = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
        shootSound = audioShoot.clip;
        SetAmmoDisplay();
    }

    protected virtual void SetAmmoTransform() {}

    void SetAmmoDisplay() {
        textObject = new GameObject();
        textMeshPro = textObject.AddComponent<TextMeshPro>();
        textMeshPro.text = currentAmmo.ToString();
        textMeshPro.fontSize = 0.4f;
        textMeshPro.alignment = TextAlignmentOptions.Center;
        textMeshPro.color = Color.white;

        GameObject canvasObj = new GameObject("Canvas");
        canvasObj.transform.SetParent(transform);
        canvasObj.transform.localPosition = Vector3.zero;
        canvasObj.transform.localRotation = Quaternion.identity;
        canvasObj.transform.localScale = Vector3.one;
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        canvasObj.AddComponent<RectTransform>();
        textMeshPro.transform.SetParent(canvas.transform);

        SetAmmoTransform();
    }

    IEnumerator ReloadWithDelay() {
        isReloading = true;

        currentAmmo = maxAmmo;
        textMeshPro.text = currentAmmo.ToString();

        float reloadDuration = 0.1f; 

        yield return new WaitForSeconds(reloadDuration);

        isReloading = false;
    }

    void Reload()
    {
        if (isReloading || isShooting)
            return;

        Vector3 gunEulerAngles = transform.eulerAngles;
        float minAngle = 75f;
        float maxAngle = 285f;

        AudioSource audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying) {
            audioSource.clip = reloadSound;
            audioSource.Play();
        }

        if (gunEulerAngles.z > minAngle && gunEulerAngles.z < maxAngle && currentAmmo < maxAmmo)
        {
            StartCoroutine(ReloadWithDelay());
        }
    }  

    protected IEnumerator ShootWithDelay()
    {
        currentAmmo--;
        textMeshPro.text = currentAmmo.ToString();
        simpleShoot.StartShoot();

        AudioSource audioSource = GetComponent<AudioSource>();

        if (!audioSource.isPlaying) {
            audioSource.clip = shootSound;
            audioSource.Play();
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

    protected virtual void Shoot() {}
    
    void Update() {
        if (grabbable.grabbedBy && grabbable.isGrabbed) {
            textObject.SetActive(true);
            Shoot();
            Reload();
        }
        else {
            textObject.SetActive(false);
        }
    }
}
