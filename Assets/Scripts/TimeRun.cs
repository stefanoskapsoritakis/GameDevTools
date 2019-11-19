using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeRun : MonoBehaviour
{
    public Text timeText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Button restartButton;
    public bool isGameActive =true ;
    public float time = 30;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }
    public void UpdateTime()
    {
        if (isGameActive)
        {
            time = time - Time.deltaTime;
            timeText.text = "Time: " + Mathf.Round(time);
            if (time < 0)
            {
                GameOver();
                
            }
        }
    }
    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameActive = true;
    }
}