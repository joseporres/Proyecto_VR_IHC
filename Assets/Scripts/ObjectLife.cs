using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLife : MonoBehaviour
{
    [SerializeField]
    protected int maxHp;
    public int currentHp;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;  
    }

    public virtual void TakeDamage(int damage) {}
}
