using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int SelectedBackgroundIndex;
    public static GameManager Instance;
    public bool isPlaying = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {}

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        isPlaying = true;
    }

    public void SetSelectedBackground(int index)
    {
        SelectedBackgroundIndex = index;
    }

    public void GameOver()
    {
        isPlaying = false;
        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager != null)
        {
            Debug.Log("Game Over inside");
            gameOverManager.TriggerGameOver();
        }
    }
}
