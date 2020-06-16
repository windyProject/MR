using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoard : MonoBehaviour
{
    string word = null;
    int wordIndex = 0;
    string alpha;
    public Text myName = null;

    public void alphabetFunction(string alphabet)
    {
        wordIndex++;
        word = word + alphabet;
        myName.text = word;
    }

    public void DeleteFunction()
    {
        if (wordIndex != 0)
        {
            wordIndex--;
            word = myName.text.Substring(0, wordIndex);
            myName.text = myName.text.Substring(0, wordIndex);
        }
    }

    public void EnterFunction()
    {
        Debug.Log("Enter");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
