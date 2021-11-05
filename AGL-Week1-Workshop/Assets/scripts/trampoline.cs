using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour
{
    public float launchForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("dog"))
        {

            SoundManager.Instance.PlayTrampolineSound();
            collision.collider.GetComponent<Rigidbody2D>().AddForce(Vector3.up * launchForce);
        }

    }
}
