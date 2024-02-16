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
    public Animator animator;
    private int lives = 3;
    private bool livesChanged = false;
    private float _timer;

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

        if (livesChanged)
        {
            animator.enabled = false;
            _enemy.speed = 0f;
            _timer += Time.deltaTime;
            if (_timer > 2f)
            {
                _enemy.speed = 1f;
                _timer = 0;
                livesChanged = false;
                animator.enabled = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (lives == 0)
            {
                SceneManager.LoadScene("DeadScene");
            }
            else
            {
                lives -= 1;
                livesChanged = true;
            }
        }
    }
}