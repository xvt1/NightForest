using System;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 10f;

    [SerializeField] private Menu menu;

    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
    }

    void Update()
    {
        if (!menu.GetStart()) return;
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
    }
}
