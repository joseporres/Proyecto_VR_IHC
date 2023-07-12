using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDetectionRange : MonoBehaviour
{
    private GameObject[] animals;

    void Start()
    {
        animals = GameObject.FindGameObjectsWithTag("Animal");
        foreach (GameObject animal in animals)
        {
            SphereCollider sphere = animal.AddComponent<SphereCollider>();
            sphere.radius = 5;
            sphere.isTrigger = true;
        }
    }
}