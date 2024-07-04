using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class OneBallBehaviour : MonoBehaviour
{
    /*For previous part*/
    //public float XRotation = 0;
    //public float YRotation = 1;
    //public float ZRotation = 0;
    //public float DegreesPerSecond = 180;

    public float XSpeed;
    public float YSpeed;
    public float ZSpeed;
    public float Multiplier = 0.75F;
    public float TooFar = 5;

    static int BallCount = 0;
    public int BallNumber;

    // Start is called before the first frame update
    void Start()
    {
        BallCount++;
        BallNumber = BallCount;

        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        /*For previous part*/
        //Vector3 axis = new Vector3(XRotation, YRotation, ZRotation);
        //transform.RotateAround(Vector3.zero, axis, DegreesPerSecond * Time.deltaTime);

        transform.Translate(Time.deltaTime * XSpeed, Time.deltaTime * YSpeed, Time.deltaTime * ZSpeed);

        XSpeed += Multiplier - Random.value * Multiplier * 2;
        YSpeed += Multiplier - Random.value * Multiplier * 2;
        ZSpeed += Multiplier - Random.value * Multiplier * 2;

        if ((Mathf.Abs(transform.position.x) > TooFar) || (Mathf.Abs(transform.position.y) > TooFar) || (Mathf.Abs(transform.position.z) > TooFar))
        {
            ResetBall();
        }
    }

    void OnMouseDown()
    {
        GameController controller = Camera.main.GetComponent<GameController>();
        if (!controller.GameOver)
        {
            controller.ClickedOnBall();
            Destroy(gameObject);
        }
    }

    void ResetBall()
    {
        XSpeed = Multiplier * Random.value;
        YSpeed = Multiplier * Random.value;
        ZSpeed = Multiplier * Random.value;

        transform.position = new Vector3(3 - Random.value * 6, 3 - Random.value * 6, 3 - Random.value * 6);
    }
}
