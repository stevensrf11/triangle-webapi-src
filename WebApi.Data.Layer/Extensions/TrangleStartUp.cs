using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Data.Layer.Interfaces.Models;
using WebApi.Data.Layer.Models.Triangle;

namespace WebApi.Data.Layer.Extensions
{
    /// <summary>
    /// Triangle startup extension class for obtaining row and column lists
    /// </summary>
    public static class TrangleStartUp
    {
        /// <summary>
        /// Extension method to calculate a range of  row and column values
        /// </summary>
        /// <typeparam name="T1">Row type</typeparam>
        /// <typeparam name="T2">Column type</typeparam>
        /// <param name="row">Beginning row value</param>
        /// <param name="column">Beginning Column value</param>
        /// <returns>Data layer triangle start up model which contains a list of rows and columns</returns>
        /// <exception cref="ArgumentNullException">
        /// The exception that is thrown when a null reference  is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="ArgumentException">
        /// The value is neither of type enumType nor does it have the same underlying type as enumType
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The method is invoked by reflection in a reflection-only context,
        /// </exception>
        public static IDLModel StartUpInfo<T1,T2>(this T1 row, T2 column)
        {
            var rowList = new List<DLRowModel>();
            var columnList = new List<DLColumnModel>();

            if (typeof(T1).IsEnum)
            {
                var rowName=Enum.GetName(typeof(T1), row);
                var rowNames = Enum.GetNames(typeof(T1)).ToList();
                var index = rowNames.FindIndex(x=> x==rowName);
                if (index != -1)
                {
                    var listRow = rowNames.Skip(index).Take(rowNames.Count - index-1);
                    rowList.AddRange(listRow.Select(listRowItem => new DLRowModel(listRowItem)));
                }
                
            }
            if (typeof(T2).IsEnum)
            {

                var colName = Enum.GetName(typeof(T2), column);
                var colNames = Enum.GetNames(typeof(T2)).ToList();
                var index = colNames.FindIndex(x => x == colName);
                if (index != -1)
                {
                    
                    var colValues = Enum.GetValues(typeof(T2)).Cast<int>().ToList().Skip(index);
               
                    columnList.AddRange(from int colValue in colValues select new DLColumnModel(colValue));
               }
            
            }


            var rl = rowList.Cast<IDLRowModel>().ToList();
            var cl = columnList.Cast<IDLColumnModel>().ToList();
            return new DLTriangleStartUpInfoModel(rl, cl);
        }
    }
}
