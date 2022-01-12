using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    //kullanıcılara sonuç dönmek için;
    //sonuç olduğu için sadece get
    public interface IResult
    {
        public ResultStatus ResultStatus { get;  } //ResultStatus.Success //ResultStatus.Error
        public string Message { get;  }
        public Exception Exception { get;  }
    }
}
