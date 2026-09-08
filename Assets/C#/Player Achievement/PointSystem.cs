using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PointSystem : MonoBehaviour
{
    private int money,moneyinround;

    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Points"))
            money = PlayerPrefs.GetInt("Points");
        else
            PlayerPrefs.SetInt("Points",money);
    }

    private void Update()
    {
        text.text = "Points:" + money;
        PlayerPrefs.SetInt("Points", money);
        PlayerPrefs.Save();
    }

    public void addMoney(int addmoney)
    {
        money += addmoney;
        moneyinround += addmoney;
    }
}
