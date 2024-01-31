using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class BurgerBuilder
{
    public Func<BurgerBuilder>[] actions;
    
    public bool item1;
    public bool item2;
    public bool item3;
    public bool item4;
    //---------------------------------------------------------------------------------------------------------------
    public BurgerBuilder()
    {
        actions = new Func<BurgerBuilder>[]
        {
            WithItem1,
            WithItem2,
            WithItem3,
            WithItem4
        };
    }
    //---------------------------------------------------------------------------------------------------------------
    private BurgerBuilder Default()
    {
        item1 = false;
        item2 = false;
        item3 = false;
        item4 = false;
        return this;
    }
    //---------------------------------------------------------------------------------------------------------------
    private BurgerBuilder WithItem1()
    {
        item1 = true;
        return this;
    }
    //---------------------------------------------------------------------------------------------------------------
    private BurgerBuilder WithItem2()
    {
        item2 = true;
        return this;
    }
    //---------------------------------------------------------------------------------------------------------------
    private BurgerBuilder WithItem3()
    {
        item3 = true;
        return this;
    }
    //---------------------------------------------------------------------------------------------------------------
    private BurgerBuilder WithItem4()
    {
        item4 = true;
        return this;
    }
    //---------------------------------------------------------------------------------------------------------------
    public BurgerBuilder SetItems(int[] settings)
    {
        Default();
        
        foreach (var parametr in settings)
        {
            actions[parametr].Invoke();
        }

        return this;
    }
    //---------------------------------------------------------------------------------------------------------------
    public Burger Build()
    {
        Burger burger = Object.Instantiate(new GameObject()).AddComponent<Burger>();
        burger.SetItem1(item1);
        burger.SetItem2(item2);
        burger.SetItem3(item3);
        burger.SetItem4(item4);
        return burger;
    }
    //---------------------------------------------------------------------------------------------------------------
}