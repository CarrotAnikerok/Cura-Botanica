using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AloeVera : Plant
{
    public override double normalWaterAmount
    {
        get { return _normalWaterAmount; }
        set { _normalWaterAmount = value; }
    }

    public override string state
    {
        get { return _state; }
        set { _state = value; }
    }

    public override string[] states
    {
        get { return _states; }
        set { _states = value; }
    }

    public override Sprite[] statesPicturesMini
    {
        get { return _statesPicturesMini; }
        set { _statesPicturesMini = value; }
    }

    public override Sprite[] statesPicturesBig
    {
        get { return _statesPicturesBig; }
        set { _statesPicturesBig = value; }
    }

    public override Image image
    {
        get { return _image; }
        set { _image = value; }
    }

    public override double phasesFromLastPour
    {
        get { return _fasesFromLastPour; }
        set { _fasesFromLastPour = value; }
    }

    public override bool alive
    {
        get { return _alive; }
        set { _alive = value; }
    }

    public override bool sharpDrop 
    {
        get { return _sharpDrop; }
        set { _sharpDrop = value; }
    }

    /* Plant Parameters */

    public override double waterCoefficient
    {
        get { return _waterCoefficient; }
        set { _waterCoefficient = value; }
    }

    public override int lightAmount
    {
        get { return _lightAmount; }
        set { _lightAmount = value; }
    }
    public override double humidity
    {
        get { return _humidity; }
        set { _humidity = value; }
    }
    public override int temperature
    {
        get { return _temperature; }
        set { _temperature = value; }
    }

    private bool _wateringTooOften;
    private int _dryCount; // count number of phases, when waterCoefficient = 0

    public AloeVera()
    {
        normalWaterAmount = 300f;
        waterCoefficient = 0.0f;
        state = states[2];
        phasesFromLastPour = 10;
        lightAmount = 3000;
        humidity = 0.6;
        temperature = 20;
        _dryCount = 0;
        _wateringTooOften = false;
    }

    // Methods
    public override void Dry()
    {
        DryLogic(0.1);
    }

    public override void Spray(double sprayHumidity)
    {
        SprayLogic(sprayHumidity);
    }

    public override void ChangeState()
    {
        int i = Array.FindIndex(states, x => x == state);

        // If waterint too often, aloe will die
        if (_wateringTooOften)
        {
            ChangeStateDown(i);
            Debug.Log("Pouring is too much");
            _wateringTooOften = false;
        }
        else
        {
            ChangeStateLogic(0.4f, 1f, 0.55, 0.85);
            Debug.Log("Pouring is okey");
        }

        // If pod is dry for 4 phases, aloe will die

        if (waterCoefficient == 0)
        {
            _dryCount += 1;
        }
        else
        {
            _dryCount = 0;
        }

        if (_dryCount >= 4)
        {
            ChangeStateDown(i);
        }

        phasesFromLastPour += 1;
        Debug.Log("Fases from last pour " + phasesFromLastPour);
    }

    public override void Pour(double waterAmount)
    {
        PourLogic(waterAmount);

        if (waterAmount >= 450)
        {
            sharpDrop = true;
        }

        if (phasesFromLastPour > 0 && phasesFromLastPour <=3)
        {
            phasesFromLastPour = 0;
            _wateringTooOften = true;
            Debug.Log("You are pouring it too often!");
        } 
        else if (waterAmount == 0)
        {
            phasesFromLastPour = phasesFromLastPour;
            Debug.Log("You didnt pour it");
        }
        else
        {
            phasesFromLastPour = 0;
            Debug.Log("Your pouring is okey");
        }
        Debug.Log(_wateringTooOften + " and " + phasesFromLastPour);
    }
}
