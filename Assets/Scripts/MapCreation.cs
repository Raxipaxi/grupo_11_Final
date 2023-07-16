using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class MapCreation : MonoBehaviour
{
    [SerializeField] private Vector2 stageSize;
    public Vector2 StageSize => stageSize;
    [SerializeField] private GameObject[] wallsX;
    [SerializeField] private GameObject[] wallsY;
    [SerializeField] private Vector2 brickSize;
    public Vector2 BrickSize => brickSize;
    [field: SerializeField] public List<Bricks> BricksList;
    [SerializeField] private BallScript ball;
    [SerializeField] private Slider _slider;
    [SerializeField]private PhysicsManager _manager;

    private void Awake()
    {
        CalculateDistance();
        _manager.Initialize(_slider,this);
    }
    private void Start()
    {
        _slider.AssignProperties(stageSize);
        ball.AssignProperties(stageSize,brickSize.y,_slider,_manager);

    }

    private void CalculateDistance()
    { // Ver como conseguir el grosor de la pared en X
        stageSize = new Vector2(Math.Abs(wallsX[0].transform.position.x - wallsX[1].transform.position.x - 0.5f),
            Math.Abs(wallsY[0].transform.position.y - wallsY[1].transform.position.y));
    }
}
