using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> AvailablePlayers = new List<GameObject>();
    public List<Enemy> Enemies = new List<Enemy>();

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnNewPlayer();
    }

    public void SpawnNewPlayer()
    {
        PlayerLauncher.Instance.SetNewPlayer(AvailablePlayers[0]);
        AvailablePlayers.RemoveAt(0);
    }

    public void PlayerFinished()
    {
        SpawnNewPlayer();
    }

    public void DestroyEnemy (Enemy enemy)
    {
        Enemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
