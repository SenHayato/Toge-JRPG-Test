using UnityEngine;
using UnityEngine.InputSystem;

public class InputActive : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    public InputAction moveAction, interactAction, pauseAction, runAction;

    [Header("Reference")]
    [SerializeField] PlayerActive playerActive;

    private void Awake()
    {
        moveAction = playerInput.actions.FindAction("Move");
        interactAction = playerInput.actions.FindAction("Interaction");
        pauseAction = playerInput.actions.FindAction("Pause");
        runAction = playerInput.actions.FindAction("Run");
    }

    private void Start()
    {
        playerActive = FindFirstObjectByType<PlayerActive>();
    }

    void MoveHandler()
    {
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();
        playerActive.moveValue = moveDirection;
        if (moveDirection != Vector2.zero)
        {
            RunningHandler();
        }
    }

    public IInteractable currentInteractable;
    void Interaction()
    {
        if (interactAction.triggered)
        {
            if (currentInteractable != null)
            {
                currentInteractable.Interact();
            }
            Debug.Log("Interact Button");
        }
    }

    void PauseButton()
    {
        if (pauseAction.triggered)
        {
            Debug.Log("Pause Menu");
        }
    }

    void RunningHandler()
    {
        if (runAction.IsPressed())
        {
            playerActive.isRunning = true;
        }
        else
        {
            playerActive.isRunning = false;
        }
    }

    private void Update()
    {
        MoveHandler();
        Interaction();
        PauseButton();
    }
}
