using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        Vector3 fallVector = new Vector3(-75, 0, 0);
        this.transform.Rotate(fallVector);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
