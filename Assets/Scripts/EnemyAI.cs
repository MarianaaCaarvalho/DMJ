using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _enemy;
    private GameObject _player;
    
    // Start is called before the first frame update
    void Awake()
    {
        _enemy = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshPath _path = new NavMeshPath();
        _enemy.CalculatePath(_player.transform.position, _path);
        _enemy.SetPath(_path);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
}