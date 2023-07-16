using System;
using UnityEngine;


namespace Utilities
{
    public class PhysicsManager:MonoBehaviour
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
            if (ball.Pos.x - radio <= _slider.PosX + _slider.Size &&
                ball.Pos.x + radio >= _slider.PosX - _slider.Size)
            {
                float ballPosX = ball.Pos.x;
                if (ballPosX < _slider.PosX - _slider.Center ||
                    ballPosX > _slider.PosX + _slider.Center)
                {
                    print("cotadito");
                    return new Vector2(ball.Dir.x - 0.25f, Math.Abs(ball.Dir.y));
                }

                print("Centro");
       
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
        public Vector2 BrickCollisionCheck(BallScript ball )
        {
            if (_map.BricksMap.ContainsKey(ball.Pos)) // Estoy en el centro
            {
                return Vector2.down;
            } 
            if(_map.BricksMap.ContainsKey((Vector2) ball.Pos + _map.BrickSize / 2)) // DER
            {
                return new Vector2(1, -1);
            }

            if (_map.BricksMap.ContainsKey((Vector2) ball.Pos + -_map.BrickSize / 2)) // IZQ
            {
                return new Vector2(-1, 1);

            }

            return ball.Speed;
        }
    }
}