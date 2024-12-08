using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public int playerHealth;
    public TextMeshProUGUI health;
    public GameObject deathUI;
    public GameObject wave;
    public Vector3 wavePos;
    public GameObject winUI;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(Spawner());
        StartCoroutine(Win());

    }
    private void Update()
    {

        // update the health bar each frame 

        health.text = playerHealth.ToString();

        // if the player health is 0 or less , the game will end
        if(playerHealth <= 0)
        {
            EndGame();
        }
    }
    IEnumerator Spawner()
    { 
        // spawn a wave every 25 seconds
        yield return new WaitForSeconds(25);
        // spawn the wave at the position of the wavePos
        Instantiate(wave, wavePos, Quaternion.identity);
        // restart the coroutine
        StartCoroutine(Spawner());
    }

    private void EndGame()
    {
        
        Time.timeScale = 0;
        deathUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(120);
        Time.timeScale = 0;
        winUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

