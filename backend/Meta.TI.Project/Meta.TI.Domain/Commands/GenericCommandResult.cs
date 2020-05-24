using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(){}
        public GenericCommandResult(bool sucess, object data)
        {
            Sucess = sucess;
            Data = data;
        }
        public GenericCommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
