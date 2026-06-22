using UnityEngine;
using UnityEngine.InputSystem;

public class InputActive : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] InputAction moveAction, interactAction, pauseAction;

    private void Awake()
    {
        moveAction = playerInput.actions.FindAction("Move");
        interactAction = playerInput.actions.FindAction("Interaction");
        pauseAction = playerInput.actions.FindAction("Pause");
    }

    void MoveHandler()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        //Debug.Log("Move Value " + moveValue);
    }

    void Interaction()
    {
        if (interactAction.triggered)
        {
            Debug.Log("Interaction");
        }
    }

    void PauseButton()
    {
        if (pauseAction.triggered)
        {
            Debug.Log("Pause Menu");
        }
    }

    private void Update()
    {
        MoveHandler();
        Interaction();
        PauseButton();
    }
}
