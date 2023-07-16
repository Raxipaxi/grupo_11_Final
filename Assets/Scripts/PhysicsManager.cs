using System;
using System.Collections.Generic;
using CustomUpdateManagerNSP;
using UnityEngine;
using Utilities.Parents;


namespace Utilities
{
    public class PhysicsManager:PhysicsUpdateBehaviour
    {
        public static PhysicsManager Instance;
        private Slider _slider;
        private List<Bricks> _bricksList;
        private BallScript _ball;
        private Entity _rWall;
        private Entity _lWall;
        private Entity _wallY;
        private float BallLeft => _ball.Pos.x - _ball.radio;
        private float BallRight => _ball.Pos.x + _ball.radio;
        private float BallTop => _ball.Pos.y + _ball.radio;
        private float BallBot => _ball.Pos.y - _ball.radio;


        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }

        public void Initialize (Entity Rwall,Entity Lwall, Entity wallY,BallScript ballScript,Slider slider, List<Bricks> bricksList)
        {
            _slider = slider;
            _bricksList = bricksList;
            _ball = ballScript;
            _rWall = Rwall;
            _lWall = Lwall;
            _wallY = wallY;
        }
        protected override void UpdateItems()
        {
            base.UpdateItems();
        //    WallCollision();
            SliderCollision();
            BrickCollisionCheck();
            
        }
        public void WallCollision(Vector3 nextPos)
        {
            if (BallLeft < _lWall.Right || BallRight > _rWall.Left)
            {
                _ball.ChangeDir(-_ball.Dir.x, _ball.Dir.y);
            }
            else if (BallBot < 0 || BallTop > _wallY.Bot)
            {
                _ball.ChangeDir(_ball.Dir.x, -_ball.Dir.y);
            }

        }


        public void SliderCollision()
        {
            if (BallBot > _slider.Top)
            {
                return;
            }
            if (BallLeft < _slider.Right &&
                BallRight > _slider.Left)
            {
                float ballPosX = _ball.Pos.x;
                if (ballPosX < _slider.PosX - _slider.Center ||
                    ballPosX > _slider.PosX + _slider.Center)
                {
                    _ball.ChangeDir(_ball.Dir.x - 0.25f, Math.Abs(_ball.Dir.y));
                }
                else
                {
                    _ball.ChangeDir(_ball.Dir.x, Math.Abs(_ball.Dir.y));
                }

            }
        }
        public void BrickCollisionCheck()
        {
            foreach (Bricks bricks in _bricksList)
            {
                if (BallBot > bricks.Top ||
                    BallTop < bricks.Bot)
                {
                    continue;
                }
                if (BallLeft <= bricks.Right &&
                    BallRight >= bricks.Left)
                {
                    _ball.ChangeDir(_ball.Dir.x, -_ball.Dir.y);
                    bricks.Hit();
                    break;
                }
            }
        }

        public void UnList(Bricks brick)
        {
            _bricksList.Remove(brick);
        }
        
    }
}