using System;

public static class GameEventManager
{
    public static Action<DataShip> OnUploadDataUI;
    public static Action OnGameOver;

    public static Action OnKillPlayer;
    public static Action<int> OnChangeHealth;
    public static Action<int> OnChangeLives;
    
    public static Action<int> OnChangeScore;
    public static Action<IEnemyLife> OnDestroyEnemy;

    public static void Clear()
    {
        OnUploadDataUI = null;
        OnGameOver = null;

        OnKillPlayer = null;
        OnChangeHealth = null;
        OnChangeLives = null;
        
        OnChangeScore = null;
        OnDestroyEnemy = null;
    }

    public static void SendUploadDataUI(DataShip value)
    {
        OnUploadDataUI?.Invoke(value);
    }
    
    public static void SendGameOver()
    {
        OnGameOver?.Invoke();
    }

    public static void SendKillPlayer()
    {
        OnKillPlayer?.Invoke();
    }
    
    public static void SendChangeHealth(int value)
    {
        OnChangeHealth?.Invoke(value);
    }

    public static void SendChangeLives(int value)
    {
        OnChangeLives?.Invoke(value);
    }

    public static void SendChangeScore(int value)
    {
        OnChangeScore?.Invoke(value);
    }

    public static void SendDestroyEnemy(IEnemyLife enemy)
    {
        OnDestroyEnemy?.Invoke(enemy);
    }
}
