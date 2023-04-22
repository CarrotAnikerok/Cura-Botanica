using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Plant : MonoBehaviour
{
    //private new readonly string name;
    //public double waterCoefficient;
    protected string _state;
    public abstract string state { get; set; }

    protected double _normalWaterAmount; // ��� ���� ����������� ���� � ������ ���������� ����� ����� 0.
    public abstract double normalWaterAmount { get; set; }

    protected double _waterCoefficient;
    public abstract double waterCoefficient { get; set; }


    protected string[] _states = {"Perfect", "Good", "Neutral", "Bad", "Horrible", "Dead"};
    public abstract string[] states { get; set; }



    public virtual void ChangeState()
    {
        int i = Array.FindIndex(states, x => x == state);
        if (waterCoefficient < 0.75 || waterCoefficient > 1.25)
        {
            if (i == 5)
            {
                Debug.Log(String.Format("There is no more elements"));
            } 
            else
            {
                this.state = states[i+1];
            }
        } 
        
    }

    public virtual void Dry()
    {
        if (waterCoefficient > 0.0f)
        {
            this.waterCoefficient -= 0.25f;
        }
    }

    public virtual void Pour(double waterAmount)
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
}
