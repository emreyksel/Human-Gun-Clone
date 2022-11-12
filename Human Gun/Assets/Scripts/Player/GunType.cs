using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunType : MonoBehaviour
{
    public static GunType instance;

    public Gun[] guns = new Gun[4];

    public Transform gunMesh;
    [HideInInspector] public int damage;
    [HideInInspector] public float fireInterval;
    [HideInInspector] public float fireRange;
    public int humanCounter = 1;
    public int currentGun;
 
    private float timer;
    private float effectsDisplayTime = 0.05f;
    private LineRenderer gunLine;

    public GameObject human;

    private void Awake()
    {
        instance = this;
    }

    [System.Obsolete]
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer>=fireInterval && humanCounter>1 && Physics.Raycast(gunMesh.GetChild(currentGun).GetChild(0).position, transform.forward, out RaycastHit info, fireRange))
        {
            Shoot(info);
        }

        if (timer >= fireInterval * effectsDisplayTime)
        {
            DisableEffects();
        }

        #region HUMAN
        
        #endregion
    }

    [Obsolete]
    public void HumanCounter(int value)
    {
        humanCounter += value;
        GunTypeSettings();

        if (humanCounter < 2)
        {
            human.SetActive(true);

            for (int i = 0; i < gunMesh.childCount; i++)
            {
                gunMesh.GetChild(i).gameObject.SetActive(false);
            }

            if (humanCounter < 1)
            {
                int count = gunMesh.GetChild(currentGun).childCount;
                for (int i = 0; i < count; i++)
                {
                    if (gunMesh.GetChild(currentGun).GetChild(0) != null)
                    {
                        GameObject gunPiece = gunMesh.GetChild(currentGun).GetChild(0).gameObject;
                        gunPiece.transform.SetParent(null);
                        gunPiece.transform.DOJump(RandomPos(transform), 1, 2, 1).OnComplete(() =>
                        gunPiece.gameObject.SetActive(false));
                    }
                }

                human.GetComponent<Animator>().SetTrigger("Game Over");
                GameManager.instance.isGameOver = true;

                if (GameManager.instance.isFinish)
                {
                    GameManager.instance.WinPanelActive();
                }
                else
                {
                    GameManager.instance.FailPanelActive();
                }
            }
        }
        else
        {
            human.SetActive(false);
        }
    }

    private void DisableEffects()
    {
        gunLine = gunMesh.GetChild(currentGun).GetComponent<LineRenderer>();
        gunLine.enabled = false;
    }

    [System.Obsolete]
    public void GunTypeSettings()
    {
        if (humanCounter>=2 && humanCounter<4)
        {
            currentGun = 0;
            GunSettings();    
        }
        else if (humanCounter >= 4 && humanCounter < 6)
        {
            currentGun = 1;
            GunSettings();
        }
        else if (humanCounter >= 6 && humanCounter < 8)
        {
            currentGun = 2;
            GunSettings();
        }
        else if (humanCounter >= 8)
        {
            currentGun = 3;
            GunSettings();
        }
    }

    [System.Obsolete]
    public void GunSettings()
    {
        damage = guns[currentGun].damage;
        fireInterval = guns[currentGun].fireInterval;
        fireRange = guns[currentGun].fireRange;

        if (!gunMesh.GetChild(currentGun).gameObject.active)
        {
            for (int i = 0; i < gunMesh.childCount; i++)
            {
                gunMesh.GetChild(i).gameObject.SetActive(false);
            }

            gunMesh.GetChild(currentGun).gameObject.active = true;
        }
    }

    public void Shoot(RaycastHit hitInfo)
    {
        if (hitInfo.collider.TryGetComponent(out IDamageable damageable))
        {
            timer = 0f;

            gunLine = gunMesh.GetChild(currentGun).GetComponent<LineRenderer>();
            gunLine.enabled = true;
            gunLine.SetPosition(0, gunMesh.GetChild(currentGun).GetChild(0).position);
            gunLine.SetPosition(1, hitInfo.point);

            Animator anim = gunMesh.GetChild(currentGun).GetComponent<Animator>();
            anim.SetTrigger("Fire");

            damageable.TakeDamage(damage);
        }      
    }

    private Vector3 RandomPos(Transform gun)
    {
        Vector3 randPos = gun.position + new Vector3(UnityEngine.Random.Range(-1, 1), 0, UnityEngine.Random.Range(-1, 1));
        return randPos;
    }
}
