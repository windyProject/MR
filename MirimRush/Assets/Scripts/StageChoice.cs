using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChoice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageBtnEvent(int a)
    {
        if(a == 1) SceneManager.LoadScene("GameStage1");
        else SceneManager.LoadScene("GameStage2");

    }
}
