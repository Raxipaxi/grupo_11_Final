using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class MapCreation : MonoBehaviour
{
    [SerializeField]private Vector2 stageSize;
    public Vector2 StageSize => stageSize;
    [SerializeField]private GameObject wallPrefab;
    [SerializeField]private List<GameObject> walls;
    [SerializeField] private BallScript ball;
    [SerializeField] private Slider _slider;
    [SerializeField] private Brick[] bricks;
    #region Editor

#if UNITY_EDITOR
    [ContextMenu("BakeStage")]
    private void BakeStage()
    {
        var stageScaleX = new Vector3(stageSize.x, 1, 1);
        var stageScaleY = new Vector3(1, stageSize.y, 1);
        InstantiateWall(new Vector3(0,stageSize.y/2),stageScaleX);
        InstantiateWall(new Vector3(0,-stageSize.y/2),stageScaleX );
        InstantiateWall(new Vector3(stageSize.x/2, 0), stageScaleY);
        InstantiateWall(new Vector3(-stageSize.x/2,0),stageScaleY);
    }
    [ContextMenu("ClearStage")]
    private void ClearScenenary()
    {

        for (int i = 0; i < walls.Count; i++)
        {
            DestroyImmediate(walls[i]);
        }

        walls.Clear();
    }

    [ContextMenu("Build Bricks")]
    private void BakeBricks()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            bricks[i].ChangeColor();
        }
    }
#endif

    #endregion

    private void Start()
    {
        ball.AssignProperties(stageSize / 2, bricks,_slider);
        _slider.AssignProperties(stageSize / 2);
    }

    private void InstantiateWall(Vector3 pos, Vector3 scale)
    {
        var wall =   Instantiate(wallPrefab,pos,Quaternion.identity);
        wall.transform.parent = this.transform;
        wall.transform.localScale = scale;
        walls.Add(wall);
    }
}
