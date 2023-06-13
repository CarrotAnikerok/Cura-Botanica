using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cactus : Plant
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

    public override bool tooMuchDrop
    {
        get { return _tooMuchDrop; }
        set { _tooMuchDrop = value; }
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
    public override int temperature
    {
        get { return _temperature; }
        set { _temperature = value; }
    }


    public Cactus()
    {
        plantName = "������";
        this.lightAmount = 3000;
        this.normalWaterAmount = 100f;
        this.waterCoefficient = 0.75f;
        minWaterCoefficient = 0.5f;
        maxWaterCoefficient = 0.1f;
        this.state = states[2];
    }

    public override void ChangeState()
    {
        ChangeStateLogic(minWaterCoefficient, maxWaterCoefficient, 0.5, 1, 2000, 8000);
    }

    public override void Dry()
    {
        DryLogic(0.2f);
    }

    public override void Spray(double sprayHumidity)
    {
        SprayLogic(sprayHumidity);
    }

    public override void Pour(double waterAmount)
    {
        PourLogic(waterAmount);
    }
}
