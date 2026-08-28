using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private TMP_Text notiText;
    [SerializeField]
    private GameObject[] ballPositions;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject cueBall;

    [SerializeField]
    private GameObject ballLine;

    [SerializeField]
    private float xInput = 0f;

    [SerializeField]
    private GameObject cam;

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
        RotateBall();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            ShootBall();
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -0.5f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = 0.5f;
        else
            xInput = 0f;

        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
            StopBall();
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
        if (cueBall == null)
        {
            Debug.LogWarning("cueBall is missing/destroyed. Cannot shoot.");
            return;
        }

        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        if (rd == null) return;

        rd.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);

        if (ballLine != null)
            ballLine.SetActive(false);

        if (cam != null)
        {
            cam.transform.parent = null;
            cam.transform.position = new Vector3(0f, 30f, -42f);
            cam.transform.eulerAngles = new Vector3(45f, 0f, 0f);
        }
    }

    private void RotateBall()
    {
        if (cueBall != null)
            cueBall.transform.Rotate(new Vector3(0f, xInput, 0f));
    }

    private void StopBall()
    {
        if (cueBall == null)
        {
            Debug.LogWarning("cueBall is missing/destroyed. Cannot stop.");
            return;
        }

        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        cueBall.transform.eulerAngles = Vector3.zero;

        if (ballLine != null)
            ballLine.SetActive(true);

        CameraBehindCueBall();
    }

    private void CameraBehindCueBall()
    {
        if (cueBall == null || cam == null) return;

        cam.transform.parent = cueBall.transform;
        cam.transform.position = cueBall.transform.position + new Vector3(0f, 7f, -15f);
        cam.transform.eulerAngles = new Vector3(30f, 0f, 0f);
    }

    public void ShowScoreText(int n)
    {
        playerScore += n;
        if (notiText != null)
            notiText.text = $"Ball Point:{n}\nTotal Score:{playerScore}";
    }

    public void ShowStringText(string s)
    {
        if (notiText != null)
            notiText.text = s;
    }
}