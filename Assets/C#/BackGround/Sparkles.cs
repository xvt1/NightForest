using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Sparkles : MonoBehaviour
{
    [Header("Налаштування світла")]
    [SerializeField] private float minIntensity = 0.5f, maxIntensity = 2.0f;
    private float targetIntensity;
    private float lightTimer;

    [Header("Налаштування руху (Тремтіння)")]
    [SerializeField] private float moveRadius = 0.3f; // Макс. відстань від центру
    [SerializeField] private float moveSpeed = 0.5f;   // Швидкість руху

    private Vector3 startPosition; // Центр, куди зірка завжди повертається
    private Vector3 targetPosition; // Поточна точка, куди ми летимо
    private Vector3 currentVelocity; // Потрібно для SmoothDamp
    private Light2D lightComponent;

    void Start()
    {
        startPosition = transform.localPosition;
        targetPosition = startPosition;

        lightComponent = GetComponent<Light2D>();
        SetNewRandomTarget();
    }

    void Update()
    {
        HandleSmoothMovement();
        if (lightComponent != null)
            HandleLight();
    }

    void HandleSmoothMovement()
    {
        // Якщо ми майже дісталися цілі, обираємо нову
        if (Vector3.Distance(transform.localPosition, targetPosition) < 0.01f)
        {
            SetNewRandomTarget();
        }

        // Плавно рухаємо зірку до цілі (SmoothDamp дає дуже м'який рух)
        transform.localPosition = Vector3.SmoothDamp(
            transform.localPosition,
            targetPosition,
            ref currentVelocity,
            1f / moveSpeed
        );
    }

    void SetNewRandomTarget()
    {
        // Обираємо випадкову точку в межах радіуса від початкової позиції
        // Це змушує зірку рухатися в різні боки і завжди повертатися до центру
        Vector2 randomOffset = Random.insideUnitCircle * moveRadius;
        targetPosition = new Vector3(startPosition.x + randomOffset.x, startPosition.y + randomOffset.y, startPosition.z);
    }

    void HandleLight()
    {
        lightTimer -= Time.deltaTime;
        if (lightTimer <= 0)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
            lightTimer = Random.Range(2f, 5f);
        }

        // Плавне мерехтіння
        lightComponent.intensity = Mathf.MoveTowards(lightComponent.intensity, targetIntensity, Time.deltaTime * 2f);
    }
}