using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreHandler : MonoBehaviour
{
    public int score;
    [SerializeField] private Text txtScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        txtScore.text = "Score: " + score.ToString();
    }

    public void AddScore(int i)
    {
        score += i;
        txtScore.text ="Score: "+score.ToString();
    }
}
