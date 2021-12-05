using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHeath : MonoBehaviour
{
    [SerializeField] int pScore; //player health
    [SerializeField] int eScore; //enemy health
    const int DEFAULT_POINTS = 1; //add one if player shoots
    const int NUM_POINTS_PER_LEVEL = 5;
    int score_threshold;
    [SerializeField] Text playerScore;
    [SerializeField] Text sceneTxt;
    [SerializeField] Text enemyScore;
    [SerializeField] int level;
    [SerializeField] string playerName;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        //DisplayName();
        DisplayLevel();
        DisplayScore();



    }

    // Update is called once per frame
    void Update()
    {

    }
    
    //initially you get 1 health, every time you get hit you lose a health point
    public void decHealth(int points)
    {
        pScore += points;
        DisplayScore();

        if (pScore > score_threshold)
            AdvanceLevel();

    }


    public void decHealth()
    {
        decHealth(DEFAULT_POINTS);
    }

    public void DisplayScore()
    {
        playerScore.text = "Player: " + pScore;
        enemyScore.text = "Enemy: ";
    }

    public void DisplayLevel()
    {
        sceneTxt.text = "Level: " + level;
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(level + 2);
    }
}
    // public void DisplayName()
    // {
    //     nameTxt.text = "Hello, " + playerName;
    // }