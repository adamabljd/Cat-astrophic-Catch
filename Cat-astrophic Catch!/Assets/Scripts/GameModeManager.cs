using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameModeManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null && healthText != null)
        {
            PlayerController player = FindObjectOfType<PlayerController>(); 
            if(player != null)
            {
                int livesRemaining = player.GetCurrentHealth();
                healthText.text = "Lives: " + livesRemaining.ToString();
            }
        }
    }
}
