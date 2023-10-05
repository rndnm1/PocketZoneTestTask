using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PrefabManager : MonoBehaviour
{
    public static List<GameObject> BulletPrefabs = new List<GameObject>();
    public static GameObject EnemyPrefab;
    public static GameObject CollectibleItemPrefab;

    public static GameObject ItemVisualizationPrefab;

    [Header("-Entity prefabs")]
    [SerializeField] private List<GameObject> bulletPrefabs;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject collectibleItemPrefab;

    [Header("-UI prefabs")]
    [SerializeField] private GameObject itemVisualizationPrefab;

    private void OnEnable()
    {
#if UNITY_EDITOR
        ApplyPrefabs();
#endif
    }

    private void ApplyPrefabs()
    {
        BulletPrefabs = bulletPrefabs;
        EnemyPrefab = enemyPrefab;
        CollectibleItemPrefab = collectibleItemPrefab;

        ItemVisualizationPrefab = itemVisualizationPrefab;
    }
}
