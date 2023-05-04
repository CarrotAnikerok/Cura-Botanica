using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public abstract class Plant : MonoBehaviour
{

    protected double _normalWaterAmount; // при этом количечстве воды в горшке коэффицент будет равен 1.
    public abstract double normalWaterAmount { get; set; }

    protected string[] _states = {"Perfect", "Good", "Neutral", "Bad", "Horrible", "Dead"};
    public abstract string[] states { get; set; }

    protected string _state; // состояние растения
    public abstract string state { get; set; }

    [SerializeField]  protected Sprite[] _statesPicturesMini = new Sprite[6]; // спрайт на общем экране
    public abstract Sprite[] statesPicturesMini { get; set; }

    [SerializeField] protected Sprite[] _statesPicturesBig = new Sprite[6]; // спрайт в меню растения
    public abstract Sprite[] statesPicturesBig { get; set; }

    protected Image _image; // компонент  
    public abstract Image image { get; set; }

    protected double _fasesFromLastPour = 0; // количество поливов
    public abstract double fasesFromLastPour { get; set; }

    protected bool _alive = true; // отражает, живо ли растение
    public abstract bool alive { get; set; }

    /* Параметры в таблице: */

    /// <summary>
    /// Количество света, которое растение получает сейчас в люксах
    /// </summary>
    protected int _lightAmount; //
    public abstract int lightAmount { get; set; }

    /// <summary>
    /// Коэффицент того, насколько полито растение
    /// </summary>
    protected double _waterCoefficient; 
    public abstract double waterCoefficient { get; set; }

    /// <summary>
    /// Окружающая влажность
    /// </summary>
    protected double _humidity;
    public abstract double humidity { get; set; }

    /// <summary>
    /// Температура окружающей среды 
    /// </summary>
    protected int _temperature;
    public abstract int temperature { get; set; }



    public virtual void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = statesPicturesMini[Array.FindIndex(states, x => x == state)];
    }


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

    // Изменение состояния растения

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

    public abstract void Pour(double waterAmount);

    public abstract void ChangeState();

    public abstract void Dry();

}
