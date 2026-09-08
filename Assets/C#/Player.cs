using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private DamageTint tint;

    [SerializeField]
    private float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Black" || collision.tag == "White")
        {
            tint.Tint(Damage);
        }

    }
}
