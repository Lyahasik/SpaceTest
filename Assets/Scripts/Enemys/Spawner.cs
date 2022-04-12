using System.Collections;
using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    [SerializeField] private MeteorLife _prefabEnemy;
    [SerializeField] private float _delay = 1;

    [Inject] private DiContainer _diContainer;

    private Vector2 _borderSpawn;

    private void Start()
    {
        _borderSpawn = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
        
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);

            Vector2 spawnPosition = new Vector2(
                transform.position.x + Random.Range(-_borderSpawn.x, _borderSpawn.x),
                transform.position.y + Random.Range(-_borderSpawn.y, _borderSpawn.y));
            _diContainer.InstantiatePrefab(_prefabEnemy, new Vector3(spawnPosition.x, spawnPosition.y, 0.0f), Quaternion.identity, null);
        }
    }
}
