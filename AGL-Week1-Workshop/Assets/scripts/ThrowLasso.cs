using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLasso : MonoBehaviour
{
    public GameObject lassoPrefab;
    public Transform lassoHandle;
    public Rigidbody2D throwerRb;
    public float throwForce;
    Camera mainCam;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }
    public void Throw()
    {
        GameObject lassoInstance = Instantiate(lassoPrefab, lassoHandle.position, transform.rotation);
        lassoInstance.GetComponent<Lasso>().playerRb = throwerRb;
        Vector3 mousePos=mainCam.ScreenToWorldPoint(Input.mousePosition-new Vector3(0,0,10));
        Vector2 forceDir = (Vector2)mousePos;
        lassoInstance.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        lassoInstance.GetComponent<Rigidbody2D>().AddForce((forceDir-throwerRb.position).normalized*throwForce, ForceMode2D.Impulse);
        SoundManager.Instance.PlayPlayerWhip();
    }
}
