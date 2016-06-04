using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Team monsterTeam;

    [SerializeField]
    private Character[] monsterPrefabs;

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
        EnemyFetcher.Instance.FetchEnemies(SetEnemyTeam);
    }

    private void SetEnemyTeam(CharacterData[] enemies)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            Character enemyPrefab = GetEnemyPrefab(enemies[i].monsterType);
            Character instance = Instantiate(enemyPrefab);
            instance.SetStats(enemies[i]);
            monsterTeam[i] = instance;
        }
    }

    private Character GetEnemyPrefab(EnemyType enemyType)
    {
        return monsterPrefabs[(int)enemyType];
    }

    public void AttackEnemy(int slot, int attackPoints)
    {
        monsterTeam[slot].ApplyDamage(attackPoints);
    }
}
