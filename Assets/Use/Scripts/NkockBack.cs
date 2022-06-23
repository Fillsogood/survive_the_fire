using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class NkockBack : MonoBehaviour
{
    // Start is called before the first frame update
    private FirstPersonController firstPersonController;
    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Burn_Area")
        {
            firstPersonController.enabled = false;
            Vector3 reactVec = transform.position - other.transform.position;
            reactVec = reactVec.normalized;
            Debug.Log(reactVec.ToString());
            transform.position = transform.position + reactVec;
            Invoke("EnableScript", 0.5f);
        }
    }

    private void EnableScript()
    {
        firstPersonController.enabled = true;
    }

}
