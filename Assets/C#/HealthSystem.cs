using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float Health;

    [SerializeField]
    private Slider slider;

    private void Update()
    {
        slider.value = Health;    
    }

    public void Damage(int Damage = 20)
    {
        if (slider  != null)
        {
            Health -= Damage;
        }
    }
}
