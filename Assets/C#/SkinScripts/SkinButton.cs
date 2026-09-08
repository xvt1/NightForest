using UnityEngine;

public class SkinButton : MonoBehaviour
{
    [SerializeField] SkinManager sm;
    public int number;
    public string category;

    public void ChangeSkin()
    {
        sm.setnumber(number);
        sm.setcategory(category);
        sm.ChangeSkin();
    }
}
