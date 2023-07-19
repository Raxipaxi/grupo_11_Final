using System;
using UnityEngine;
using Utilities;

public class BallScript : MonoBehaviour, IUpdate
{
    public float radio { get; private set; }
    [SerializeField] private float radioScaler;
    private Slider _slider;
    private Vector2 dir;
    private Transform _tr;
    private Vector3 _NextPos;
    private Vector3 _PrevPos;
    private bool initialized = false;

    public Vector2 Pos => _tr.position;
    public float Speed => GameManager.Instance.globalConfig.ballSpeed;
    public Vector3 Dir => dir;

    public void Initialize()
    {
        initialized = true;
        _tr = transform;
        radio = _tr.localScale.x * radioScaler;
        GameManager.Instance.ModifyCurrentBalls(1);
        dir = new Vector2(1, 1);
        _PrevPos = _tr.position;

        GameManager.Instance.updateManager.gameplayCustomUpdate.Add(this);
        gameObject.SetActive(true);
    }

    public void ChangeDir(float currDirX, float currDirY)
    {
        dir.x = currDirX ;
        dir.y = currDirY;
        AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.ballBounce);
    }

    public void Disable()
    {
        GameManager.Instance.updateManager.gameplayCustomUpdate.Remove(this);
        gameObject.SetActive(false);
    }

    void Move()
    {
        
        _NextPos = _tr.position + Dir * (Speed * Time.deltaTime);
        if (!((Math.Abs(Vector3.Magnitude(_NextPos-_PrevPos)))<GameManager.Instance.globalConfig.distToCheck))
        {
            _PrevPos = _NextPos;
            GameManager.Instance.physicsManager.WallCollision(this, _NextPos);
        }

        _NextPos.x = Mathf.Clamp(_NextPos.x, GameManager.Instance.physicsManager.WallL.Right, GameManager.Instance.physicsManager.WallR.Left);
        _NextPos.y = Mathf.Clamp(_NextPos.y, GameManager.Instance.globalConfig.deadZone, GameManager.Instance.physicsManager.WallT.Bot);

        _NextPos += Dir * (Speed * Time.deltaTime);
       _tr.position = _NextPos;
    }

    public void DoUpdate()
    {
        if (!initialized) return;
        Move();
        GameManager.Instance.physicsManager.BrickCollisionCheck(this);
        GameManager.Instance.physicsManager.SliderCollision(this);
    }
}
