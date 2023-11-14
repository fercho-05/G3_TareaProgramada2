using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DaylightCicleController : MonoBehaviour
{
    [SerializeField]
    Light2D globalLight;

    [SerializeField]
    DaylightCicle[] daylightCicles;

    [SerializeField]
    float cicleLifeTime = 5.0F;

    int _currentCicle;
    int _nextCicle;


    float _currentLifeTime;
    float _ciclePercentage;

    Color _currentColor;
    Color _nextColor;


    void Start()
    {
        _currentCicle = 0;
        _nextCicle = _currentCicle + 1;
        globalLight.color = daylightCicles[_currentCicle].color;
    }

    void Update()
    {
        _currentLifeTime += Time.deltaTime;
        _ciclePercentage = _currentLifeTime / cicleLifeTime;

        if (_currentLifeTime >= cicleLifeTime)
        {
            _currentLifeTime = 0.0F;
            _currentCicle += 1;

            if (_currentCicle >= daylightCicles.Length)
            {
                _currentCicle = 0;
            }


            _nextCicle = _currentCicle + 1;
            if (_nextCicle >= daylightCicles.Length)
            {
                _nextCicle = 0;
            }

            _currentColor = daylightCicles[_currentCicle].color;
            _nextColor = daylightCicles[_nextCicle].color;
        }

        ChangeColor();
    }

    void ChangeColor()
    {
        globalLight.color = Color.Lerp(_currentColor, _nextColor, _ciclePercentage);
    }


}
