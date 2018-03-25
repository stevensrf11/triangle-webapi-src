using System.Collections.Generic;

namespace Common.Interfaces.Model 
{
    public interface IModel : ICommonModel
    {
        IList<ILinkModel> Links { get; set; }
    }
}
