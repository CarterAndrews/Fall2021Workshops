using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public GameObject lassoPrefab;
    public Transform lassoHandle;
    public Rigidbody2D throwerRb;
    public float throwForce;
    Camera mainCam;
    public bool swinging;
    public Vector2 swingCenter;
    public LineRenderer lr;
    public LayerMask swingable;
    public float swingSpeed;
    public bool swingingRight;
    public Transform indicator;
    public float endPointSpeed;
    public float endPointPos;
    public float groundedSwingForce;
    public float maxRange;
    public DogMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            StopSwing();
            return;
        }
        if (swinging)
        {
            lr.SetPosition(0, throwerRb.position);

            //lr.SetPosition(1, throwerRb.position+ Mathf.Clamp01(endPointPos+endPointSpeed*Time.deltaTime)*(throwerRb.position-swingCenter));
            endPointPos = Mathf.Clamp01(endPointPos + endPointSpeed * Time.deltaTime);
            lr.SetPosition(1, throwerRb.position + -endPointPos * (throwerRb.position - swingCenter));
        }
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition - new Vector3(0, 0, 10));
        Vector2 forceDir = (Vector2)mousePos;
        RaycastHit2D hit=Physics2D.Raycast(throwerRb.position, forceDir - throwerRb.position,maxRange,swingable);

        if (hit.point == Vector2.zero)
        {
            indicator.gameObject.SetActive(false);
            return;
        }
        indicator.gameObject.SetActive(true);
        indicator.position = new Vector3(hit.point.x, hit.point.y, indicator.position.z);
        if (Input.GetButtonDown("Fire1"))
        {
            if (movement.getGrounded())
            {
                throwerRb.velocity = Vector3.zero;
                throwerRb.AddForce((hit.point - throwerRb.position).normalized * groundedSwingForce, ForceMode2D.Impulse);
            }
            else
            {
                swingCenter = hit.point;
                StartSwing();
            }
        }

    }
    private void FixedUpdate()
    {
        if (swinging)
        {
            transform.up = (swingCenter - (Vector2)transform.position).normalized;
            if (Input.GetAxis("Horizontal") > 0)
                swingingRight = true;
            if (Input.GetAxis("Horizontal") < 0)
                swingingRight = false;
            if (swingingRight)
                throwerRb.velocity = transform.right*swingSpeed;
            else
                throwerRb.velocity = -transform.right * swingSpeed;
        
            
        }
    }
    private void LateUpdate()
    {
        
    }
    public void StartSwing()
    {
        lr.SetPosition(0, throwerRb.position);
        endPointPos = 0;
        lr.SetPosition(1, throwerRb.position);
        lr.enabled = true;
        swinging = true;
        //endPointPos = 0;
        //swingSpeed = throwerRb.velocity.magnitude;
        throwerRb.gravityScale = 0;
        swingingRight = swingCenter.x > transform.position.x;
        SoundManager.Instance.PlayPlayerWhip();
    }
    public void StopSwing()
    {
        swinging = false;
        lr.enabled = false;
        transform.up = Vector3.up;
        throwerRb.gravityScale = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopSwing();


    }
}
