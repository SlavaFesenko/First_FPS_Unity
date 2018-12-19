using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    private GameObject _enemy;
	
	// Update is called once per frame
	void Update ()
	{
	    if (_enemy != null)
	        return;

        _enemy = Instantiate(enemyPrefab) as GameObject;
        _enemy.transform.position = new Vector3(15, 20, 20);
	    float angle = Random.Range(0, 360);
        _enemy.transform.Rotate(-50, angle, 0);
	}
}
