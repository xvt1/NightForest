using System;
using UnityEngine;
using UnityEngine.UI;

public class BtnOff : MonoBehaviour
{
    [SerializeField]
    private GameObject[] btns;

    
    public void OffBtn()
    {
        for(int i = 0; i < btns.Length; i++)
        {
            btns[i].GetComponent<Animator>().enabled = false;
        }
    }
    public void OnBtn()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].GetComponent<Animator>().enabled = true;
        }
    }

}
