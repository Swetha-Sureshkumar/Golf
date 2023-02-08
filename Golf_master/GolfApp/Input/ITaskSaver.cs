using GolfApp.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolfApp.Input
{
    public interface ITaskSaver
    {
        void Save(Task task);
    }
}
