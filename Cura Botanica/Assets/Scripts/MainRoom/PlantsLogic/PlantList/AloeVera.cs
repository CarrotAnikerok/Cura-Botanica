using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AloeVera : Plant
{

    // Поля
    public override double waterCoefficient
    {
        get { return _waterCoefficient; }
        set { _waterCoefficient = value; }
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

    public override double fasesFromLastPour
    {
        get { return _fasesFromLastPour; }
        set { _fasesFromLastPour = value; }
    }

    public override bool alive
    {
        get { return _alive; }
        set { _alive = value; }
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

    public bool wateringTooOften = false;

    // Конструктор

    public AloeVera()
    {
        normalWaterAmount = 300f;
        waterCoefficient = 0.0f;
        state = states[2];
        fasesFromLastPour = 10;
        lightAmount = 3000;
        humidity = 0.6;
        temperature = 20;
    }

    // Методы



    public override void Dry()
    {
        DryLogic(0.1);
    }

    public override void ChangeState()
    {
        if (wateringTooOften)
        {
            int i = Array.FindIndex(states, x => x == state);
            ChangeStateDown(i);
            Debug.Log("Полив слишком частый");
            wateringTooOften = false;
        }
        else
        {
            ChangeStateLogic(0.4f, 1f);
            Debug.Log("Полив норм");
        }

        fasesFromLastPour += 1;
        Debug.Log("Fases from last pour " + fasesFromLastPour);
    }

    public override void Pour(double waterAmount)
    {
        PourLogic(waterAmount);
        if (fasesFromLastPour > 0 && fasesFromLastPour <=3)
        {
            fasesFromLastPour = 0;
            wateringTooOften = true;
            Debug.Log("You are pouring it too often!");
        } 
        else if (waterAmount == 0)
        {
            fasesFromLastPour = fasesFromLastPour;
            Debug.Log("You didnt pour it");
        }
        else
        {
            fasesFromLastPour = 0;
            Debug.Log("Your pouring is okey");
        }
        Debug.Log(wateringTooOften + " and " + fasesFromLastPour);
    }
}
