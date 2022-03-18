/*
 * Summary:
 * 
 * EventManager contains all the possible events in the game
 * 
 * 
 */

using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance { get; private set; }

    public event Action<int> OnPlayerTakesDamage;

    public event Action OnPlayerDeath;

    private void Awake()
    {
        instance = this;
    }

    public void DecreasePlayerHealthInUI(int value)
    {
        OnPlayerTakesDamage?.Invoke(value);
    }

    public void LoseGame()
    {
        OnPlayerDeath?.Invoke();
    }
}
