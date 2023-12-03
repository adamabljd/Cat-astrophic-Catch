using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    public float minSwipeDistance = 20f;

    public SpriteRenderer backgroundRenderer;
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private RectTransform mapRectTransform;

    public Sprite[] backgroundSprites;
    public string[] mapNames;

    private int currentIndex = 0;
    private bool isSwiping = false;

    private void Start() {

    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (!isSwiping && RectTransformUtility.RectangleContainsScreenPoint(mapRectTransform, touch.position, null))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerDownPosition = touch.position;
                    fingerUpPosition = touch.position;
                    isSwiping = true;
                }
            }

            if (isSwiping)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    fingerUpPosition = touch.position;
                    DetectSwipe();
                    isSwiping = false;
                }
            }
        }
    }


    private void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if (IsHorizontalSwipe())
            {
                if(fingerDownPosition.x > fingerUpPosition.x){
                    ChangeMap(true);
                }else if(fingerDownPosition.x < fingerUpPosition.x){
                    ChangeMap(false);
                }
            }
        }
    }

    private bool IsHorizontalSwipe()
    {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x) > Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
    }

    private bool SwipeDistanceCheckMet()
    {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x) > minSwipeDistance;
    }

    private void ChangeMap(bool next)
    {
        switch(next){
            case true:
                currentIndex++;
                if (currentIndex >= backgroundSprites.Length)
                {
                    currentIndex = 0;
                }
                break;
            case false:
                currentIndex--;
                if (currentIndex < 0)
                {
                    currentIndex = backgroundSprites.Length - 1;
                }
                break;
        }
        backgroundRenderer.sprite = backgroundSprites[currentIndex];
        titleText.text = mapNames[currentIndex];
        GameManager.Instance.SetSelectedBackground(currentIndex);
    }
}

