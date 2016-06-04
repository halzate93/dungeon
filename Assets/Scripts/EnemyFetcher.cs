using UnityEngine;
using System;

public class EnemyFetcher : MonoBehaviour
{
    private static EnemyFetcher instance;

    [SerializeField]
    private CharacterData[] enemies;

    public static EnemyFetcher Instance
    {
        get
        {
            return instance;
        }
    }

    public void FetchEnemies(Action<CharacterData[]> onGotEnemies)
    {
        onGotEnemies(enemies);
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
}
