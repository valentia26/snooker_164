using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballPositions;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject cueBall;


    [SerializeField]
    private float xInput = 0f;

    public static Gamemanager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        SetBall(BallColor.Red, 1);
        SetBall(BallColor.Yellow, 2);
        SetBall(BallColor.Green, 3);
        SetBall(BallColor.Blue, 4);
        SetBall(BallColor.Brown, 5);
        SetBall(BallColor.Pink, 6);
        SetBall(BallColor.Black, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            ShootBall();
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -0.1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = 0.1f;
        else
            xInput = 0f;

        RotateBall();
    }

    private void SetBall(BallColor col, int i)
    {
       GameObject obj = Instantiate(ballPrefab,
            ballPositions[i].transform.position,
            Quaternion.identity);

        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }

    private void ShootBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * 50,ForceMode.Impulse);
    }

    private void RotateBall()
    {
        if(cueBall != null) 
            cueBall.transform.Rotate(new Vector3(0f, xInput ,0f));
    }
}
