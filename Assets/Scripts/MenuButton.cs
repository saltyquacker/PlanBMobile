using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject btnPlay;
    [SerializeField] private GameObject btnInstructions;
    [SerializeField] private GameObject btnBack;
    [SerializeField] private GameObject instructionPopup;

    public void Start()
    {
        btnPlay = GameObject.Find("btnPlay");
        btnInstructions = GameObject.Find("btnInstructions");
        btnBack = GameObject.Find("btnBack");
        instructionPopup = GameObject.Find("Instructions");

        instructionPopup.SetActive(false);
        btnBack.SetActive(false);
    }
    public void onClickPlay()
    {
        
        SceneManager.LoadScene("Game");
    }

    public void onClickShowInstructions()
    {
        instructionPopup.SetActive(true);
        btnBack.SetActive(true);

        btnPlay.SetActive(false);
        btnInstructions.SetActive(false);
    }

    public void onClickHideInstructions()
    {
        instructionPopup.SetActive(false);
        btnBack.SetActive(false);

        btnPlay.SetActive(true);
        btnInstructions.SetActive(true);
    }
}
