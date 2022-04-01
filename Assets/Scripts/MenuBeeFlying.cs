using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBeeFlying : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject cake;
    [SerializeField] private float speed = 1.0f;
    void Start()
    {
        //Target is location of cake/target
        cake = GameObject.Find("Cake");
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, cake.transform.position, step);

        if (gameObject.transform.position == cake.transform.position)
        {
            Destroy(this.gameObject);
        }
    }
}
