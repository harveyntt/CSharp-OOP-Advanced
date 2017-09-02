﻿using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type soldierType = Assembly
                          .GetExecutingAssembly()
                          .GetTypes()
                          .FirstOrDefault(t => t.Name == soldierTypeName);

        var soldierParams = new object[] { name, age, experience, endurance };

        return (ISoldier)Activator.CreateInstance(soldierType, soldierParams);
    }
}