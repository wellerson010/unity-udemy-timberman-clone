using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    Left = 1,
    Right = 2
}

public class Player : MonoBehaviour
{

    private SpriteRenderer Sprite;
    private Animator Animator;
    private Side CurrentSide = Side.Left;

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GameOver)
        {
            Sprite.flipX = false;
            Animator.Play("die");
        }
    }

    private void ChangeSide(Side side)
    {
        if (CurrentSide != side)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
            Sprite.flipX = !Sprite.flipX;
            CurrentSide = side;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.GameOver = true;
        GameManager.instance.ScreenGameOver();
    }

    public void Touch(bool left)
    {
        if (!GameManager.instance.GameOver)
        {
            ChangeSide((left) ? Side.Left : Side.Right);
            Animator.Play("cut");
        }
    }
}
