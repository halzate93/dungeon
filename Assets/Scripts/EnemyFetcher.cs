using UnityEngine;
using System;
using Zenject;
using Communication;

public class EnemyFetcher : MonoBehaviour
{
    [Inject]
    private ICommunicationManager communications;

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
