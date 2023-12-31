using System;
using MyEngine;
using UnityEngine;
using Utilities.Parents;
using Utilities.Updates;
using Random = UnityEngine.Random;

namespace Utilities
{
    public class Bricks : Entity
    {
        [SerializeField]private BricksSO _data;
        private int _hitsLeft;

        public override void Initialize()
        {
            base.Initialize();
            _hitsLeft = _data.Hits;
            GameManager.Instance.ModifyCurrentBricks(1);
        }

        public void Hit()
        {
            _hitsLeft--;
            
            if (_hitsLeft <= 0)
            {
                GameManager.Instance.physicsManager.UnList(this);
                Die();
            }
        }
        
        private void Die()
        {
            gameObject.SetActive(false);
            int dropProb =Random.Range(0, 100);
            if(dropProb < 5)
            {
                Upgrade upgrade = Instantiate(_data._upgrades[0], transform.position,Quaternion.identity);
                upgrade.Initialize();
            }

            GameManager.Instance.ModifyCurrentBricks(-1);
            GameManager.Instance.AddPoints(100*_data.Hits);
            AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.brickDestroyed);
        }
    }
}