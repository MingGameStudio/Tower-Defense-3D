using UnityEngine;

public class CastleController : MonoBehaviour
{
    public int maxHealth = 10;

    public int CurrentHealth { get; private set; }

    void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void DealDamage(int damage)
    {
        if (damage <= 0 || CurrentHealth <= 0)
        {
            return;
        }

        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);

        if (CurrentHealth == 0)
        {
            Debug.Log("Castle destroyed");
        }
    }
}
