using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    //get işlemleri için. kod tekrarını önlemek için. 
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }


    }
}
