using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    public float gravity = -8f;
    public float Upwards = 4f;
    private Text score;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        score.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey("w")) 
        {
            direction = Vector3.up * Upwards;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite() 
    {
        spriteIndex++;
        if(spriteIndex >= sprites.Length) 
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle") 
        {
            FindObjectOfType<ScoreManager>().GameOver();
        }else if(other.gameObject.tag == "Scoring") 
        {
            FindObjectOfType<ScoreManager>().IncreaseScore();
        }
    }
}
