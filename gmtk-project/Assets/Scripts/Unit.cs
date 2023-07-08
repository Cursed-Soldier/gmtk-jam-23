using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int health;
    public int maxHealth;
    public int atk;
    public int movementPoints;
    public int spotRadius;
    public State state = State.Idle;

    private void Start()
    {
        health = maxHealth;
    }

    public void Move()
    {
        //Move unit by movement points
    }

    public void Attack(GameObject opponent)
    {
       //Attack opponent
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Spot()
    {
        //Spot opponent
    }

    private void Die()
    {
        Debug.Log("Unit died");
    }
}

public enum State
{
    Idle,
    Walk,
    Attack,
    Die
}