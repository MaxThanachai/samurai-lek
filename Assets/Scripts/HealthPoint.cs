using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    public int defaultMaxHealthPoint = 1;

    private int maxHealthPoint;
    private int healthPoint;

    void Start()
    {
        maxHealthPoint = defaultMaxHealthPoint;
        healthPoint = maxHealthPoint;
    }

    public int GetHealthPoint()
    {
        return healthPoint;
    }

    public void ModifyHealthPoint(int hp)
    {
        healthPoint += hp;
        CheckHealthPoint();
    }

    public int GetMaxHealthPoint()
    {
        return maxHealthPoint;
    }

    public int SetMaxHealthPoint(int newMaxHp)
    {
        if (newMaxHp < 1)
        {
            return maxHealthPoint;
        }
        maxHealthPoint = newMaxHp;
        return maxHealthPoint;
    }

    public int ModifyMaxHealthPoint(int hp)
    {
        if (maxHealthPoint + hp < 1)
        {
            return maxHealthPoint;
        }
        maxHealthPoint += hp;
        return maxHealthPoint;
    }

    public int ResetMaxHealthPoint()
    {
        maxHealthPoint = defaultMaxHealthPoint;
        return maxHealthPoint;
    }

    private void CheckHealthPoint()
    {
        if (healthPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
