using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHeath : MonoBehaviour
{
    [SerializeField] int pHealth; //player health
    [SerializeField] int eHealth; //enemy health
    [SerializeField] int score;
    public GameObject controller;
    const int DEFAULT_POINTS = -1; //decrease one if player shoots another player
    const int HEALTH_POINTS = 5;
    const int EASY_LEVEL=1;
    const int SCORE_MULTIPLIER = 10;
    const int DEFAULT_PTS_LEVEL = 50;
    int score_threshold;
    [SerializeField] Text playerHealth;
    [SerializeField] Text sceneTxt;
    [SerializeField] Text enemyHealth;
    [SerializeField] Text playerScore;
    [SerializeField] Text nameTxt;
    [SerializeField] int level;
    [SerializeField] string playerName;

    // Start is called before the first frame update
    void Start()
    {
        pHealth = HEALTH_POINTS;
        eHealth = HEALTH_POINTS;
        level = SceneManager.GetActiveScene().buildIndex-1;
        playerName = PersistentData.Instance.GetName();
        score = PersistentData.Instance.GetScore();
        score_threshold = level * DEFAULT_PTS_LEVEL;
        PersistentData.Instance.SetIndex(level + 1);
        DisplayLevel();
        DisplayScore();
        DisplayHealth();
        DisplayName();

        if(controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    //add score
    public void addPoints(){
        score += SCORE_MULTIPLIER;
        DisplayScore();
        PersistentData.Instance.SetScore(score);
        if (score > score_threshold)
            AdvanceLevel();

    }
    
    //decreasone one from health
    public void decPlayerHealth(int points)
    {
        pHealth += points;
        if(pHealth ==0)
           controller.GetComponent<ButtonFunctions>().PlayGame();
        DisplayHealth();

    }
    public void decPlayerHealth()
    {
        decPlayerHealth(DEFAULT_POINTS);
    }
    public void decEnemyHealth(int points)
    {
        eHealth += points;
        if(eHealth == 0)
          AdvanceLevel();
        DisplayHealth();

    }
    public void decEnemyHealth()
    {
        decEnemyHealth(DEFAULT_POINTS);
    }

    public int getPHealth()
    {
        return pHealth;
    }

    public int getEHealth()
    {
        return eHealth;
    }

      public int getLevel()
    {
        return level;
    }
    public void DisplayScore()
    {
        playerScore.text = "Score: " + score;
    }
    public void DisplayHealth()
    {
        playerHealth.text = "Player: " + pHealth;
        enemyHealth.text = "Enemy: " + eHealth;
    }

    public void DisplayLevel()
    {
        sceneTxt.text = "Level: " + level;
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(level+2);
    }
    public void DisplayName()
    {
        nameTxt.text = "Hello, " + playerName;
    }

}
