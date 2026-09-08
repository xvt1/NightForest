using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private GameObject[] skin;

    [SerializeField] private string[] categoryListName;
    [SerializeField] private bool[] categoryList;

    private int number;
    private string category;

    private void Start()
    {
        categoryList = new bool[skin.Length];
    }

    public void setnumber(int i){number = i;}

    public void setcategory(string i){category = i;}

    public void ChangeSkin()
    {
        if (skin[number] != null)
        {
            if (skin[number].GetComponent<Skin>().Enabled())
            {
                skin[number].GetComponent<Skin>().Switch(false);
                categoryList[number] = false;
            }
            else
            {
                for (int i = 0; i < skin.Length; i++)
                {
                    if (skin[i].GetComponent<Skin>().CategoryName() == category && skin[i].GetComponent<Skin>().Enabled() && skin[i] != skin[number])
                    {
                        skin[i].GetComponent<Skin>().Switch(false);
                        categoryList[i] = false;
                    }
                    else
                    {
                        skin[number].GetComponent<Skin>().Switch(true);
                        categoryList[number] = true;
                    }
                }
            }
        }
    }
}
