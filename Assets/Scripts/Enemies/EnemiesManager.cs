using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Ebac.Core.Singleton;
using Enemy;

public class EnemiesManager : Singleton<EnemiesManager>
{
    public UnityEvent OnAllEnemiesDead;

    private List<EnemyBase> enemies = new List<EnemyBase>();

    public void RegisterEnemy(EnemyBase enemy)
    {
        enemies.Add(enemy);
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
