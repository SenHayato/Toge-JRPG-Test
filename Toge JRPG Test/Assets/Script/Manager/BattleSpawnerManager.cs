using UnityEngine;

public class BattleSpawnerManager : Singleton<BattleSpawnerManager>
{
    [Header("Spawn Position")]
    [SerializeField] Transform playerSpawnPosition;
    [SerializeField] Transform enemySpawnPosition;
    [SerializeField] Transform cameraSpawnPosition;

    [Header("Unit Reference")]
    [SerializeField] PlayerActive playerActive;
    [SerializeField] BossActive bossActive;
    [SerializeField] Camera mainCamera;

    [Header("Properties")]
    [SerializeField] float moveSpeed;

    public void AssignComponent()
    {
        Debug.Log("Test");
        mainCamera = Camera.main;
        playerActive = FindFirstObjectByType<PlayerActive>();
        bossActive = FindFirstObjectByType<BossActive>();
    }

    public void MoveToPosition(CharacterController unitToMove, Transform target)
    {
        Vector3 direction = (target.position - unitToMove.transform.position).normalized;

        unitToMove.Move(direction * moveSpeed * Time.deltaTime);
    }

    public void SpawnUnit()
    {
        mainCamera.transform.position = cameraSpawnPosition.position;
        playerActive.transform.position = playerSpawnPosition.position;
        bossActive.transform.position = enemySpawnPosition.position;
    }
}
