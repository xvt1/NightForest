using UnityEngine;

public class LoadSkin : MonoBehaviour
{
    [SerializeField] private Skin[] skins;

    private void Start()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            if(skins[i] != null)
            {
                if (PlayerPrefs.HasKey(skins[i].name))
                {
                    int e = PlayerPrefs.GetInt(skins[i].name);

                    if (e == 0)
                    {
                        skins[i].enabled = false;
                    }
                    else if (e == 1)    
                    {
                        skins[i].enabled = true;
                    }
                }
            }
        }
    }

    private void Update()
    {
        
    }
}
