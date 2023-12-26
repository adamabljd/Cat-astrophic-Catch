using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int SelectedBackgroundIndex;
    public static GameManager Instance;
    public float totalTime = 60f;
    private float remainingTime;
    public bool isTimerModeActive = false;

    public int totalLives = 9;
    private int remainingLives;
    public bool isSurvivalModeActive = false;

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
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimerMode();
    }
    public void StartTimerMode()
    {
        SceneManager.LoadScene("Game");
        initTimerMode();
    }

    public void StartSurvivalMode()
    {
        SceneManager.LoadScene("Game");
        initSurvivalMode();
    }

    public void SetSelectedBackground(int index)
    {
        SelectedBackgroundIndex = index;
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
    }

    public void StopTimerMode()
    {
        isTimerModeActive = false;
    }

    public void StopSurvivalMode()
    {
        isSurvivalModeActive = false;
    }

    public void initTimerMode()
    {
        remainingTime = totalTime;
        isTimerModeActive = true;
    }
    public void initSurvivalMode()
    {
        remainingLives = totalLives;
        isSurvivalModeActive = true;
    }

    public float GetCurrentTime()
    {
        return remainingTime;
    }

    public float GetCurrentLives()
    {
        return remainingLives;
    }

    public void addCurrentTime(float time){
        remainingTime += time;
    }

    public void addCurrentLives(int lives){
        remainingLives += lives;
    }

    public void TimerMode()
    {
        if (isTimerModeActive)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                GameOver();
                isTimerModeActive = false;
            }
        }
    }

    public void SurvivalMode()
    {
        if (isSurvivalModeActive)
        {
            if (remainingLives == 0)
            {
                GameOver();
                isSurvivalModeActive = false;
            }
        }
    }
}
