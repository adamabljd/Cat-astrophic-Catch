using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset;
    private bool isDragging = false;
    private float minX, maxX; // Set these in the Inspector to define movement boundaries

    void Start()
    {
        mainCamera = Camera.main; // Cache the main camera

        // Calculate the screen boundaries in world space
        float screenHalfWidthInWorldUnits = mainCamera.orthographicSize * mainCamera.aspect;
        float playerHalfWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;

        minX = -screenHalfWidthInWorldUnits + playerHalfWidth;
        maxX = screenHalfWidthInWorldUnits - playerHalfWidth;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu"){
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
        }
    }
}
