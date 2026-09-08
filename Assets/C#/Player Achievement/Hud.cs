using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    private float recordTime;
    private float timer;
    [SerializeField] private bool isStart = false;

    [SerializeField] private TextMeshProUGUI[] textRecord, textTimer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Record"))
        {
            recordTime = PlayerPrefs.GetFloat("Record");
        }
        else
        {
            PlayerPrefs.SetFloat("Record", recordTime);
        }
    }

    private void Update()
    {
        if (!isStart) return;
        timer += Time.deltaTime;


        if (timer > recordTime)
        {
            recordTime = timer;
            PlayerPrefs.SetFloat("Record", recordTime);
            PlayerPrefs.Save();

        }

        UpdateText();
    }

    private void UpdateText()
    {
        for(int i = 0; i < textRecord.Length; i++)
        {
            textRecord[i].SetText("Record Time: " + Mathf.Round(recordTime));
        }

        for(int i = 0;i < textTimer.Length; i++)
        {
            textTimer[i].SetText("Time: " + Mathf.Round(timer));
        }
    }
}
