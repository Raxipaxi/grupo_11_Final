using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class MapCreation : MonoBehaviour
{
    [SerializeField] private Vector2 stageSize;
    [SerializeField] private GameObject[] wallsX;
    [SerializeField] private GameObject[] wallsY;
    [field: SerializeField] public List<Bricks> BricksList;
    [SerializeField] private BallScript ball;
    [SerializeField] private Slider _slider;
    [SerializeField] private PhysicsManager _manager;

    private void Awake()
    {
        CalculateDistance();
        _manager.Initialize(stageSize,ball,_slider, this, BricksList);
    }
    private void Start()
    {
        _slider.AssignProperties(stageSize);

    }

    private void CalculateDistance()
    { // Ver como conseguir el grosor de la pared en X
        stageSize = new Vector2(Math.Abs(wallsX[0].transform.position.x - wallsX[1].transform.position.x - 0.5f),
            Math.Abs(wallsY[0].transform.position.y - wallsY[1].transform.position.y));
    }
}
