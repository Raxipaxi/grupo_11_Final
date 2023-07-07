using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    [SerializeField]private Vector2 stageSize;
    [SerializeField]private GameObject wallPrefab;
    [SerializeField]private List<GameObject> walls;
#if UNITY_EDITOR
    [ContextMenu("BakeStage")]
    private void BakeStage()
    {
        var stageScaleX = new Vector3(stageSize.x, 1, 1);
        var stageScaleY = new Vector3(1, stageSize.y, 1);
        InstantiateWall(new Vector3(0,0),stageScaleX);
        InstantiateWall(new Vector3(0,stageSize.y),stageScaleX );
        InstantiateWall(new Vector3(stageSize.x/2, stageSize.y/2), stageScaleY);
        InstantiateWall(new Vector3(-stageSize.x/2,stageSize.y/2),stageScaleY);
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
#endif
    private void InstantiateWall(Vector3 pos, Vector3 scale)
    {
        var wall =   Instantiate(wallPrefab,pos,Quaternion.identity);
        wall.transform.localScale = scale;
        walls.Add(wall);
    }
}
