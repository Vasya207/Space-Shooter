using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] int damage = 10;

    public int GetDamage() { return damage; }

    public void Hit() { Destroy(gameObject); }
}
