using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Parents;

namespace Utilities
{
    public class PhysicsManager: MonoBehaviour
    {
        private Slider _slider;
        public Slider Slider => _slider;
        private List<Bricks> _bricksList;
        private BallScript _ball;
        private Entity _rWall;
        private Entity _lWall;
        private Entity _wallY;

        public Entity WallR => _rWall;
        public Entity WallL => _lWall;
        public Entity WallT => _wallY;
        private float BallLeft => _ball.Pos.x - _ball.radio;
        private float BallRight => _ball.Pos.x + _ball.radio;
        private float BallTop => _ball.Pos.y + _ball.radio;
        private float BallBot => _ball.Pos.y - _ball.radio;

        public void Initialize (Entity Rwall,Entity Lwall, Entity wallY,Slider slider, List<Bricks> bricksList)
        {
            _slider = slider;
            _bricksList = bricksList;
            _rWall = Rwall;
            _lWall = Lwall;
            _wallY = wallY;
        }

        public void WallCollision(BallScript currentBall,Vector3 nextPos)
        {
            _ball = currentBall;
            if (BallLeft <= _lWall.Right || BallRight >= _rWall.Left)
            {
                _ball.ChangeDir(-_ball.Dir.x, _ball.Dir.y);
            }
            else if (BallTop >= _wallY.Bot  )
            {
                _ball.ChangeDir(_ball.Dir.x, -_ball.Dir.y);
            }

            if (BallBot < 0)
            {
                GameManager.Instance.ModifyCurrentBalls(-1);
                _ball.Disable();
            }

        }

        public void SliderCollision(BallScript currentBall)
        {
            _ball = currentBall;
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
                    _ball.ChangeDir(_ball.Dir.x - GameManager.Instance.globalConfig.sideHitMod, Math.Abs(_ball.Dir.y));
                }
                else
                {
                    _ball.ChangeDir(_ball.Dir.x, Math.Abs(_ball.Dir.y));
                }

            }
        }
        public void BrickCollisionCheck(BallScript currentBall)
        {
            _ball = currentBall;
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