using System.Collections;        // <- для IEnumerator
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;              // <- для Volume
using UnityEngine.Rendering.Universal;

public class DamageTint : MonoBehaviour
{
    public Volume volume;
    private ColorAdjustments colorAdjustments;

    public GameObject ShakeFX;
    public float shakeDur;

    [SerializeField]
    private float offset, offsetstart;

    [SerializeField]
    private HealthSystem health;

    void Start()
    {
        offset = offsetstart;
        volume.profile.TryGet(out colorAdjustments);

        ShakeFX.SetActive(false);
    }

    private void Update()
    {
        if (offset > 0)
        {
            offset -= Time.deltaTime;
        }
    }

    public IEnumerator DipExposure(float dipValue = -3f, float duration = 0.7f)
    {
        colorAdjustments.postExposure.value = dipValue;

        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            colorAdjustments.postExposure.value = Mathf.Lerp(dipValue, 0f, t / duration);
            yield return null;
        }

        colorAdjustments.postExposure.value = 0f;
    }

    IEnumerator Shake(float t)
    {
        ShakeFX.SetActive(true);
        yield return new WaitForSeconds(t);
        ShakeFX.SetActive(false);
    }

    public void Tint(float Damage = 10)
    {
        if (offset > 0) return;
        StartCoroutine(DipExposure());
        StartCoroutine(Shake(shakeDur));

        health.Damage(10);

        offset = offsetstart;
    }
}
