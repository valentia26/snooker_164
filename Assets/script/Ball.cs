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
    Debug.Log(point);
        GameManager.instance.PlayerScore =++  point;
        Destroy(gameObject);
}
{
    [SerializeField]
    private int point;

    [SerializeField]
    private BallColor
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
