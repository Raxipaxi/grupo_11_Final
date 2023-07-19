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
   // [SerializeField] private Transform sliderSpawmPos;
   // [SerializeField] private BallScript _ballScript;

   private Vector3 sliderSP;
    public void Initialize(PhysicsManager physicsManager)
    {
        physicsManager.Initialize(RwallX, LwallX, wallY, _slider, BricksList);
        sliderSP = _slider.transform.position;
        _slider.Initialize();
        _slider.AssignProperties(LwallX, RwallX);


        for (int i = 0; i < BricksList.Count; i++)
        {
            BricksList[i].Initialize();
        }

        //_ballScript.Initialize();
        LwallX.Initialize();
        RwallX.Initialize();
        wallY.Initialize();
    }

    public void Restart()
    {
        _slider.transform.position = sliderSP;
       _slider.BallStock();
       // Instantiate(_ballScript, ballSpawnPoint.position, Quaternion.identity);
    }

    public BallScript GetBall(Vector3 position)
    {//TODO POOL
        return Instantiate(GameManager.Instance.globalConfig.ballPrefab, position, Quaternion.identity);
    }

}
