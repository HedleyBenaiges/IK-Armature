using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Snake : MonoBehaviour
{
    public int[] body = {1};
    public Sprite bodySprite;

    // Start is called before the first frame update
    void Start()
    {
        GameObject bodySegment = new GameObject("BodySegment", typeof(SpriteRenderer));
        SpriteRenderer bodySpriteRenderer = bodySegment.GetComponent<SpriteRenderer>();

        bodySpriteRenderer.sprite = bodySprite;
        // circleSpriteRenderer.sortingOrder = 20;
        // circleSpriteRenderer.sortingLayerName = "Over";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
