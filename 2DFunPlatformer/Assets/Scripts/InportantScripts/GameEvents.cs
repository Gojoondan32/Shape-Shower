using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    #region Singleton
    public static GameEvents instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public event Action<int> dashCountChanged;

    public event Action<Vector3> blockSpawning;
    public event Action playerDied;

    public void DashCountChanged(int count)
    {
        dashCountChanged.Invoke(count);
    }

    public void BlockSpawning(Vector3 position) => blockSpawning.Invoke(position);

    public void PlayerDied() => playerDied.Invoke();
}
