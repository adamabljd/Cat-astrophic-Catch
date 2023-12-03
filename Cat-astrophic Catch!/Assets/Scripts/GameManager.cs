using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int SelectedBackgroundIndex;
    public static GameManager Instance;

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
        
    }
    public void StartTimerMode()
    {
        Debug.Log("Starting Timer Mode");
        SceneManager.LoadScene("Game");
    }

    public void StartSurvivalMode()
    {
        Debug.Log("Starting Survival Mode");
        SceneManager.LoadScene("Game");
    }

    public void SetSelectedBackground(int index)
    {
        SelectedBackgroundIndex = index;
    }
}
