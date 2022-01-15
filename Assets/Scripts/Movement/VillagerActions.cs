using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerActions : MonoBehaviour

{
    [SerializeField] float boundaryDistance = 5f;
    private bool hasBowed = false;

    private void Update()
    {
        var playerPosition = GameObject.Find("Player").transform.position;
        bool isInRange = Vector3.Distance(transform.position, playerPosition) < boundaryDistance;
        if (!isInRange)
        {
            hasBowed = false;
            return;
        }

        if(isInRange)
        {
            transform.LookAt(GameObject.Find("Player").transform);
            if(!hasBowed)
            {
                transform.LookAt(GameObject.Find("Player").transform);
                GetComponent<Animator>().SetTrigger("bow");
                hasBowed = true;
            }
        }
    }
}
