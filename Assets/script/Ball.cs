using System;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BallColor
{
    White,
    Red,
    Yellow,
    Green,
    Brown,
    Blue,
    Pink,
    Black
}

public class Ball : MonoBehaviour, IPointerClickHandler
{
    
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        {
            Debug.Log(point);
            Gamemanager.instance.PlayerScore = ++point;
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private int point;

    [SerializeField]
    private BallColor color;

    [SerializeField]
    private MeshRenderer rd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        rd = GetComponent<MeshRenderer> ();
    }

    public void SetColorAndPoint(BallColor col)
    {
        switch(col)
        {
            case BallColor.White:
                point = 0;
                rd.material.color = Color.white;
                break;

            case BallColor.Red:
                point = 1;
                rd.material.color = Color.red;
                break;

            case BallColor.Yellow:
                point = 2;
                rd.material.color = Color.yellow;
                break;

            case BallColor.Green:
                point = 3;
                rd.material.color = Color.green;
                break;

            case BallColor.Brown:
                point = 4;
                rd.material.color = Color.brown;
                break;

            case BallColor.Blue:
                point = 5;
                rd.material.color = Color.blue;
                break;

            case BallColor.Pink:
                point = 6;
                rd.material.color = Color.pink;
                break;

            case BallColor.Black:
                point = 0;
                rd.material.color = Color.black;
                break;
        }
    }

}



