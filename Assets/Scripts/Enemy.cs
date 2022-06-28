using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerLauncher.Instance.Player == null) return;

        if(collision.relativeVelocity.magnitude > 2f && PlayerLauncher.Instance.Player.Launching == true)
        {
            GameManager.Instance.DestroyEnemy(this);
        }
    }
}
