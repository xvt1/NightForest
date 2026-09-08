using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject[] btns;

    [SerializeField] private bool isStart;

    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private bool isPause;

    [SerializeField] private AudioSource sound;

    [SerializeField] private Animator animPlayer;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isStart)
        {
            Pause();
            pauseMenu.SetActive(true);
        }
    }

    public void Play()
    {
        isStart = true;
        animPlayer.SetBool("isStart", true);
        SpawnerTest spawner;
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].GetComponent<Button>().enabled = false;
            btns[i].GetComponent<Animator>().enabled = false;
        }

    }

    public void ShowOff()
    {
        gameObject.SetActive(false);
    }

    public void ShowOn()
    {
        gameObject.SetActive(true);
    }

    public void LoadScene(int i)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(i);
    }

    public void Pause()
    {
        isPause = !isPause;
        isStart = !isStart;
        if (isPause)
        {
            Time.timeScale = 0f;
            animPlayer.SetBool("isStart", false);
        }
        else
        {
            Time.timeScale = 1.0f;
            animPlayer.SetBool("isStart", true);
        }

    }

    public void Exit()
    {
        Application.Quit();
    }

    public bool GetStart()
    {
        return isStart;
    }

    public void SetStart(bool a)
    {
        isStart=a;
    }
        
}
