using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float LimitTime = 91f;
    public Text TimeText;
    string resultTime = "";
    void Update()
    {
        LimitTime -= Time.deltaTime;
        int b;
        if (LimitTime >= 0)
        {
            if (LimitTime >= 60f)
            {
                b = (int)LimitTime - 60;
                resultTime = (b + 60).ToString();
                Debug.Log(resultTime);
                if (b < 10)
                    TimeText.text = "1 : " + "0" + b;
                else
                    TimeText.text = "1 : " + b;
            }
            else
            {
                b = (int)LimitTime;
                resultTime = b.ToString();
                Debug.Log(resultTime);
                //TimeText.text = b.ToString();
                if (b < 10)
                    TimeText.text = "0 : 0" + b;
                else
                    TimeText.text = "0 : " + b;

            }
        }
        else
        {
            TimeText.text = "시간끝남";
            return;
        }
    }
}