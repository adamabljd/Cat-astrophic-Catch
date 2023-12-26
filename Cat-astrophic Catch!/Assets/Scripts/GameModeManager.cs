using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameModeManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null && timerText != null)
        {
            if(GameManager.Instance.isTimerModeActive == true){
            timerText.text = "Time : " + Mathf.CeilToInt(GameManager.Instance.GetCurrentTime()).ToString();
            } else if(GameManager.Instance.isSurvivalModeActive == true){
                timerText.text = "Lives: " + Mathf.CeilToInt(GameManager.Instance.GetCurrentLives()).ToString();
            }
        }
    }
}
