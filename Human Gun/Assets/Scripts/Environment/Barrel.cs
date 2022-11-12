using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Barrel : Obstacle,IDamageable
{
    public int health;
    public TextMeshProUGUI healthText;

    public int Health
    {
        get => health;
        set => health = value;
    }

    private void Start()
    {
        healthText.text = health.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = health.ToString();
        if (health<=0)
        {
            Camera.main.DOShakeRotation(1.5f, 4, fadeOut: true);
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
            GameManager.instance.FailPanelActive();
        }
    }
}
