using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Ebac.Core.Singleton;
using Enemy;
using System.Linq;

public class EnemiesManager : Singleton<EnemiesManager>
{
    public UnityEvent OnAllEnemiesDead;

    private List<EnemyBase> enemies = new List<EnemyBase>();

    private void Start()
    {
        enemies = FindObjectsOfType<EnemyBase>(true).ToList();
    }


    public void EnemyDie(EnemyBase enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
            if (enemies.Count == 0)
            {
                OnAllEnemiesDead?.Invoke();
            }
        }
    }
}
