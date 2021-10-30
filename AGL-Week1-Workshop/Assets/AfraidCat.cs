using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfraidCat : MonoBehaviour
{
    public Transform player;
    public float visionRadius;   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,player.position) < visionRadius){
		print("Danger close");
	}
    }
}
