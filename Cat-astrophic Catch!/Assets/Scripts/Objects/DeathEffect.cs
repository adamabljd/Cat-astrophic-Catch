using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour, IApplyEffects
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ApplyEffect(){
        if(GameManager.Instance.isTimerModeActive == true){
            GameManager.Instance.addCurrentTime(-10f);
        } else if(GameManager.Instance.isSurvivalModeActive == true){
            GameManager.Instance.addCurrentLives(-1);
        }
        
    }
}
