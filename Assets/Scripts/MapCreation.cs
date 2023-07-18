using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using Utilities.Parents;

public class MapCreation : MonoBehaviour
{
    [SerializeField] private Entity LwallX;
    [SerializeField] private Entity RwallX;
    [SerializeField] private Entity wallY;
    [field: SerializeField] public List<Bricks> BricksList;
    [SerializeField] private BallScript ball;
    [SerializeField] private Slider _slider;
    [SerializeField] private PhysicsManager _manager;

    private void Awake()
    {
        _manager.Initialize(RwallX,LwallX,wallY,_slider, BricksList);
    }
    private void Start()
    {
        _slider.AssignProperties(LwallX, RwallX);

    }
}
