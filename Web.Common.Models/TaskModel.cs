using System.Collections.Generic;
using Web.Common.Interfaces.Model;

namespace Web.Common.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskModel : ILinkModels
    {
       public IList<ILinkModel> Links { get; set; }

        public TaskModel(IList<ILinkModel> links)
        {
            Links = links;
        }
        

    }
}
