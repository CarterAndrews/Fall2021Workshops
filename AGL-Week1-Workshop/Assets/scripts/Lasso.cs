using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasso : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public Rigidbody2D lassoRb;
    public float pullForce;
    public LineRenderer ropeRendeder;
    // Start is called before the first frame update
    void Start()
    {
        if (!lassoRb)
        {
            lassoRb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ropeRendeder.SetPosition(0, lassoRb.position);
        ropeRendeder.SetPosition(1, playerRb.position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce((lassoRb.position - playerRb.position).normalized*pullForce,ForceMode2D.Impulse);
        
        
        print(collision.collider.gameObject.name);
        Destroy(gameObject);
    }
}
