using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Stone : Obstacle,IDamageable
{
    public StoneState stoneState;
    private GameObject player;
    public TextMeshProUGUI healthText;
    public GameObject prize;
    private GameObject clonePrize;

    public int health;

    public enum StoneState
    {
        InGame,
        EndGame
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").gameObject;
    }

    private void Start()
    {
        healthText.text = health.ToString();

        if (prize != null)
        {
            clonePrize = Instantiate(prize, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }

    public int Health 
    { 
        get => health; 
        set => health = value; 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = health.ToString();

        if (health <= 0)
        {
            if (prize != null)
            {
                if (stoneState == StoneState.InGame)
                {
                    clonePrize.transform.DOJump(transform.position + new Vector3(0, -0.4f, 2), 1, 1, 0.5f);
                }
                else if (stoneState == StoneState.EndGame)
                {
                    clonePrize.transform.DOJump(player.transform.position, 1, 1, 0.5f);
                }               
            }
            gameObject.SetActive(false);
        }
    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (once)
        {
            once = false;
            Camera.main.DOShakeRotation(1.5f, 4, fadeOut: true);
            Crash(-GunType.instance.humanCounter);
            GameManager.instance.isGameOver = true;

            if (stoneState == StoneState.InGame)
            {
                GameManager.instance.FailPanelActive();
            }
            else if (stoneState == StoneState.EndGame)
            {
                GameManager.instance.WinPanelActive();
            }           
        }
    }
}
