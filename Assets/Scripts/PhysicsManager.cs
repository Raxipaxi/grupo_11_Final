using System;
using System.Collections.Generic;
using UnityEngine;


namespace Utilities
{
    public class PhysicsManager:MonoBehaviour
    {
        private Slider _slider;
        private MapCreation _map;
        private List<Bricks> _bricksList;
         public void Initialize (Slider slider, MapCreation mapCreator, List<Bricks> bricksList)
        {
            _slider = slider;
            _map = mapCreator;
            _bricksList = bricksList;
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
        public Vector2 BrickCollisionCheck(BallScript ball, float radio)
        {
            // for (int i = 0; i < _bricksList.Count; i++)
            // {
            //     Bricks currBrick = _bricksList[i];
            //     if (ball.Pos.x - radio <= currBrick.PosX + _slider.Size &&
            //         ball.Pos.x + radio >= currBrick.PosX - _slider.Size)
            //     {
            //         float ballPosX = ball.Pos.x;
            //         if (ballPosX < currBrick.PosX - currBrick.Center ||
            //             ballPosX > currBrick.PosX + currBrick.Center)
            //         {
            //             print("cotadito");
            //             return new Vector2(ball.Dir.x - 0.25f, Math.Abs(ball.Dir.y));
            //         }
            //
            //         print("Centro");
            //
            //         return new Vector2(ball.Dir.x, Math.Abs(ball.Dir.y));
            //     }
            // }

            // if (_map.BricksMap.ContainsKey(ball.Pos)) // Estoy en el centro
            // {
            //     return new Vector2(ball.Dir.x, Math.Abs(-ball.Dir.y));
            //
            // } 
            // if(_map.BricksMap.ContainsKey((Vector2) ball.Pos + _map.BrickSize / 2)) // DER
            // {
            //     return new Vector2(ball.Dir.x - 0.25f, Math.Abs(-ball.Dir.y));
            //
            // }
            //
            // if (_map.BricksMap.ContainsKey((Vector2) ball.Pos + -_map.BrickSize / 2)) // IZQ
            // {
            //     return new Vector2(ball.Dir.x - 0.25f, Math.Abs(-ball.Dir.y));
            //
            //
            // }

            return ball.Dir;
        }
    }
}