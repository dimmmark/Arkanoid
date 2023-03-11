using System.Collections;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public float bounceDistance = 0.2f; // ���������� ��� �������
    public float bounceDuration = 0.01f; // ����������������� �������
    public float returnDuration = .03f; // ����������������� ����������� �� �����

    private Vector3 initialPosition; // ��������� ������� �������

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

        // ���������� �������� ������� �������, ����� ������� ������ ���������� �������
        while (elapsedTime < bounceDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / bounceDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ���������� ������ �� �����
        StartCoroutine(ReturnCoroutine());
    }

    private IEnumerator ReturnCoroutine()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        // ���������� �������� ������� �������, ����� ������� ��� �� ��������� �������
        while (elapsedTime < returnDuration)
        {
            transform.position = Vector3.Lerp(startPosition, initialPosition, elapsedTime / returnDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ���������� ������ �� ������ �����
        transform.position = initialPosition;
    }
}
