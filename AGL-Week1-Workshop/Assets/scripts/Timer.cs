using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float init;
    // Start is called before the first frame update
    void Start()
    {
        init = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        text.text = "Time:"+Mathf.RoundToInt(Time.time - init).ToString() ;

    }
}
