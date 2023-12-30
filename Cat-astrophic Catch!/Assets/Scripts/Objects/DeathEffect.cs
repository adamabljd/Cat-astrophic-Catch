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
        if (GameManager.Instance.isPlaying)
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
        }
    }
}
