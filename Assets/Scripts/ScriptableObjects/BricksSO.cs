using UnityEngine;
using Utilities.Updates;

namespace Utilities
{
    [CreateAssetMenu(fileName = "New Brick", menuName = "Bricks", order = 0)]
    public class BricksSO : ScriptableObject
    {
        #region SerializeFields
        [field:SerializeField]public Upgrade[] _upgrades;

        [field:SerializeField] public int Hits { get; private set;} 
        #endregion

    }
}