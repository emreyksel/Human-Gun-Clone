using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun",menuName ="Gun")]
public class Gun : ScriptableObject
{
    public GameObject gunPrefab;
    public int damage;
    public float fireInterval;
    public float fireRange;
}
