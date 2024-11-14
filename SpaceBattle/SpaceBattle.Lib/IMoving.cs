﻿using System.Numerics;
using System.Linq;
using System;

namespace SpaceBattle.Lib;

public interface ICommand
{
    void Execute();
}
public interface IMovingObject
{
    public Vector Location {get;  set;}
    public Vector Velocity{get;   }
}
public class Move: ICommand
{
    IMovingObject MovingObject;
    public Move(IMovingObject MovingObject)
    {
        this.MovingObject = MovingObject;
    }
    public void Execute()
    {
        var NewLocation = MovingObject.Location + MovingObject.Velocity;
        MovingObject.Location = NewLocation;
    }
}

public class Vector
{
    int [] coordinates;
    public Vector(params int [] coordinates)
    {
        this.coordinates = coordinates;
    }
    public static Vector operator +(Vector a, Vector b)
    {
        a.coordinates = a.coordinates.Zip(b.coordinates, (x,y) => x + y).ToArray<int>();
        return a;
    }
    public static Vector operator *(Vector a, int b)
    {
        a.coordinates = a.coordinates.Select(x => x * b).ToArray();
        return a;
    }
    public override bool Equals(object obj)
    {
        if (obj is Vector other)
        {
            if (coordinates.Length != other.coordinates.Length)
            {
                return false;
            }
            bool[] result = coordinates.Zip(other.coordinates, (x,y) => x == y ? true : false).ToArray<bool>();
            return result.All(x => x == true);
        }
        return false;
    }
}
