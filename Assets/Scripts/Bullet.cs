using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision){
        if (collision.transform.CompareTag("Animal")){
            collision.gameObject.GetComponent<AnimalLife>().TakeDamage(10);
            Destroy(gameObject);
        }
    }

}
