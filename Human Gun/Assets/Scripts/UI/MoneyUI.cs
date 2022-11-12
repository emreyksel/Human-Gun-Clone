using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyUI : MonoBehaviour
{
    private Transform moneyImage;
    [SerializeField] private Ease easeType;
    private const int moneyValue = 80;
    private int counter;

    private void Awake()
    {
        moneyImage = GameObject.FindGameObjectWithTag("MoneyImage").transform;
    }

    private void OnEnable()
    {
        if (counter > 0)
        {
            StartCoroutine(nameof(MoneyMove));
        }
        counter++;
    }

    private IEnumerator MoneyMove()
    {
        transform.DOMove(moneyImage.position, 1).SetEase(easeType).OnComplete(() =>
        {
            GameManager.instance.UpdateMoneyScore(moneyValue);
            ObjectPool.instance.SendPooledObject(0, gameObject);
        });
        yield return null;
    }
}
