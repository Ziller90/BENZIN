using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Health playersVehicleHealth;
    public CanvasGroup gameOverPanel;
    public float speed;
    public float timeToGameOverScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playersVehicleHealth.currentHealth <= 0)
        {
            StartCoroutine("ShowGameOverScreen");
        }
    }
    IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(timeToGameOverScreen);
        while (gameOverPanel.alpha < 1)
        {
            yield return new WaitForSeconds(100 / speed);
            gameOverPanel.alpha += 0.01f;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
