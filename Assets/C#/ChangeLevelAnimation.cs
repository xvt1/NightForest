using UnityEngine;
using UnityEngine.UI;

public class ChangeLevelAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator anim1, anim2;

    [SerializeField]
    private Animator menu;



    private void Update()
    {
        
    }

    public void Up()
    {
        menu.SetBool("Show", true);

        anim1.SetBool("up", true);
        anim2.SetBool("down", true);

    }

    public void Down()
    {
        anim1.SetBool("up", false);
        anim2.SetBool("down", false);
    }

    public void MenuBack()
    {
        menu.SetBool("Show", false);
    }
}
