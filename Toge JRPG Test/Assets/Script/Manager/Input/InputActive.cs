using Fungus;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActive : MonoBehaviour
{
    public static InputActive instance {  get; private set; }
    [SerializeField] PlayerInput playerInput;
    public InputAction moveAction, interactAction, pauseAction, runAction;

    [Header("Reference")]
    [SerializeField] PlayerActive playerActive;
    [SerializeField] GameManager gameManager;
    [SerializeField] DialogInput dialogInput;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }

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
        if (gameManager.gameState != GameState.Exploration)
        {
            playerActive.moveValue = Vector2.zero;
        }
        else
        {
            Vector2 moveDirection = moveAction.ReadValue<Vector2>();
            playerActive.moveValue = moveDirection;
            if (moveDirection != Vector2.zero)
            {
                RunningHandler();
            }
        }
    }

    public IInteractable currentInteractable;
    void Interaction()
    {
        if (interactAction.triggered)
        {
            if (gameManager.gameState == GameState.Exploration)
            {
                if (currentInteractable != null)
                {
                    currentInteractable.Interact();
                }
            }
            else if(gameManager.gameState == GameState.Dialog)
            {
                dialogInput.NewInputFlag();
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
