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

    public event Action<int> OnPlayerShoot;

    public event Action<int, Sprite> OnPlayerSwapWeapon;

    private void Awake()
    {
        instance = this;
    }

    public void DisplayPlayerHealth(int value)
    {
        OnPlayerTakesDamage?.Invoke(value);
    }

    public void LoseGame()
    {
        OnPlayerDeath?.Invoke();
    }

    public void DisplayCurrentAmmoCount(int value)
    {
        OnPlayerShoot?.Invoke(value);
    }

    public void DisplayMaximumAmmoCount(int value, Sprite image)
    {
        OnPlayerSwapWeapon?.Invoke(value, image);
    }


}
