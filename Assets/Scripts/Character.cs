using UnityEngine;

public class Character : MonoBehaviour
{
    private static int MAX_DEFENSE = 100;

    [SerializeField]
    private int lifePoints;

    [SerializeField]
    private int attackPoints;

    [SerializeField]
    private int defensePoints;

    public void ApplyDamage(int damage)
    {
        lifePoints -= (int)(damage * (1 - defensePoints / (float)MAX_DEFENSE));
        Debug.Log(string.Format("{0} was hit, has {1} remaining lifepoints.", gameObject.name, lifePoints));
        if (lifePoints <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " has died.");
        Destroy(gameObject);
    }

    public void SetStats(CharacterData characterData)
    {
        this.lifePoints = characterData.lifePoints;
        this.attackPoints = characterData.attackPoints;
        this.defensePoints = characterData.defensePoints;
    }
}
