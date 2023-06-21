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

    public override int placeIndex
    {
        get { return _placeIndex; }
        set { _placeIndex = value; }
    }


    public Cactus()
    {
        plantName = "Кактус";
        this.lightAmount = 3000;
        this.normalWaterAmount = 100f;
        this.waterCoefficient = 0f;
        minWaterCoefficient = 0.1f;
        maxWaterCoefficient = 1f;
        this.state = states[2];
        humidity = 0.6;
        maxHumidity = 1;
        minHumidity = 0.5;
    }

    public override void ChangeState()
    {
        ChangeStateLogic(minWaterCoefficient, maxWaterCoefficient, minHumidity, maxHumidity, 2000, 8000);
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
