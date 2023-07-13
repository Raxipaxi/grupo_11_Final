using System;
using UnityEngine;

namespace Utilities
{
    public class PhysicsManager
    {
        private Slider _slider;
        private MapCreation _map;

         public PhysicsManager(Slider slider, MapCreation mapCreator)
        {
            _slider = slider;
            _map = mapCreator;
        }

        public Vector2 SliderCollision(BallScript ball, float radio)
        {
            if (ball.transform.position.x + radio >= _slider.transform.position.x + _slider.Size.x / 2 ||
                ball.transform.position.x + radio <= _slider.transform.position.x - _slider.Size.x / 2)
            {
                return new Vector2(ball.Dir.x, Math.Abs(ball.Dir.y));

            }
            // if (ball.transform.position.x + radio <= _slider.transform.position.x - _slider.Size.x) // Si toco la mitad del lado izquierdo (negativo) me voy para x en el lado izquierdo
            // {
            //     
            //     return new Vector2(ball.Dir.x, Math.Abs(ball.Dir.y));
            // }
            // if (ball.transform.position.x + radio >= _slider.transform.position.x  + _slider.Size.x)
            // {
            //         return  new Vector2(ball.Dir.x, Math.Abs(ball.Dir.y));
            // }

            return ball.Dir;
        }
        public Vector2 BrickCollisionCheck(BallScript ballPos, float radio )
        {
            if (_map.BricksMap.ContainsKey(ballPos.transform.position)) // Estoy en el centro
            {
                return Vector2.down;
            } 
            if(_map.BricksMap.ContainsKey((Vector2) ballPos.transform.position + _map.BrickSize / 2)) // DER
            {
                return new Vector2(1, -1);
            }

            if (_map.BricksMap.ContainsKey((Vector2) ballPos.transform.position + -_map.BrickSize / 2)) // IZQ
            {
                return new Vector2(-1, 1);

            }

            return ballPos.Speed;
        }
    }
}