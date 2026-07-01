using System.Collections;
using UnityEngine;

public class StateMachine
{
    public IState CurrentState { get; private set; }
    private MonoBehaviour coroutineRunner;

    public StateMachine(MonoBehaviour runner)
    {
        coroutineRunner = runner;
    }

    private IEnumerator EnterState()
    {
        CurrentState.Enter();

        //penjeda jika perlu waktu
        yield return null;
    }

    public void ChangeState(IState newState)
    {
        if (CurrentState != null)
        {
            CurrentState.Exit();
        }

        CurrentState = newState;
        coroutineRunner.StartCoroutine(EnterState());
    }


    public void Update()
    {
        CurrentState?.Update();
    }
}
