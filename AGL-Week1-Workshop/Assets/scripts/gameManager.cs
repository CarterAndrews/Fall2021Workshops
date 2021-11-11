using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public int catCount;
    public TextMeshProUGUI countText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (catCount < 0)
        {
            catCount = FindObjectsOfType<cat>().Length;
            countText.text="Cats Remaining: " + catCount.ToString() ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collectCat()
    {
        print("collect cat");
        catCount--;
        countText.text = "Cats Remaining: " + catCount.ToString();
        if (catCount == 0)
        {
            print("Game over");
            SceneManager.LoadScene("GameOver");
        }
    }
}
