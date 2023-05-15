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
    public abstract double phasesFromLastPour { get; set; }

    protected bool _alive = true;
    public abstract bool alive { get; set; }

    protected bool _sharpDrop; // if the parameters have changed drastically
    public abstract bool sharpDrop { get; set; }


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
    public virtual void ChangeStateLogic(double minCoefficient, double maxCoefficient, double minHumidity, double maxHumidity)
    {
        int howBadIsIt = 0;
        int i = Array.FindIndex(states, x => x == state);
        /*if (waterCoefficient < minCoefficient || waterCoefficient > maxCoefficient)
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
        else if (waterCoefficient >= minCoefficient && waterCoefficient <= maxCoefficient)
        {
            if (i == 1)
            {
                Debug.Log(String.Format(name + " You are not perfect enough"));
            }
            else
            {
                if (sharpDrop)
                {
                    sharpDrop = false;
                } 
                else
                {
                    ChangeStateUp(i);
                }
            }
        }*/

        if (waterCoefficient < minCoefficient || waterCoefficient > maxCoefficient)
        {
            howBadIsIt += 1; 
        } 

        if (humidity < minHumidity || humidity > maxHumidity)
        {
            howBadIsIt += 1;
        }

        // Deterioration

        if (i == 1 && howBadIsIt >= 1)
        {
            ChangeStateDown(i);
        } 
        else if (i == 2 && howBadIsIt >= 2)
        {
            ChangeStateDown(i);
        } 
        else if (i == 3 && howBadIsIt >=3)
        {
            ChangeStateDown(i);
        } 
        else if (i == 4 && howBadIsIt >=4)
        {
            ChangeStateDown(i);
        }

        // Improvement

        if (i == 4 && howBadIsIt < 3 && !sharpDrop)
        {
            ChangeStateUp(i);
        }
        else if (i == 3 && howBadIsIt < 2 && !sharpDrop)
        {
            ChangeStateUp(i);
        }
        else if (i == 2 && howBadIsIt < 1 && !sharpDrop)
        {
            ChangeStateUp(i);
        }

        sharpDrop = false;
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
            Debug.Log("This is water coefficietn: " + waterCoefficient);
        }
    }

    public void SprayLogic(double sprayHumidity)
    {
        if (this.humidity + sprayHumidity > 1)
        {
            this.humidity = 1;
        }
        else
        {
            this.humidity += sprayHumidity;
            Debug.Log("This is plant humidity: " + humidity);
        }
    }

    /* Abstract methods */

    public abstract void Pour(double waterAmount);

    public abstract void ChangeState();

    public abstract void Dry();

    public abstract void Spray(double sprayHumidity);

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
