using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public abstract class Plant : MonoBehaviour
{

    protected double _normalWaterAmount; // при этом количечстве воды в горшке коэффицент будет равен 1.
    public abstract double normalWaterAmount { get; set; }

    protected double _waterCoefficient; // коэффицент того, насколько полито растение
    public abstract double waterCoefficient { get; set; }

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
                Debug.Log(String.Format("That is not so bad"));
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
                Debug.Log(String.Format("You are not perfect enough"));
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
            Debug.Log(String.Format("That's all folks"));
        }
        else
        {
            this.state = states[i + 1];
            image.sprite = statesPicturesMini[i + 1];
        }
    }
    public void ChangeStateUp(int i)
    {
        if (i == 0)
        {
            Debug.Log(String.Format("That's all folks"));
        }
        else
        {
            this.state = states[i - 1];
            image.sprite = statesPicturesMini[i - 1];
        }
    }

    public abstract void Pour(double waterAmount);

    public abstract void ChangeState();

    public abstract void Dry();

}
