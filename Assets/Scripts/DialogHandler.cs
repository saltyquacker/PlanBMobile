using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class DialogHandler : MonoBehaviour
{
    [SerializeField] private Text txtDialog;
    [SerializeField] private Text tapContinue;

    [SerializeField] private GameObject EnemyScript;
    [SerializeField] private GameObject BalloonScript;
    [SerializeField] private GameObject DialogBoxes;
    private List<string> dialogList = new List<string> { "Woah is that free cake!? I love free cake...","Wait a minute! No bees invited!? How DARE they!!","Skip Plan A, go straight to Plan B...","We're blowing that cake up so NO ONE gets any! Not even the Birthday Kid.","We won't stop until theres none of us left!","Dodge the water balloons! Get past that sling shot!","Bees... ATTACK!!!!!"};
    private List<string> winDialog = new List<string> { "No way...", "How...did you...wipe out my entire hive!?", "Hopefully Karma gets you. Eat your damn cake and enjoy it." };
    private List<string> loseDialog = new List<string> { "...","HAHA..","No cake for anyone!", "Maybe invite the bees next time HUH!?", "Pathetic..." };


    public bool lose = false;
    public bool win = false;
    private bool begin = true;
    [SerializeField]private int thisDialogLength = 0;
    [SerializeField]private int incrementDialog;
    private bool nexti=true;


    void Start()
    {
        incrementDialog = 0;
     
        
        BalloonScript.SetActive(false);
        DialogBoxes.SetActive(true);
        txtDialog.enabled = true;
        tapContinue.enabled = true;
    }


    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
    private void Update()
    {
  

            BalloonScript.SetActive(false);
            if (incrementDialog == 0)
            {
            txtDialog.enabled = true;
            tapContinue.enabled = true;
            DialogBoxes.SetActive(true);
                if (begin == true)
                {
                    txtDialog.text = dialogList[incrementDialog];
                    thisDialogLength = dialogList.Count;
                }
                else if (lose == true)
                {
       

                    txtDialog.text = loseDialog[incrementDialog];
                    thisDialogLength = loseDialog.Count;
                if (Touch.activeTouches.Count == 1)
                {
                    OnDisable();
                }
                
                }
                else if (win == true)
                {
                    txtDialog.text = winDialog[incrementDialog];
                    thisDialogLength = winDialog.Count;
                   
                }
                OnEnable();
                nexti = true;
            }
            if (Touch.activeTouches.Count == 1 && nexti == true)
            {
                if (incrementDialog < thisDialogLength - 1)
                {
                    tapContinue.enabled = false;
                    nexti = false;

                    StartCoroutine(nextDialog());
                }
                else
                {
                    if (lose == true || win == true)
                    {
                        ResetGame();
                    }
                    else
                    {
                        StartCoroutine(CloseDialogStartGame());
                    }
                }
            }
           
            }
        
        
    


    IEnumerator nextDialog()
    {
        
        incrementDialog += 1;
        tapContinue.text = "Tap to continue...";
        if (begin == true)
        {


            txtDialog.text = dialogList[incrementDialog];
            yield return new WaitForSeconds(1);
            nexti = true;
            if (incrementDialog == dialogList.Count - 1)
            {
                tapContinue.text = "Tap to start!";
            }

        }
        else if(lose==true)
        {
            txtDialog.text = loseDialog[incrementDialog];
            yield return new WaitForSeconds(1);
            nexti = true;
            if (incrementDialog == loseDialog.Count - 1)
            {
                tapContinue.text = "Tap to play again!";
            }
        }
        else if (win == true)
        {
            txtDialog.text = winDialog[incrementDialog];
            yield return new WaitForSeconds(1);
            nexti = true;
            if (incrementDialog == winDialog.Count - 1)
            {
                tapContinue.text = "Tap to play again!";
            }
           
        }

        tapContinue.enabled = true;

    }

    IEnumerator CloseDialogStartGame()
    {
       
        begin = false;
        DialogBoxes.SetActive(false);
        txtDialog.enabled = false;
        tapContinue.enabled = false;
        
        yield return new WaitForSeconds(1f);

        EnemyScript.SetActive(true);
        BalloonScript.SetActive(true);

        incrementDialog = 0;
        this.enabled = false;
    }

    void ResetGame()
    {
        Debug.Log("RESET!!!");
        SceneManager.LoadScene("Menu");
    }


}
