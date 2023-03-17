using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_shake : MonoBehaviour
{
    public IEnumerator shake (float duration, float magn) {
        Vector2 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration) {
            float x = Random.Range(-1f, 1f) * magn;
            float y = Random.Range(-1f, 1f) * magn;
            transform.localPosition = new Vector2(x, y);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
