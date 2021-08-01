using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helman : MonoBehaviour
{
    //Karakter haraket değişkenlerini tanımlama.
    Rigidbody2D myBody;
    public bool up = true;
    [SerializeField] float upSpeed;

    //Karakterin ateş etme değişkenlerinin tanımlanması.
    public GameObject arm;
    public GameObject arrow;
    public float arrowSpeed;
    public bool fire;
    private Animator myAnimator;

    //Ray işlemleri
    private float with;
    [SerializeField] LayerMask engel;
    public bool onWall;

    //Ses işlemleri
    SoundsController mySounds;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myBody.velocity = new Vector2(0, upSpeed);

        
        myAnimator = GetComponent<Animator>();

        with = GetComponent<SpriteRenderer>().bounds.extents.y;//karakterin karesinin yarısı

        mySounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundsController>();

    }

    
    void Update()
    {

        Fire();
       // Flip();

    }



    public void Fire()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            myAnimator.SetTrigger("Attack");
            Invoke("FireMechanical", 0.5f);

            mySounds.ArrowShot();

        }

        

    }


    public void FireMechanical()
    {
        GameObject arrows = Instantiate(arrow, arm.transform.position , Quaternion.identity);
        arrows.transform.parent = GameObject.Find("ArrowBag").transform;

        arrows.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowSpeed * Time.deltaTime, 0);


    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Vector3 playerRealPosition = transform.position + (transform.right);
        Gizmos.DrawLine(playerRealPosition, playerRealPosition + new Vector3(-3f, 0, 0));

    }

    public void Flip()//Helmanın raycasthit ile belli bir alanda sağ ve sola gitme işlemi.
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (transform.right), Vector2.left, 3f, engel);

        if(hit.collider != null)
        {
            onWall = true;
            
        }

        else
        {
            onWall = false;
        }

        if (!onWall)
        {
            Debug.Log(upSpeed);
            upSpeed = -50;
        }

        

        myBody.velocity = new Vector2(0f, transform.up.y * upSpeed * Time.deltaTime);

    }


}
