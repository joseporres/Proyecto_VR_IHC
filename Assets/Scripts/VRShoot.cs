using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    public SimpleShoot simpleShoot;
    public OVRInput.Button shootButton;

    protected OVRGrabbable grabbable;
    protected AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
       grabbable = GetComponent<OVRGrabbable>();
       audio = GetComponent<AudioSource>();
    }

    protected virtual void Shoot() {}

    void Update() {
        Shoot();
    }
}
