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
    [SerializeField] private Slider _slider;
    [SerializeField] private Transform sliderSpawmPos;
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private BallScript _ballScript;

    public void Initialize(PhysicsManager physicsManager)
    {
        physicsManager.Initialize(RwallX,LwallX,wallY,_slider, BricksList);
        _slider.Initialize();
        _slider.AssignProperties(LwallX, RwallX);

        for (int i = 0; i < BricksList.Count; i++)
        {
            BricksList[i].Initialize();
        }

        _ballScript.Initialize();
        LwallX.Initialize();
        RwallX.Initialize();
        wallY.Initialize();
    }

    public void Restart()
    {
        _slider.transform.position = sliderSpawmPos.position;
        Instantiate(_ballScript, ballSpawnPoint.position, Quaternion.identity);
    }
}
