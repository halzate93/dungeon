using UnityEngine;
 
public class Team : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;

    private Character[] characters;

    public Character this [int position]
    {
        get
        {
            return characters[position];
        }

        set
        {
            characters[position] = value;
            value.transform.SetParent(positions[position], false);
        }
    }

    private void Awake()
    {
        characters = new Character[positions.Length];
    }
}
