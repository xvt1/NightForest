using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private float speed;
    private float livetime = 5f;

    private void Update()
    {
        transform.position -= new Vector3(speed, 0,0) * Time.deltaTime;

        if(livetime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            livetime -= Time.deltaTime; 
        }
    }
    
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
