using UnityEngine;

public class SpawnerTest : MonoBehaviour
{
    [SerializeField] private float timer;
    private float[] whiteObject,blackObject;
    [SerializeField] private GameObject bObj,wObj;

    [SerializeField]
    private float musicOffset;
    [SerializeField]
    private AudioSource audio;

    private int windex,bindex;

    [SerializeField]
    private Menu menu;

    public bool isStart = false;

    private void Start()
    {
        whiteObject = new float[] { 8, 12, 16, 20, 24, 28, 32, 34, 36, 38, 40, 42, 44, 46, 48, 51, 53, 55, 56, 60, 64, 68, 72, 74, 75, 76, 78, 82, 85, 86, 88, 90, 96, 98, 100, 102, 104, 106, 108, 110, 112, 116, 120, 124 };
        blackObject = new float[] { 18, 22, 26, 30, 33, 33.5f, 37, 37.5f, 41, 41.5f, 45, 45.5f, 49, 49.25f, 49.5f, 52, 52.25f, 54, 57, 57.5f, 66, 67, 67.25f, 70, 73, 74.25f, 77, 77.5f, 84, 84.5f, 87, 87, 89, 90, 91.5f, 92.75f, 94, 97, 97.5f, 101, 101.5f, 105, 105.5f, 109, 109.5f, 114, 115, 118, 119, 122, 126 };
    }

    void Update()
    {
        isStart = menu.GetStart();

        if (!isStart)
        {

            audio.enabled = false;
            return;
        }
        else
        {
            audio.enabled = true;
        }
        if (timer >= musicOffset)
        {
            Spawn();
        }
          

        timer += Time.deltaTime;


    }

    private void Spawn()
    {
        if (windex < whiteObject.Length && timer + musicOffset >= whiteObject[windex])
        {
            Instantiate(wObj, transform.position, Quaternion.identity);
            windex++;
        }

        if (bindex < blackObject.Length && timer + musicOffset >= blackObject[bindex])
        {
            Instantiate(bObj, transform.position, Quaternion.identity);
            bindex++;
        }
    }
}