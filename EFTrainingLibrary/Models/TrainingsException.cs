using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Models
{
    public class TrainingsException : Exception
    {
        public TrainingsException(string msg) : base(msg) { }

    }
}