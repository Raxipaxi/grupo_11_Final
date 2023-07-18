using System;
using CustomUpdateManagerNSP;
using UnityEngine;
using Utilities;

public class BallScript : GameplayUpdateBehaviour
{
    public float radio { get; private set; }
    [SerializeField] private float radioScaler;
    private Slider _slider;
    private PhysicsManager _physicsManager;
    private Vector2 dir;
    private Transform _tr;
    private Vector2 prevDir;
    private Vector3 _NextDir;

    public Vector2 Pos => _tr.position;
    public float Speed => GameManager.Instance.globalConfig.ballSpeed;
    public Vector3 Dir => dir;

    private void Awake() //TODO take out awake, start, update. move them to a CustomUpdater
    {

        _tr = transform;
        radio = _tr.localScale.x * radioScaler;
        print("Radio " + radio);
    }

    protected override void Start()
    {
        base.Start();
        Initialize();
    }

    void Initialize()
    {
        GameManager.Instance.ModifyCurrentBalls(1);
        dir = new Vector2(1, 1);
        prevDir = dir;
    }

    public void ChangeDir(float currDirX, float currDirY)
    {
        dir.x = currDirX ;
        dir.y = currDirY;
        AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.ballBounce);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }
    protected override void UpdateItems()
    {
        base.UpdateItems();
        Move();
        GameManager.Instance.physicsManager.BrickCollisionCheck(this);
        GameManager.Instance.physicsManager.SliderCollision(this);
    }

    void Move()
    {
        Vector3 nextPosition = _tr.position;
        GameManager.Instance.physicsManager.WallCollision(this,nextPosition + Dir * (Speed * Time.deltaTime));

       nextPosition += Dir * (Speed * Time.deltaTime);
       _tr.position = nextPosition;
    }
    
}
