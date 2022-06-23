using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterCtrl : MonoBehaviour
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
                    anim.SetBool("IsTrace", false);
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
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.collider.CompareTag)
    }
    //사거리표시는 따로 안 만듬 필요하면 만듬
    //private void OnDrawGizmos()
    //{

    //}

    void Update()
    {
        
    }
}
