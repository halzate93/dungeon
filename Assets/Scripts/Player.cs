using UnityEngine;

public class Player : MonoBehaviour
{ 
    [SerializeField]
    private int attackPoints;

    public void AttackEnemy(int slot)
    {
        GameManager.Instance.AttackEnemy(slot, attackPoints);
    }
}
