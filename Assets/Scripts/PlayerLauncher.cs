using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    public Transform PlayerStartPos;
    public Player Player;
    private bool _holdingPlayer;

    private Camera _cam;

    public static PlayerLauncher Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        if (Player == null) return;

        if (InputDown() && Player.Launching == false)
        {
            Vector3 touchWorldPos;

            if (Input.touchCount > 0)
            {
                touchWorldPos = _cam.ScreenToWorldPoint(Input.touches[0].position);
            }
            else
            {
                touchWorldPos = _cam.ScreenToWorldPoint(Input.mousePosition);
            }

            touchWorldPos.z = 0f;

            if (Vector3.Distance(touchWorldPos, Player.transform.position) <= 3f)
            {
                _holdingPlayer = true;
            }
        }

        if(InputUp()&& _holdingPlayer == true)
        {
            _holdingPlayer = false;
            Player.Launch(PlayerStartPos.position - Player.transform.position);
        }

        if(_holdingPlayer && Player.Launching == false)
        {
            Vector3 newPos;

            if (Input.touchCount > 0)
            {
                newPos = _cam.ScreenToWorldPoint(Input.touches[0].position);
            }
            else
            {
                newPos = _cam.ScreenToWorldPoint(Input.mousePosition);
            }

            newPos.z = 0f;
            Player.transform.position = newPos;
        }
    }

    private bool InputDown()
    {
        if(Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began)
        {
            return true;
        }else if (Input.GetMouseButtonDown(0))
        {
            return true;
        }

        return false;
    }

    private bool InputUp()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            return true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            return true;
        }

        return false;
    }

    public void SetNewPlayer(GameObject playerPrefab)
    {
        Player = Instantiate(playerPrefab, PlayerStartPos.position, Quaternion.identity).GetComponent<Player>();
        CameraController.Instance.SetPlayer(Player);
    }
}
