using System.Collections;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public float bounceDistance = 0.2f; // Расстояние для отскока
    public float bounceDuration = 0.01f; // Продолжительность отскока
    public float returnDuration = .03f; // Продолжительность возвращения на место

    private Vector3 initialPosition; // Начальная позиция объекта

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void TakeHit(Vector2 vectorAttract)
    {
        Vector3 bounceDirection = -vectorAttract.normalized;
        StartCoroutine(BounceCoroutine(bounceDirection));
    }
    private IEnumerator BounceCoroutine(Vector3 bounceDirection)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position + bounceDirection * bounceDistance;

        // Постепенно изменяем позицию объекта, чтобы создать эффект медленного отскока
        while (elapsedTime < bounceDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / bounceDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Возвращаем объект на место
        StartCoroutine(ReturnCoroutine());
    }

    private IEnumerator ReturnCoroutine()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        // Постепенно изменяем позицию объекта, чтобы вернуть его на начальную позицию
        while (elapsedTime < returnDuration)
        {
            transform.position = Vector3.Lerp(startPosition, initialPosition, elapsedTime / returnDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Возвращаем объект на точное место
        transform.position = initialPosition;
    }
}
