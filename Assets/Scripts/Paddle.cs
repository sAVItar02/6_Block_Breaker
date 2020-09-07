using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    private Vector3 touchPos;
    public float minX = 1f;
    public float maxX = 15f;

    public AudioClip collectSFX;

    GameSession gameSession;
    Ball ball;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
    }
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            paddlePos.x = Mathf.Clamp(touchPos.x, minX, maxX);
            transform.position = paddlePos;
        }
    }

    /*private float GetXPos()
    {
        if(gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x; 
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }*/
}
