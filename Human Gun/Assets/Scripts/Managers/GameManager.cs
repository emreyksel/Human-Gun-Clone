using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI moneyText;

    public GameObject winPanel;
    public GameObject failPanel;
    public int moneyScore;

    [HideInInspector] public bool isGameStart = false;
    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public bool isFinish = false;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateMoneyScore(int value)
    {
        moneyScore += value;
        moneyText.text = moneyScore.ToString();
    }

    public void WinPanelActive()
    {
        winPanel.SetActive(true);
    }

    public void FailPanelActive()
    {
        failPanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
