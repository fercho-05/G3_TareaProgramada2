using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    //define cuanto daño causa el golpe
    [SerializeField]
    float damage = 100.0F; //daño del 100%

    //define cuantos ataques por segundo
    [SerializeField]
    int attackRate = 1;

    [SerializeField]

    float _attackTime;

    void Update()
    {
        _attackTime -= Time.deltaTime;
        if (Input.GetButton("Fire1")) 
        { 
            if (_attackTime <= 0.0F)
            {
                Character2DController.Instance.Attack(damage);
                _attackTime = 1.0F / attackRate;
            }
        }
    }
}
