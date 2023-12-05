using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSetter : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer;
    public Sprite[] backgroundSprites;
    int index;
    void Start()
    {
        index = GameManager.Instance.SelectedBackgroundIndex;
        backgroundRenderer.sprite = backgroundSprites[index];
    }
}
