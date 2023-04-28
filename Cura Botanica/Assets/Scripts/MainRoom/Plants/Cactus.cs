using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cactus : Plant
{
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

    public Cactus()
    {
        this.normalWaterAmount = 100f;
        this.waterCoefficient = 0.75f;
        this.state = states[2];
    }
 }
