using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Data.Layer.Interfaces.Models
{
    /// <summary>
    /// Data layer column model interface <see cref="IDLModel"/>
    /// </summary>

    public interface IDLColumnModel : IDLModel
    {
        /// <summary>
        /// Column value
        /// </summary>
        int Column { get; }
    }
}
