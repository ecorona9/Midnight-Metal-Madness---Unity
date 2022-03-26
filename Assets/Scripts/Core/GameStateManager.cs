/*  File Description:
 *  GameStateManager is a class controls the state of the game
 */
using UnityEngine;

namespace MidnightMetalMadness
{
    public enum State { Start, Running, Paused, Death, Lost, Victory }

    public class GameStateManager : MonoBehaviour
    {     
        [SerializeField] private BoolEventSO pause_channel;

        private State current_state;

        private void Start()
        {
            current_state = State.Start;
            ActivateState();
        }

        private void ActivateState()
        {
            switch (current_state)
            {
                case State.Start:
                    {
                        Time.timeScale = 1f;
                        TransitionState(State.Running);
                        break;
                    }
                case State.Running:
                    break;

                case State.Paused:
                    {
                        pause_channel.RaiseEvent(true);
                        Time.timeScale = 0f;
                        break;
                    }
                case State.Death:
                    {
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
                        pause_channel.RaiseEvent(false);
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

        public void TransitionToLostState()
        {
            TransitionState(State.Death);
        }
    }
}
