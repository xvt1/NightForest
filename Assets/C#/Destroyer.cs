using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    private float timer;

    [SerializeField]
    private bool timeron;

    void Update()
    {
        if (!timeron) return;
        if(timer < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timer-= Time.deltaTime;
        }
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
