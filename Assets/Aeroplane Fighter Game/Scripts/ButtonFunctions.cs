using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] InputField input;
    [SerializeField] Button gameButton;
    [SerializeField] int index;

    // Start is called before the first frame update
    void Start()
    {
        index = PersistentData.Instance.GetIndex();
        string pName = PersistentData.Instance.GetName();
        if (pName != "")
            input.placeholder.GetComponent<Text>().text = pName;
        if (index > 0)
            gameButton.GetComponentInChildren<Text>().text = "Resume game";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void GoToInstructions()
    {
        SceneManager.LoadScene("instructions");
    }
    public  void GoToSetting()
    {
        SceneManager.LoadScene("settings");
    }
    public  void GoToHighScore()
    {
        SceneManager.LoadScene("highscores");
    }

    public void PlayGame()
    {
       
        
        
            string playerName = input.text;
            PersistentData.Instance.SetName(playerName);
            SceneManager.LoadScene("level1");
        

    }

    public void MainMenu()
    {
        PersistentData.Instance.SetIndex(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("menu");
    }
    public void hardLevel()
    {
        SceneManager.LoadScene("level3");
    }

    public void mediumLevel()
    {
        SceneManager.LoadScene("level2");
    }
    public void easyLevel()
    {
        SceneManager.LoadScene("level1");
    }
}