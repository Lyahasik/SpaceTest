using UnityEngine;

[CreateAssetMenu(fileName = "NewDataMeteor", menuName = "Data meteor", order = 152)]
public class DataMeteor : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _scale;

    public int Health => _health;
    public float Speed => _speed;
    public Vector3 Scale => _scale;
}
