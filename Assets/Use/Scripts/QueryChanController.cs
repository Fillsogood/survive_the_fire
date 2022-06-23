using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class QueryChanController : MonoBehaviour
{
    private NavMeshAgent agent;
    private QuerySDEmotionalController motionalController;
    private QuerySDMecanimController mecanimController;
    private bool cur_state = true;
    public GameObject target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        motionalController = GetComponent<QuerySDEmotionalController>();
        mecanimController = GetComponent<QuerySDMecanimController>();
        // StartCoroutine(emotionManager());
    }

    void Update()
    {
        agent.SetDestination(target.transform.position);
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if(dist <= 3.0f)
        {
            if (cur_state)
            {
                StartCoroutine(mecanimManger());
                cur_state = false;
            }
        }
        else
        {
            mecanimController.ChangeAnimation(QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_RUN);
            cur_state = true;
        }
    }

    IEnumerator emotionManager()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            int emotionNum = Random.Range(0, 13);
            emotionNum = emotionNum >= 7 ? 4 : emotionNum;
            motionalController.ChangeEmotion((QuerySDEmotionalController.QueryChanSDEmotionalType)emotionNum);
        }
    }

    IEnumerator mecanimManger()
    {
        int mecanimNum = Random.Range(50, 90);
        mecanimNum = mecanimNum >= 60 ? 56 : mecanimNum;
        mecanimController.ChangeAnimation((QuerySDMecanimController.QueryChanSDAnimationType)mecanimNum);
        float waitNum = Random.Range(2.0f, 6.0f);
        yield return new WaitForSeconds(waitNum);
        cur_state = true;

    }
}
