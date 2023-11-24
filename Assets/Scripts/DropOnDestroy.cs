using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] List<GameObject> dropItemPrefab;
    [SerializeField] [Range(0f,1f)] float chance = 1f;

    bool isQuiting = false;

    private void OnApplicationQuit()
    {
        isQuiting = true;
    }

    public void CheckDrop()
    {

        if (isQuiting)
        {
            return;
        }

        float drop = Random.value;
        if (drop < chance)
        {
            GameObject toDrop = dropItemPrefab[Random.Range(0, dropItemPrefab.Count)];
            SpawnManager.instance.SpawnObject(transform.position, toDrop);
        }

    }
}
