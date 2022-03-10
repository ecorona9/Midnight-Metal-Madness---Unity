/*  File Description:
 *  GameStateManager is a class controls the state of the game
 */
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private enum State { Start, Running, Paused, Death, GameOver, Victory }

    public static GameStateManager instance { get; private set; }

    private State current_state;

    private void Awake()
    {
        instance = this;
    }

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
                // Makes sure the game is resumed when the scene restarts
                Time.timeScale = 1f;
                TransitionState(State.Running);
                break;

            case State.Running:
                break;

            case State.Paused:
                Time.timeScale = 0f;
                break;

            case State.Death:
                break;

            case State.GameOver:
                break;

            case State.Victory:
                break;

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
                Time.timeScale = 1f;
                break;

            case State.Death:
                break;

            case State.GameOver:
                break;

            case State.Victory:
                break;

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

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TransitionState(State.Paused);
                }

                break;

            case State.Paused:

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TransitionState(State.Running);
                }

                break;

            case State.Death:
                break;

            case State.GameOver:
                break;

            case State.Victory:
                break;

            default:
                break;
        }
    }
}
