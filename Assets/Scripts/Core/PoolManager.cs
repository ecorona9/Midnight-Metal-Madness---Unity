/*
 * Summary:
 * 
 * PoolManager instantiates a set number of
 * projectiles and allows the player to reuse them
 * by setting a projectile active and inactive
 * 
 */
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MidnightMetalMadness
{
    [Serializable]
    public class Pool
    {
        public GameObject projectile;
        public int amount;
        [HideInInspector] public List<GameObject> projectile_list = new List<GameObject>();
    }

    public class PoolManager : MonoBehaviour
    {
        public static PoolManager pool_instance { get; private set; }

        [SerializeField] private List<Pool> pool_list;

        private void Awake()
        {
            pool_instance = this;
        }

        private void Start()
        {
            for (int i = 0; i < pool_list.Count; i++)
            {
                for (int j = 0; j < pool_list[i].amount; j++)
                {
                    GameObject obj = Instantiate(pool_list[i].projectile);
                    obj.SetActive(false);
                    pool_list[i].projectile_list.Add(obj);
                }
            }
        }

        public GameObject GetPooledProjectile(int index)
        {
            for (int i = 0; i < pool_list[index].projectile_list.Count; i++)
            {
                if (!pool_list[index].projectile_list[i].activeInHierarchy)
                {
                    return pool_list[index].projectile_list[i];
                }
            }
            return null;
        }
    }
}
