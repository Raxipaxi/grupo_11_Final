using System;
using System.Collections.Generic;
using CustomUpdateManagerNSP;
using UnityEngine;
using Utilities.Parents;


namespace Utilities
{
    public class PhysicsManager:PhysicsUpdateBehaviour
    {
        private Slider _slider;
        private List<Bricks> _bricksList;
        private BallScript _ball;
        private Entity _rWall;
        private Entity _lWall;
        private Entity _wallY;
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
            WallCollision();
            SliderCollision();
            BrickCollisionCheck();
            
        }
        public void WallCollision()
        {
            if (_ball.Pos.x - _ball.radio <= _lWall.PosX + _lWall.SizeX ||_ball.Pos.x + _ball.radio >= _rWall.PosX - _rWall.SizeX)
            {
                _ball.ChangeDir(-_ball.Dir.x, _ball.Dir.y);
            }
            else if (_ball.Pos.y - _ball.radio <= 0 ||_ball.Pos.y + _ball.radio >= _wallY.PosY - _wallY.SizeY)
            {
                _ball.ChangeDir(_ball.Dir.x, -_ball.Dir.y);
            }

        }


        public void SliderCollision()
        {
            if (_ball.Pos.y - _ball.radio > _slider.PosY + _slider.SizeY)
            {
                return;
            }
            if (_ball.Pos.x - _ball.radio <= _slider.PosX + _slider.SizeX &&
                _ball.Pos.x + _ball.radio >= _slider.PosX - _slider.SizeX)
            {
                float ballPosX = _ball.Pos.x;
                if (ballPosX < _slider.PosX - _slider.Center ||
                    ballPosX > _slider.PosX + _slider.Center)
                {
                    print("cotadito");
                    _ball.ChangeDir(_ball.Dir.x - 0.25f, Math.Abs(_ball.Dir.y));
                }
                else
                {
                    _ball.ChangeDir(_ball.Dir.x, Math.Abs(_ball.Dir.y));
                    
                    print("Centro");
                }

            }
        }
        public void BrickCollisionCheck()
        {
            foreach (Bricks bricks in _bricksList)
            {
                if (_ball.Pos.y - _ball.radio > bricks.PosY + bricks.SizeY ||
                    _ball.Pos.y + _ball.radio < bricks.PosY - bricks.SizeY)
                {
                    continue;
                }
                if (_ball.Pos.x - _ball.radio <= bricks.PosX + bricks.SizeX &&
                    _ball.Pos.x + _ball.radio >= bricks.PosX - bricks.SizeX)
                {
                    _ball.ChangeDir(_ball.Dir.x, -_ball.Dir.y);
                    bricks.Hit();
                    return;
                }
            }
        }
    }
}