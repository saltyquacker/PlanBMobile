using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class IndividualBall : MonoBehaviour
{
    [SerializeField] private SpringJoint2D thisSpring;
    [SerializeField] private Animation waterSplash;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer spriteRend;
    [SerializeField] private CircleCollider2D collider;
    [SerializeField] private Rigidbody2D rigidbody;
    // Start is called before the first frame update

    private bool inAir = false;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //Only wiggles while in the air
        if (thisSpring.enabled==false&&inAir ==false)
        {
            inAir = true;    
            anim.enabled = true;
            anim.Play("BalloonWiggle");
        }
       
    }

    //Destroy Ball after certain amount of time
    //Prevents overload of clones
    //Cleanup Crew
    IEnumerator DestroyOldBall()
    {
        //collider.enabled = false;
      
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(0.3f);
        
        Debug.Log("Destroying...");
        Destroy(this.gameObject);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.gameObject.name);
        inAir = false;
        waterSplash.enabled = true;
        anim.Play("WaterSplash");
        StartCoroutine(DestroyOldBall());
        

    }
}
