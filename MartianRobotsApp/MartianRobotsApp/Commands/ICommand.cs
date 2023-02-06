using MartianRobotsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobotsApp.Commands;

internal interface ICommand
{
    void Execute(Robot robot);
}