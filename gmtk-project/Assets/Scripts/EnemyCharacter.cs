using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    public bool visible = false;
    public bool turn = true;
    public GameObject gfx;
    public UnitManager unitMan;
    public Transform[] spawns;
    public UIManager uiMan;
    public Animator anim;
    Vector3 Position;

    private void Awake()
    {
        GetSpawn();
    }
    public override void Start()
    {
        base.Start();
        ToggleVisible(false);
        
    }

    private void Update()
    {
        if (unitMan.enemies.Count > 0)
        {
            for (int i = 0; i < unitMan.enemies.Count; i++)
            
            {
                Debug.Log(unitMan.enemies[0].name);
                float oppX = unitMan.enemies[0].transform.position.x - transform.position.x;
                float oppY = unitMan.enemies[0].transform.position.y - transform.position.y;

                Debug.Log(oppX + " : " + oppY);

                //If enemy in range of unit
                if ((oppX <= atkRange && oppX >= (atkRange * -1)) && (oppY <= atkRange && oppY >= (atkRange * -1)))
                {
                    Debug.Log("In");
                    if ((Time.time > lastAtk + atkRate))
                    {
                        anim.SetBool("Attacking", true);
                        Debug.Log("IN IN");
                        lastAtk = Time.time;
                        Attack(unitMan.enemies[0]);
                        anim.SetBool("Attacking", false);
                    }
                }
            }
        }
                

                /*float oppX = unitMan.enemies[i].transform.position.x - transform.position.x;
                float oppY = unitMan.enemies[i].transform.position.y - transform.position.y;

                //If enemy in range of unit
                if ((oppX <= atkRange && oppX >= (atkRange * -1)) && (oppY <= atkRange && oppY >= (atkRange * -1)))
                {
                    if ((Time.time > lastAtk + atkRate))
                    {
                        lastAtk = Time.time;
                        Attack(unitMan.enemies[i]);
                    }
                }

                
                
            }

        GameObject.FindGameObjectsWithTag("")*/

        
    }
    public override void Attack(GameObject opponent)
    {
        base.Attack(opponent);
    
        //Check if unit in proximity
        if (opponent.CompareTag("Patroller"))
        {
            opponent.GetComponent<Patroler>().TakeDamage(atk);
        }
        else if (opponent.CompareTag("Runner"))
        {
            opponent.GetComponent<Runner>().TakeDamage(atk);
        }
        else if (opponent.CompareTag("Knight"))
        {
            //Check if the unit is within attack range
            //if (turn && (Vector2.Distance(gameObject.transform.position, opponent.transform.position) <= atkRange))
            //{
            opponent.GetComponent<Knight>().TakeDamage(atk);
                //turn = false;  
            //}

        }
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
        uiMan.ToggleWin(true);
    }

    public void ToggleVisible(bool toggle)
    {
        //gfx.SetActive(toggle);
        visible = toggle;
    }

    public void GetSpawn()
    {
        int rng = Random.Range(0, spawns.Length);
        Position.x = (spawns[rng].position.x + 0.5f);
        Position.y = (spawns[rng].position.y + 0.5f);
        transform.position = Position;
    }

    


}
