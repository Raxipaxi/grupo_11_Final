using System;
using UnityEngine;
using Utilities.Parents;

namespace Utilities
{
    public class Bricks : Entity
    {
        [SerializeField]private BricksSO _data;
        private int _hitsLeft;
        private void Start()
        {
            _hitsLeft = _data.Hits;
        }

        public void Hit()
        {
            _hitsLeft--;
            if (_hitsLeft <= 0)
                Die();
        }
        
        private void Die()
        {
            gameObject.SetActive(false);
            AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.brickDestroyed);
        }
    }
}