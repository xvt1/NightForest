using UnityEngine;

public class KnifeAnimation : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private float CoolDown = 1f;
    private float timer = 0;
    [SerializeField]
    private Transform effectPosition;
    [SerializeField]
    private GameObject effect;



    public Collider2D[] attack;

    [SerializeField]
    public int Damage;

    [SerializeField]
    private Transform attackPos;
    [SerializeField]
    private float range;

    [SerializeField]
    private GameObject whiteSound,blackSound;

    private Menu menu;

    [SerializeField]
    private DamageTint tint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!menu.GetStart()) return;

        if(timer <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                AttackAnim();
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void AttackAnim()
    {
        anim.SetBool("attack", true);
        Instantiate(effect, effectPosition.position, Quaternion.identity);
        timer = CoolDown;
    }



    private void SwitchAnim()
    {
        anim.SetBool("attack", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, range);
    }

    int test;

    public void Attack()
    {
        attack = Physics2D.OverlapCircleAll(attackPos.position, range);
        for (int i = 0; i < attack.Length; i++)
        {
            if (i == 0) test = 0;
            if (attack[i].tag == "White")
            {
                Destroy(attack[i].gameObject);
                Instantiate(whiteSound);
                test = 0;
            }
            else if (attack[i].tag == "Black")
            {
                Destroy(attack[i].gameObject);
                Instantiate(blackSound);
                test = 0;
            }
            else
            {
                test++;
            }

            if(test >= attack.Length)
            {
                tint.Tint(Damage);
            }
        }
    }
}
