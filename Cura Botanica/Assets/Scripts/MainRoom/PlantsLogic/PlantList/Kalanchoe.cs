using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kalanchoe : Plant
{
    public override string plantName
    {
        get { return _plantName; }
        set { _plantName = value; }
    }

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

    public override bool tooMuchDrop
    {
        get { return _tooMuchDrop; }
        set { _tooMuchDrop = value; }
    }

    public override bool lightOn
    {
        get { return _lightOn; }
        set { _lightOn = value; }
    }

    public override int lightTooLong
    {
        get { return _lightTooLong; }
        set { _lightTooLong = value; }
    }

    public override string[] checkPhrases
    {
        get { return _checkPhrases; }
        set { _checkPhrases = value; }
    }

    /* Plant Parameters */

    public override double waterCoefficient
    {
        get { return _waterCoefficient; }
        set { _waterCoefficient = value; }
    }

    public override double minWaterCoefficient
    {
        get { return _minWaterCoefficient; }
        set { _minWaterCoefficient = value; }
    }

    public override double maxWaterCoefficient
    {
        get { return _maxWaterCoefficient; }
        set { _maxWaterCoefficient = value; }
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

    public override double minHumidity
    {
        get { return _minHumidity; }
        set { _minHumidity = value; }
    }

    public override double maxHumidity
    {
        get { return _maxHumidity; }
        set { _maxHumidity = value; }
    }

    public override int temperature
    {
        get { return _temperature; }
        set { _temperature = value; }
    }

    private bool _wateringTooOften;
    private int _dryCount; // count number of phases, when waterCoefficient = 0

    public Kalanchoe()
    {
        plantName = "Каланхоэ";
        normalWaterAmount = 300f;
        waterCoefficient = 0.0f;
        minWaterCoefficient = 0.3f;
        maxWaterCoefficient = 0.85f;
        state = states[2];
        phasesFromLastPour = 10;
        lightAmount = 3000;
        humidity = 0.6;
        maxHumidity = 0.85;
        minHumidity = 0.55;
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
            ChangeStateLogic(minWaterCoefficient, maxWaterCoefficient, minHumidity, maxHumidity, 2000, 8000);
            Debug.Log("Pouring is okey");
        }

        // If pod was poures to much, aloe wiil go to the horrible state, and then dies

        if (tooMuchDrop)
        {
            if (i < 4)
            {
                Debug.Log("tooMuchDrop are true and Aloe going to horrible");
                Debug.Log(state + "state was");
                ChangeStateTo(4);
                Debug.Log(state + "state now");
            }
            else if (i == 4)
            {
                ChangeStateDown(i);
            }

            tooMuchDrop = false;
        }

        // If pod is dry for 3 phases, aloe will die

        if (waterCoefficient == 0)
        {
            _dryCount += 1;
        }
        else
        {
            _dryCount = 0;
        }

        if (_dryCount >= 3)
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

        if (waterAmount >= 600)
        {
            Debug.Log("tooMuchDrop are true");
            tooMuchDrop = true;

        }

        if (phasesFromLastPour > 0 && phasesFromLastPour <= 3)
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
