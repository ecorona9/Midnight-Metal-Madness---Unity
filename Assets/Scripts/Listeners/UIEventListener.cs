using UnityEngine;
using UnityEngine.Events;

namespace MidnightMetalMadness
{
    public class UIEventListener : MonoBehaviour
    {
        [SerializeField] private IntEventSO current_ammo_channel;
        [SerializeField] private IntEventSO maximum_ammo_channel;
        [SerializeField] private IntEventSO player_health_channel;
        [SerializeField] private SpriteEventSO sprite_change_channel;
        [SerializeField] private BoolEventSO pause_channel;
        [SerializeField] private VoidEventSO gameover_channel;
        [SerializeField] private VoidEventSO coin_channel;
        [SerializeField] private VoidEventSO score_channel;
        [SerializeField] private VoidEventSO level_complete_channel;

        public IntEvent OnCurrentAmmoChange;
        public IntEvent OnMaximumAmmoChange;
        public IntEvent OnPlayerHealthChange;
        public SpriteEvent OnWeaponSwap;
        public BoolEvent OnPauseKeyPressed;
        public UnityEvent OnPlayerDeath;
        public UnityEvent OnCoinPickup;
        public UnityEvent OnEnemyKilled;
        public UnityEvent OnWinningConditionMet;

        private void OnEnable()
        {
            current_ammo_channel.OnEventRaised += ChangeCurrentAmmo;
            maximum_ammo_channel.OnEventRaised += ChangeMaximumAmmo;
            player_health_channel.OnEventRaised += ChangePlayerHealth;
            sprite_change_channel.OnEventRaised += ChangeSpriteImage;
            pause_channel.OnEventRaised += ShowPauseMenu;
            gameover_channel.OnEventRaised += ShowGameOverMenu;
            coin_channel.OnEventRaised += IncreaseCoinCount;
            score_channel.OnEventRaised += IncreaseScore;
            level_complete_channel.OnEventRaised += ShowLevelCompleteMenu;
        }

        private void OnDisable()
        {
            current_ammo_channel.OnEventRaised -= ChangeCurrentAmmo;
            maximum_ammo_channel.OnEventRaised -= ChangeMaximumAmmo;
            player_health_channel.OnEventRaised -= ChangePlayerHealth;
            sprite_change_channel.OnEventRaised -= ChangeSpriteImage;
            pause_channel.OnEventRaised -= ShowPauseMenu;
            gameover_channel.OnEventRaised -= ShowGameOverMenu;
            coin_channel.OnEventRaised -= IncreaseCoinCount;
            score_channel.OnEventRaised -= IncreaseScore;
            level_complete_channel.OnEventRaised -= ShowLevelCompleteMenu;
        }

        private void ChangeCurrentAmmo(int value)
        {
            OnCurrentAmmoChange?.Invoke(value);
        }

        private void ChangeMaximumAmmo(int value)
        {
            OnMaximumAmmoChange?.Invoke(value);
        }

        private void ChangeSpriteImage(Sprite image)
        {
            OnWeaponSwap?.Invoke(image);
        }

        private void ShowPauseMenu(bool condition)
        {
            OnPauseKeyPressed?.Invoke(condition);
        }

        private void ChangePlayerHealth(int value)
        {
            OnPlayerHealthChange?.Invoke(value);
        }

        private void ShowGameOverMenu()
        {
            OnPlayerDeath?.Invoke();
        }

        private void IncreaseCoinCount()
        {
            OnCoinPickup?.Invoke();
        }

        private void IncreaseScore()
        {
            OnEnemyKilled?.Invoke();
        }

        private void ShowLevelCompleteMenu()
        {
            OnWinningConditionMet?.Invoke();
        }
    }
}
