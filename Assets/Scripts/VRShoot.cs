using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    public SimpleShoot simpleShoot;
    public OVRInput.Button shootButton;

    protected OVRGrabbable grabbable;
    protected AudioSource audioShoot;


    // Start is called before the first frame update
    void Start()
    {
       grabbable = GetComponent<OVRGrabbable>();
       audioShoot = GetComponent<AudioSource>();
    }

    protected virtual void Shoot() {}
    protected virtual void Reload() {}
    
    void Update() {
        Shoot();
        Reload();
    }
}
