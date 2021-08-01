using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseControl : MonoBehaviour
{

    Rigidbody2D myBody;
    [SerializeField] float speed;

    Animator horseanim;


    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();

        myBody.velocity = new Vector2(0, speed * Time.deltaTime);

        horseanim = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Arrow"))
        {
            horseanim.SetTrigger("Shot");
        }


    }

}
