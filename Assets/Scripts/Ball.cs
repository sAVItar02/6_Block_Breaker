using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1 = null;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip metalHit;
    [SerializeField] float randomFactor = 0.2f;

    public AudioClip popSound;
    public AudioClip crackSound;
    public AudioClip dieSound;

    Rigidbody2D myRigidBody;

    //State
    public bool hasStarted = false;
    Vector2 paddleToBallVector;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
       paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    public void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    public void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myRigidBody.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(randomFactor, randomFactor);
        
        if(hasStarted)
        {
            TriggerCollisionSFX(collision);
            myRigidBody.velocity += velocityTweak;
        }
    }

    private void TriggerCollisionSFX(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<Block>())
        {
            GetComponent<AudioSource>().PlayOneShot(clickSound);
        }
        else if (collision.gameObject.GetComponent<Block>().tag == "UnBreakable")
        {
            GetComponent<AudioSource>().PlayOneShot(metalHit);
        }
    }
}
