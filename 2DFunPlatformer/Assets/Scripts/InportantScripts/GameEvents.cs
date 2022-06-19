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

    #region UI Events
    public event Action<int> dashCountChanged;
    public void DashCountChanged(int count) => dashCountChanged.Invoke(count);
    #endregion



    public event Action<Vector3> blockSpawning;
    public event Action playerDied;



    public void BlockSpawning(Vector3 position) => blockSpawning.Invoke(position);

    public void PlayerDied() => playerDied.Invoke();
}
