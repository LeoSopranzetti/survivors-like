using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject dropItemPrefab;
    [SerializeField] [Range(0f,1f)] float chance = 1f;

    bool isQuiting = false;

    private void OnApplicationQuit()
    {
        isQuiting = true;
    }

    private void OnDestroy()
    {

        if (isQuiting)
        {
            return;
        }

        float drop = Random.value;
        if (drop < chance)
        {
            Transform t = Instantiate(dropItemPrefab).transform;
            t.position = transform.position;
        }

    }
}