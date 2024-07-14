using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingUserLibrary.Models
{
    public class TrainingUserException:Exception
    {
        public TrainingUserException(string? msg):base(msg)
        {
            
        }
    }
}
