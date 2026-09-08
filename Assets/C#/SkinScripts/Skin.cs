using UnityEngine;

public class Skin : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private string category;
    [SerializeField] private bool enabled;
    [SerializeField] private int saveenbled;

    private void Start()
    {
        
        if (PlayerPrefs.HasKey(name)){
            saveenbled = PlayerPrefs.GetInt(name);
        }
        else{
            PlayerPrefs.SetInt(name, saveenbled);
        }


        if (saveenbled == 1)
        {
            enabled = true;
        }
        else if (saveenbled == 0)
        {
            enabled = false;
        }
        else if (saveenbled > 1 || saveenbled < 0)
        {
            saveenbled = 0;
        }
    }

    private void Update()
    {
        if (enabled)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public string CategoryName(){return category;}

    public bool Enabled(){return enabled;}

    public void Switch(bool i){enabled = i; savestatus(); }

    public void savestatus()
    {
        if (enabled)
        {
            saveenbled = 1;
        }
        else if (!enabled)
        {
            saveenbled = 0;
        }
        PlayerPrefs.SetInt(name, saveenbled);
        PlayerPrefs.Save();
    }
}
