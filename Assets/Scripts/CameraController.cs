using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Player Player;
    public float Offset = 2f;

    public static CameraController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        if (Player == null) return;

        if(Player.Launching == true && Player.transform.position.x >= transform.position.x - Offset)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x + Offset, 1f, -10f), Time.deltaTime * 10f);
        }
    }

}
