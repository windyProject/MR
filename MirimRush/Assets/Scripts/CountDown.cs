using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    private float timer;
    public float onetime;
    public GameObject[] num;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        for (int i = 0; i < 5; i++)
            num[i].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (timer == 0)
            Time.timeScale = 0.0f;

        if (timer <= onetime * 5)
        {
            if (timer >= onetime)
                num[(int)timer / (int)onetime - 1].SetActive(false);
            if (timer < onetime * 5)
                num[(int)timer / (int)onetime].SetActive(true);
            timer++;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
