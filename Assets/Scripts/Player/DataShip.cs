using UnityEngine;

[CreateAssetMenu(fileName = "NewDataShip", menuName = "Data ship", order = 151)]
public class DataShip : ScriptableObject
{
    [SerializeField] private int _maxLives;
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _speed;

    public int MaxLives => _maxLives;
    public int MaxHealth => _maxHealth;
    public float Speed => _speed;
}
