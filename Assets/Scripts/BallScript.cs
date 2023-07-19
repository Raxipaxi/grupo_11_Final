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
    private Vector3 _NextDir;
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

        GameManager.Instance.updateManager.gameplayCustomUpdate.Add(this);
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
    }

    void Move()
    {
        _NextDir = _tr.position + Dir * (Speed * Time.deltaTime);
        GameManager.Instance.physicsManager.WallCollision(this, _NextDir);

        _NextDir += Dir * (Speed * Time.deltaTime);
       _tr.position = _NextDir;
    }

    public void DoUpdate()
    {
        if (!initialized) return;
        Move();
        GameManager.Instance.physicsManager.BrickCollisionCheck(this);
        GameManager.Instance.physicsManager.SliderCollision(this);
    }
}
