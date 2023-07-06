using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


namespace RPG.Cinematics
{
    public class CinematicTrigger : MonoBehaviour
    {

        bool hasTriggered = false;
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player" && !hasTriggered)
            {
                hasTriggered = true;
                GetComponent<PlayableDirector>().Play();
            }
            
        }

    }
}

