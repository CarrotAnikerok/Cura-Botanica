using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public abstract class Plant : MonoBehaviour
{

    protected double _normalWaterAmount; // with this amount of water in the pod coefficent equels one
    public abstract double normalWaterAmount { get; set; }

    protected string[] _states = {"Perfect", "Good", "Neutral", "Bad", "Horrible", "Dead"};
    public abstract string[] states { get; set; }

    protected string _state; 
    public abstract string state { get; set; }

    [SerializeField]  protected Sprite[] _statesPicturesMini = new Sprite[6]; // sprite at the main room
    public abstract Sprite[] statesPicturesMini { get; set; }

    [SerializeField] protected Sprite[] _statesPicturesBig = new Sprite[6]; // sprite at the plant menu
    public abstract Sprite[] statesPicturesBig { get; set; }

    protected Image _image; 
    public abstract Image image { get; set; }

    protected double _fasesFromLastPour = 0; 
    public abstract double fasesFromLastPour { get; set; }

    protected bool _alive = true;
    public abstract bool alive { get; set; }

    /* Plant Parameters */

    protected int _lightAmount; 
    public abstract int lightAmount { get; set; }

    protected double _waterCoefficient; 
    public abstract double waterCoefficient { get; set; }

    protected double _humidity;
    public abstract double humidity { get; set; }

    protected int _temperature;
    public abstract int temperature { get; set; }



    public virtual void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = statesPicturesMini[Array.FindIndex(states, x => x == state)];
    }



    /* Logic */
    public virtual void ChangeStateLogic(double minC, double maxC)
    {
        int i = Array.FindIndex(states, x => x == state);
        if (waterCoefficient < minC || waterCoefficient > maxC)
        {
            if (i == 3)
            {
                Debug.Log(String.Format(name +" That is not so bad"));
            } 
            else
            {
                ChangeStateDown(i);
            }
        } 
        else if (waterCoefficient >= minC && waterCoefficient <= maxC)
        {
            if (i == 1)
            {
                Debug.Log(String.Format(name + " You are not perfect enough"));
            }
            else
            {
                ChangeStateUp(i);
            }
        }
    }

    public virtual void DryLogic(double dryC)
    {
        if (waterCoefficient - dryC > 0.0f)
        {
            waterCoefficient -= dryC;
        }
        else
        {
            waterCoefficient = 0.0f;
        }
    }


    public virtual void PourLogic(double waterAmount)
    {
        if (this.waterCoefficient + waterAmount / normalWaterAmount > 2.0f)
        {
            this.waterCoefficient = 2.0f;
        }
        else
        {
            this.waterCoefficient += waterAmount / normalWaterAmount;
            Debug.Log(waterCoefficient);
        }
    }

    public void Spray(double sprayHumidity)
    {
        humidity += sprayHumidity;
    }

    /* Abstract methods */

    public abstract void Pour(double waterAmount);

    public abstract void ChangeState();

    public abstract void Dry();

    /* Change of state */

    public void ChangeStateDown(int i)
    {
        if (i == 5)
        {
            alive = false;
            Debug.Log(String.Format(name + " It is already dead, it cant be any worse." + "There is alive: " + alive));
        }
        else
        {
            this.state = states[i + 1];
            image.sprite = statesPicturesMini[i + 1];
        }
    }
    public void ChangeStateUp(int i)
    {
        if (alive)
        {
            Debug.Log(name + "It is steel alive! " + alive);
            if (i == 0)
            {
                Debug.Log(String.Format(name + " That's all folks"));
            }
            else
            {
                this.state = states[i - 1];
                image.sprite = statesPicturesMini[i - 1];
            }
        }
        else
        {
            Debug.Log(name + " It is already dead, it cant become good");
        }
    }
}
