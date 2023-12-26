using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEffect : MonoBehaviour, IApplyEffects
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
        ScoreManager.Instance.IncreaseScore(-1);
        Debug.Log("Bad Effect applied");
    }
}
