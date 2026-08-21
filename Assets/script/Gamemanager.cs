using UnityEngine;
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
        
    }

    private void SetBall(BallColor col, int i)
    {
       GameObject obj = Instantiate(ballPrefab,
            ballPositions[i].transform.position,
            Quaternion.identity);

        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }
}
