using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementMovement : MonoBehaviour {


    public GameObject firstGameO, secondGameO, targetGameO, panel;

    private float speed = 200f;

    public void OnUI()
    {
        StopAllCoroutines();
        if (panel.gameObject.activeInHierarchy)
        {
             StartCoroutine(UICoroutine());
        }
       
    }

    public void StopUI()
    {
        StopCoroutine(UICoroutine());
        panel.SetActive(false);
        firstGameO.transform.position = secondGameO.transform.position;
    }

    private IEnumerator UICoroutine()
    {
        while (true)
        {
            while(Vector3.Distance (firstGameO.transform.position, targetGameO.transform.position)> 1f)
            {
                firstGameO.transform.position = Vector3.MoveTowards(firstGameO.transform.position, targetGameO.transform.position, Time.deltaTime*speed);
                yield return new WaitForSeconds(0.02f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
