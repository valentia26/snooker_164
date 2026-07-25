using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballPositions;

    [SerializeField]
    private GameObject ballprefab;

    public static Gamemanager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetBall(BallColor red, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetBall(BallColor col, int i)
    {
       GameObject obj = Instantiate(ballprefab,
            ballPositions[i].transform.position,
            Quaternion.identity);

        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }
}
