using UnityEngine;
using System;
using System.Collections.Generic;
using Zenject;
using Communication;

public class EnemyFetcher : MonoBehaviour
{
    [Inject]
    private ICommunicationManager communications;

    private static EnemyFetcher instance;

    public static EnemyFetcher Instance
    {
        get
        {
            return instance;
        }
    }

	public void FetchLevel(string levelId, Action<LevelData> onGotEnemies)
    {
		communications.Fetch ("levels/" + levelId, onGotEnemies);
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
}
