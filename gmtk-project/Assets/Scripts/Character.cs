using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public int health;
    public int maxHealth;
    public int atk;
    public int movementPoints;
    public int atkRange;
    public State state = State.Idle;

    public float lastAtk = -1f;
    public float atkRate = 1f;

    public virtual void Start() { }

    public void Setup()
    {
        health = maxHealth;
    }

    public void Move()
    {
        
    }

    public virtual void Attack(GameObject opponent)
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die() 
    {
        Destroy(gameObject);
    }

    

}

public enum State
{
    Idle,
    Walk,
    Attack,
    Die
}
