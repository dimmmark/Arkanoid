using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] GameObject _lifeIconPrefab;
    [SerializeField] List<GameObject> _lifeIcons = new List<GameObject>();
    
    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newLifeIcon = Instantiate(_lifeIconPrefab, transform);
            _lifeIcons.Add(newLifeIcon);
        }
    }
    public void LifeIconOff(int health)
    {
        for (int i = 0; i < _lifeIcons.Count; i++)
        {
            if (i < health)
                _lifeIcons[i].SetActive(true);
            else
                _lifeIcons[i].SetActive(false);
        }
    }
}
