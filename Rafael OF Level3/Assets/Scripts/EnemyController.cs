using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private PlayerController player;
    private float distance = 999;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();    
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
    }
}