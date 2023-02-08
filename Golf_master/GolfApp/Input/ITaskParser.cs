using System;
using GolfApp.Structures;

namespace GolfApp.Input
{
    public interface ITaskParser
    {
        Task Parse();
    }
    
    public class TaskParserException : Exception
    {
    }
}