using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Team monsterTeam;

    [SerializeField]
    private Character[] monsterPrefabs;

	[SerializeField]
	private string levelId;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static GameManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        EnemyFetcher.Instance.FetchLevel(levelId, SetEnemyTeam);
    }

	private void SetEnemyTeam(LevelData level)
    {
		List<CharacterData> enemies = level.monsters;
		for (int i = 0; i < enemies.Count; i++)
        {
            Character enemyPrefab = GetEnemyPrefab(enemies[i].monsterType);
            Character instance = Instantiate(enemyPrefab);
            instance.SetStats(enemies[i]);
            monsterTeam[i] = instance;
        }
    }

    private Character GetEnemyPrefab(string enemyType)
    {
		EnemyType enemyEnum = (EnemyType)Enum.Parse (typeof(EnemyType), enemyType);
		return monsterPrefabs[(int)enemyEnum];
    }

    public void AttackEnemy(int slot, int attackPoints)
    {
        monsterTeam[slot].ApplyDamage(attackPoints);
    }
}
