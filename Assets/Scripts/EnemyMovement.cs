using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int direction = 1; //int direction where 0 is stay, 1 up, -1 down
    private int top = 3;
    private int bottom = -3;

    [SerializeField] private float speed = 5;
    
    private float xspeed = -0.5f;

    [SerializeField]private int health = 1;

    [SerializeField] private GameObject pivot;

    [SerializeField] private GameObject dialogHandler;
    [SerializeField] private DialogHandler dialogscript;
    private SpriteRenderer renderer;

    private GameObject scoreHandler;
    private ScoreHandler scoreScript;

    private int scoreIncrement = 1;
    private void Start()
    {
        pivot = GameObject.Find("Pivot");
        dialogHandler = GameObject.Find("DialogHandler");
        dialogscript = dialogHandler.GetComponent<DialogHandler>();
        scoreHandler = GameObject.Find("ScoreHandler");
        if(this.gameObject.name == "BigEnemy(Clone)")
        {
            //Larger bee slows down, has more health
            health = 5;
            xspeed = -0.2f;
            speed = 2;
            scoreIncrement = 5;
        }
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
       
    }
    void Update()
    {


        if (transform.position.y >= top)
            direction = -1;

        if (transform.position.y <= bottom)
            direction = 1;


        transform.Translate(xspeed * Time.deltaTime, speed * direction * Time.deltaTime, 0);

        if (transform.position.x <= -8.5f)
        {
            DestroyMe();
        }

        //If bee at any point reaches the sling shot
        if (transform.position.x < pivot.transform.position.x)
        {
            dialogscript.enabled=true;
            dialogscript.lose = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "Ball(Clone)")
        {
            health -= 1;

            if (health == 0)
            {
                DestroyMe();
            }
            else
            {
                Debug.Log("HIT");
                StartCoroutine(ChangeAlpha());
            }
        }
        else if(collision.gameObject.tag=="Enemy"){
            Physics.IgnoreCollision(collision.collider.gameObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
        }
    }

    IEnumerator ChangeAlpha()
    {
        //Debug.Log("Made it");
        for(int i = 0; i < 5; i++)
        {
            renderer.color = new Color(1f, 0.9542816f, 0.7028302f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            renderer.color = new Color(1f, 0.9542816f, 0.7028302f, 0.75f);
            yield return new WaitForSeconds(0.1f);
        }
        renderer.color = new Color(1f, 0.9542816f, 0.7028302f, 1f);



    }
    private void DestroyMe()
    {
        scoreScript = scoreHandler.GetComponent<ScoreHandler>();
        scoreScript.AddScore(scoreIncrement);
        scoreScript.SubBee();
        Destroy(this.gameObject);
    }
}