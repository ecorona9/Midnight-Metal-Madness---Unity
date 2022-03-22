/*  File Description:
 *  GameStateManager is a class controls the state of the game
 */
using UnityEngine;

namespace MidnightMetalMadness
{
    public class GameStateManager : MonoBehaviour
    {
        private enum State { Start, Running, Paused, Death, Lost, Victory }

        public static GameStateManager instance { get; private set; }

        private State current_state;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            EventManager.instance.OnPlayerDeath += EndGame;
            current_state = State.Start;
            ActivateState();
        }

        private void ActivateState()
        {
            switch (current_state)
            {
                case State.Start:
                    // Makes sure the game is resumed when the scene restarts
                    Time.timeScale = 1f;
                    TransitionState(State.Running);
                    break;

                case State.Running:
                    break;

                case State.Paused:
                    {
                        EventManager.instance.ShowPauseMenu();
                        Time.timeScale = 0f;
                        break;
                    }
                case State.Death:
                    {
                        // TODO: some death animation
                        Debug.Log("You have Died");
                        TransitionState(State.Lost);
                        break;
                    }
                case State.Lost:
                    {
                        Time.timeScale = 0f;
                        break;
                    }
                case State.Victory:
                    {
                        Time.timeScale = 0f;
                        break;
                    }

                default:
                    break;
            }
        }

        private void EndState()
        {
            switch (current_state)
            {
                case State.Start:
                    break;

                case State.Running:
                    break;

                case State.Paused:
                    {
                        EventManager.instance.HidePauseMenu();
                        Time.timeScale = 1f;
                        break;
                    }
                case State.Death:
                    break;

                case State.Lost:
                    {
                        Time.timeScale = 1f;
                        break;
                    }
                case State.Victory:
                    {
                        Time.timeScale = 1f;
                        break;
                    }
                default:
                    break;
            }
        }

        private void TransitionState(State new_state)
        {
            EndState();
            current_state = new_state;
            ActivateState();
        }

        private void Update()
        {
            switch (current_state)
            {
                case State.Start:
                    break;

                case State.Running:
                    {
                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                            TransitionState(State.Paused);
                        }
                        break;
                    }
                case State.Paused:
                    {
                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                            TransitionState(State.Running);
                        }
                        break;
                    }
                case State.Death:
                    break;
                case State.Lost:
                    break;
                case State.Victory:
                    break;
                default:
                    break;
            }
        }

        public bool IsGameOver()
        {
            if (current_state == State.Lost || current_state == State.Victory)
            {
                return true;
            }
            return false;
        }

        public void EndGame()
        {
            TransitionState(State.Death);
        }

        private void OnDestroy()
        {
            EventManager.instance.OnPlayerDeath -= EndGame;
        }
    }
}
