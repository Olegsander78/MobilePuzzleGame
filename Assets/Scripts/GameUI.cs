using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    public GameObject NextPlayerButton;
    public GameObject EndScreen;
    public GameObject WinText;
    public GameObject LoseText;

    public static GameUI Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OnNextPlayerButton()
    {
        GameManager.Instance.SpawnNewPlayer();
        NextPlayerButton.SetActive(false);
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetEndScreen(bool didWin)
    {
        EndScreen.SetActive(true);

        WinText.SetActive(didWin);
        LoseText.SetActive(!didWin);
    }
}
