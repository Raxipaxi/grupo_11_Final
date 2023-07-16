using System;
using System.Collections.Generic;
using CustomUpdateManagerNSP;
using UnityEngine;


namespace Utilities
{
    public class PhysicsManager:PhysicsUpdateBehaviour
    {
        private Slider _slider;
        private MapCreation _map;
        private List<Bricks> _bricksList;
        private BallScript _ball;
        private Vector2 _wallLocation;
        public void Initialize (Vector2 wallLocation,BallScript ballScript,Slider slider, MapCreation mapCreator, List<Bricks> bricksList)
        {
            _slider = slider;
            _map = mapCreator;
            _bricksList = bricksList;
            _ball = ballScript;
            _wallLocation = wallLocation;
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
            if (_ball.Pos.x - _ball.radio <= 0 ||_ball.Pos.x + _ball.radio >= _wallLocation.x)
            {
                _ball.ChangeDir(-_ball.Dir.x, _ball.Dir.y);
            }
            else if (_ball.Pos.y - _ball.radio <= 0 ||_ball.Pos.y + _ball.radio >= _wallLocation.y)
            {
                _ball.ChangeDir(_ball.Dir.x, -_ball.Dir.y);
            }

        }


        public void SliderCollision()
        {
            if (_ball.Pos.y - _ball.radio > _slider.PosY)
            {
                return;
            }
            if (_ball.Pos.x - _ball.radio <= _slider.PosX + _slider.Size &&
                _ball.Pos.x + _ball.radio >= _slider.PosX - _slider.Size)
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
                if (_ball.Pos.y - _ball.radio > _slider.PosY)
                {
                    return;
                }
                if (_ball.Pos.x - _ball.radio <= bricks.PosX + bricks.Size &&
                    _ball.Pos.x + _ball.radio >= bricks.PosX - bricks.Size)
                {
                    bricks.Hit();
                    _ball.ChangeDir(_ball.Dir.x, -_ball.Dir.y);
                }
            }
        }
    }
}