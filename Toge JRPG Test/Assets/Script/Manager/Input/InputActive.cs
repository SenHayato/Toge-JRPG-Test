using UnityEngine;
using UnityEngine.InputSystem;

public class InputActive : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] InputAction moveAction, interactAction, pauseAction;

    [Header("Reference")]
    [SerializeField] PlayerActive playerActive;

    private void Awake()
    {
        moveAction = playerInput.actions.FindAction("Move");
        interactAction = playerInput.actions.FindAction("Interaction");
        pauseAction = playerInput.actions.FindAction("Pause");
    }

    private void Start()
    {
        playerActive = FindFirstObjectByType<PlayerActive>();
    }

    void MoveHandler()
    {
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();
        playerActive.moveValue = moveDirection;
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
