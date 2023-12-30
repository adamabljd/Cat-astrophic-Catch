using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset;
    private bool isDragging = false;
    private float minX, maxX;

    private int maxHealth = 1;
    private int currentHealth;


    void Start()
    {
        mainCamera = Camera.main;

        // Calculate the screen boundaries in world space
        float screenHalfWidthInWorldUnits = mainCamera.orthographicSize * mainCamera.aspect;
        float playerHalfWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;

        minX = -screenHalfWidthInWorldUnits + playerHalfWidth;
        maxX = screenHalfWidthInWorldUnits - playerHalfWidth;

        currentHealth = maxHealth;
    }

    void Update()
    {
        if (GameManager.Instance.isPlaying){
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPos = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, transform.position.z));

                if (touch.phase == TouchPhase.Began)
                {
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        isDragging = true;
                        offset = transform.position - touchPos;
                    }
                }

                if (touch.phase == TouchPhase.Moved && isDragging)
                {
                    Vector3 newPosition = new Vector3(touchPos.x + offset.x, transform.position.y, transform.position.z);
                    newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX); // Clamp the x position
                    transform.position = newPosition;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    isDragging = false;
                }
            }
            playerIsDead();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        var effects = other.gameObject.GetComponents<IApplyEffects>();

        foreach (var effect in effects)
        {
            effect.ApplyEffect();
        }
        Destroy(other.gameObject);
    }

    public void playerIsDead(){
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameManager.Instance.GameOver();
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
