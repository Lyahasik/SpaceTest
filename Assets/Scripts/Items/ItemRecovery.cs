using UnityEngine;

public class ItemRecovery : MonoBehaviour
{
    enum ParameterRecovery : byte
    {
        Health,
        Live
    }

    [SerializeField] private ParameterRecovery _parameterRecovery;
    [SerializeField] private int _number;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (_parameterRecovery)
            {
                case ParameterRecovery.Health:
                    GameEventManager.SendChangeHealth(_number);
                    break;
                case ParameterRecovery.Live:
                    GameEventManager.SendChangeLives(_number);
                    break;
            }
        }
    }
}
