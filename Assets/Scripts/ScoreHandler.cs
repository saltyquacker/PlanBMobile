using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreHandler : MonoBehaviour
{
    public int score;
    public int beesLeft; //Win game by killing all the bees

    public int beeMax = 100;
    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtBeesLeft;

    [SerializeField] private GameObject dialogHandler;
    [SerializeField] private DialogHandler dialogscript;

    // Start is called before the first frame update
    void Start()
    {
        dialogHandler = GameObject.Find("DialogHandler");
        dialogscript = dialogHandler.GetComponent<DialogHandler>();
        beesLeft = beeMax;
        score = 0;
        txtScore.text = "Score: " + score.ToString();
        txtBeesLeft.text = "Bees Left: " + beesLeft.ToString();
    }

    private void Update()
    {
        //Check to see if there are any bees left
        GameObject[] bees = GameObject.FindGameObjectsWithTag("Enemy");
        if(bees.Length==0&& beesLeft == 0)
        {
            dialogscript.enabled=true;
            dialogscript.win = true;
        }
    }
    public void AddScore(int i)
    {

        score += i;
        txtScore.text ="Score: "+score.ToString();
    }

    public void SubBee()
    {
        if (beesLeft > 0)
        {
            beesLeft -= 1;
            txtBeesLeft.text = "Bees Left: " + beesLeft.ToString();
        }
        else
        {

        }
       
    }


}
