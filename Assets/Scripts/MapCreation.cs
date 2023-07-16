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
    private Dictionary<Vector2, Bricks> _bricksMap = new Dictionary<Vector2, Bricks>();
    public Dictionary<Vector2, Bricks> BricksMap => _bricksMap;
    [SerializeField] private BallScript ball;
    [SerializeField] private Slider _slider;
    [SerializeField] private Bricks[] bricks;
    [SerializeField]private PhysicsManager _manager;

    private void Awake()
    {
        CalculateDistance();
        _manager.Initialize(_slider,this);
    }
    private void Start()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            if(_bricksMap.ContainsKey(bricks[i].transform.position))
                _bricksMap.Add(bricks[i].transform.position, bricks[i]);
        }
        _slider.AssignProperties(stageSize);
        ball.AssignProperties(stageSize,brickSize.y,_slider,_manager);

    }

    private void CalculateDistance()
    { // Ver como conseguir el grosor de la pared en X
        stageSize = new Vector2(Math.Abs(wallsX[0].transform.position.x - wallsX[1].transform.position.x - 0.5f),
            Math.Abs(wallsY[0].transform.position.y - wallsY[1].transform.position.y));
    }
}
