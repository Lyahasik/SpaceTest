using UnityEngine;

namespace Weapon
{
    public enum TypeAttack : byte
    {
        Queue,
        Laser
    }
    
    [CreateAssetMenu(fileName = "NewDataWeapon", menuName = "Data weapon", order = 153)]
    public class DataWeapon : ScriptableObject
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _delay;
        [SerializeField] private TypeAttack _typeAttack;
        [SerializeField] protected GameObject _prefabCartrige;

        public int Damage => _damage;
        public float Delay => _delay;
        public GameObject PrefabCartrige => _prefabCartrige;
        public TypeAttack TypeAttack => _typeAttack;
    }
}

