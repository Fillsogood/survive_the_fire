using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterCtrl : MonoBehaviour, IDamageable
{
    private Transform mosterTr;
    private Transform playerTr;
    private NavMeshAgent agent;
    private Animator anim;
    private readonly int hashTrace = Animator.StringToHash("IsTrace");
    private readonly int hashAttack = Animator.StringToHash("IsAttack");
    
    public enum State
    {
        IDLE,
        TRACE,
        ATTACK,
        DIE
    }
    public State state = State.IDLE;
    public float traceDist = 10.0f;
    public float attackDist = 2.0f;
    public bool isDie = false;

    
    int currentHealth = 100;
    void Start()
    {
        //몬스터의 Transform 할당
        mosterTr = GetComponent<Transform>();

        //추적 대상인 player의 Transform 할당
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();

        //NavMeshAgent 컴포넌트 할당
        agent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();

        StartCoroutine(CheckMosterState());

        StartCoroutine(MosterAction());
    }
    IEnumerator CheckMosterState()
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.3f);

            float distance = Vector3.Distance(playerTr.position, mosterTr.position);

            if(distance <= attackDist)
            {
                state = State.ATTACK;
            }
            else if(distance <=traceDist)
            {
                state = State.TRACE;
            }
            else
            {
                state = State.IDLE;
            }
        }
    }
    //몬스터의 상태에 따라 몬스터의 동작을 수행
    IEnumerator MosterAction()
    {
        while(!isDie)
        {
            switch(state)
            {
                case State.IDLE:
                    agent.isStopped = true;
                    anim.SetBool(hashTrace, false);
                    break;
                case State.TRACE:
                    agent.SetDestination(playerTr.position);
                    agent.isStopped = false;
                    anim.SetBool(hashTrace, true);
                    anim.SetBool(hashAttack, false);
                    break;
                case State.ATTACK:
                    anim.SetBool(hashAttack, true);
                    break;
                case State.DIE:
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }


    void Update()
    {
        
    }
 

    void IDamageable.TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Debug.Log(this.name + "_" + currentHealth);
        if (currentHealth < 100 && currentHealth >= 60)
        {
            this.transform.localScale = new Vector3(2, 2, 2);
            
        }
        else if (currentHealth == 20)
        {
            this.transform.localScale = new Vector3(1, 1, 1);

        }
        else if (currentHealth <= 0)
        {  
            Die();
        }
        else { }
 
    }
    void Die()
    {
        GameManager.Monster_Count--;
        Destroy(this.gameObject);
    }
}
