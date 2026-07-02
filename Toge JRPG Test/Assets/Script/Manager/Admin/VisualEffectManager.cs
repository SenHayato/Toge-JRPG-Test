using UnityEngine;

public class VisualEffectManager : Singleton<VisualEffectManager>
{
    public VisualEffectSO visualLibrary;
    [SerializeField] Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    GameObject GetEffect(VisualType type)
    {
        VisualEffect effect = visualLibrary.effects.Find(e => e.VisualType == type);

        return effect != null ? effect.visualObj : null;
    }

    public void PlayEffect(VisualType type, Vector3 position)
    {
        GameObject prefab = GetEffect(type);

        if (prefab == null)
        {
            Debug.LogWarning($"Visual Effect {type} tidak ditemukan.");
            return;
        }

        Instantiate(prefab, position, Quaternion.identity);
    }

    public void CamereShake()
    {

    }
}
