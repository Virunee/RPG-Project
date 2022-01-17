using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerActions : MonoBehaviour

{
    [SerializeField] float boundaryDistance = 5f;
    private bool hasBowed = false;
    float timeSinceLastBow = Mathf.Infinity;
    float bowDelay = 10f;

    private void Update()
    {
        var playerPosition = GameObject.Find("Player").transform.position;
        bool isInRange = Vector3.Distance(transform.position, playerPosition) < boundaryDistance;
        if (!isInRange)
        {
            timeSinceLastBow += Time.deltaTime;
            hasBowed = false;
            return;
        }

        if(isInRange)
        {
            transform.LookAt(GameObject.Find("Player").transform);
            if(!hasBowed && timeSinceLastBow > bowDelay)
            {
                transform.LookAt(GameObject.Find("Player").transform);
                GetComponent<Animator>().SetTrigger("bow");
                hasBowed = true;
                timeSinceLastBow = 0;
            }
        }
    }
}
