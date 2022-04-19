using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]

public class Enemy : ScriptableObject
{
    public string enemyname;
    
    public int health;

}