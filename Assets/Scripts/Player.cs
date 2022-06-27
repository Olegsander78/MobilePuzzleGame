using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D Rig;
    public bool Launching;

    private void Awake()
    {
        Rig.isKinematic = true;
    }

    private void Update()
    {
        if(Launching && Rig.IsSleeping())
        {
            //next player
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction)
    {
        Rig.isKinematic = false;
        Rig.AddForce(direction * 5, ForceMode2D.Impulse);
        Launching = true;
    }

}
