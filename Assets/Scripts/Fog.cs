using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public bool isAI;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAI)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //Destroy(other.gameObject);
                print("level failed");
                GameManager.Instance.MissionFailed();
            }
        }
        else
        {
            if (other.gameObject.CompareTag("AI"))
            {
                Destroy(other.gameObject);
                print("level complete");
                GameManager.Instance.MissionComplete();
            }
        }
        
    }
}
