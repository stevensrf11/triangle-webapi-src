using System.Collections.Generic;
using WebApi.Data.Layer.Interfaces.Models;
namespace WebApi.Data.Layer.Interfaces
{
    /// <summary>
    /// Data layer triangle  processing operation interface <see cref="IDL"/>
    /// </summary>
    public interface IDLTriangle : IDL
   {
       /// <summary>
       /// Obtains triangle startup information
       /// </summary>
       /// <param name="row">Beginning row value </param>
       /// <param name="column">Beginning column value</param>
       /// <returns>Data layer triangle start up information model with list of columns and rows</returns>
        IDLModel TriangleStartUpInfo(IDLRowModel row
           , IDLColumnModel column);
       /// <summary>
       /// Obtains triangle vertice information
       /// </summary>
       /// <param name="row">Row value of triangle </param>
       /// <param name="column">Column value of triangle</param>
       /// <param name="spacing">Spacing interval</param>
       /// <param name="multiplier">Multiplier value</param>
       /// <returns>Data layer model with list of vertice information   </returns>
        IList<IDLModel> TriangleVertices(IDLRowModel row
            ,IDLColumnModel column
            , double spacing
            ,double multiplier);

       /// <summary>
       /// Obtains triangle vertice information
       /// </summary>
       /// <param name="row">Row value of triangle </param>
       /// <param name="column">Column value of triangle</param>
       /// <returns>Data layer model with list of vertice information </returns>
        IList<IDLModel> TriangleVertices(IDLRowModel row
           , IDLColumnModel column
            );
    }


}
