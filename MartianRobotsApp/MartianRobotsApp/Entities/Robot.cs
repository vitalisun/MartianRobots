using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Entities;

internal class Robot
{
    public Coordinate Coordinate { get; set; }
    public DirectionEnum DirectionEnum { get; set; }
    public bool IsLost { get; set; }

    public Robot(SpawnInfo spawnInfo)
    {
        Coordinate = spawnInfo.Position;
        DirectionEnum = spawnInfo.DirectionEnum;
    }

    public override string ToString()
    {
        return $"{Coordinate.X} {Coordinate.Y} {DirectionEnum} {(IsLost ? "LOST" : "")}";
    }
}