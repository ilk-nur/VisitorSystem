using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Shared.Utilities.Results.ComplexTypes;

namespace VisitorSystem.Shared.Utilities.Results.Abstarct
{
    public  interface IResult
    {
        public ResultStatus ResultStatus { get; }//ResultStatus.Error veya ResultStatus.Success
        public string Message { get; }
        public Exception Exception { get; }
    }
}
