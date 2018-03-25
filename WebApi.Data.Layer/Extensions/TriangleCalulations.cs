using System;
using System.Collections.Generic;
using WebApi.Data.Layer.Interfaces.Models;
using Infrastructure.Extension;
using WebApi.Data.Layer.Enums;
using WebApi.Data.Layer.Models.Triangle;
namespace WebApi.Data.Layer.Extensions
{
    /// <summary>
    /// Triangle extension class that calculates vertice information 
    /// </summary>
    static class TriangleCalulations
    {
        #region Extension methods
        /// <summary>
        /// String extension method that calculates triangles vertices
        /// </summary>
        /// <param name="row">Row that a triangle is in</param>
        /// <param name="column">Column the a triangle is in</param>
        /// <param name="spacing">Spacing of rows and columns</param>
        /// <param name="multiplier">Multiple factor</param>
        /// <returns>List of triangle vertex information</returns>

        public static IList<IDLModel> CalulateVertices(this string row, int column, double spacing,double multiplier)
        {
            return new List<IDLModel>
            {
                CalulateVerticeUpperLeft(row,  column,  spacing,  multiplier)
                , CalulateVerticeLowerRight(row,  column,  spacing,  multiplier)
                ,CalulateVerticeDiagnol(row,  column,  spacing,  multiplier)
            };
        }

        /// <summary>
        /// Integer extension method that calculates triangles vertices
        /// </summary>
        /// <param name="row">Row that a triangle is in</param>
        /// <param name="column">Column the a triangle is in</param>
        /// <param name="spacing">Spacing of rows and columns</param>
        /// <param name="multiplier">Multiple factor</param>
        /// <returns>List of triangle vertex information</returns>
        public static IList<IDLModel> CalulateVertices(this int row, int column, double spacing, double multiplier)
        {
            return new List<IDLModel>
            {
                CalulateVerticeUpperLeft(row,  column,  spacing,  multiplier)
                , CalulateVerticeLowerRight(row,  column,  spacing,  multiplier)
                ,CalulateVerticeDiagnol(row,  column,  spacing,  multiplier)
            };
        }

        /// <summary>
        /// String extension method that calculates triangles upper left vertex
        /// </summary>
        /// <param name="row">Row that a triangle is in</param>
        /// <param name="column">Column the a triangle is in</param>
        /// <param name="spacing">Spacing of rows and columns</param>
        /// <param name="multiplier">Multiple factor</param>
        /// <returns>LBuisness layer triangle vertice model which contain vertex information</returns>

        public static IDLModel CalulateVerticeUpperLeft(this string row, int column, double spacing, double multiplier)
        {
            return CalulateVerticeUpperLeft((int)row.ToEnum<TriangleRowEnums>(true, false), column, spacing, multiplier);
            ;

        }

        /// <summary>
        /// String extension method that calculates triangle's lower  right vertex
        /// </summary>
        /// <param name="row">Row that a triangle is in</param>
        /// <param name="column">Column the a triangle is in</param>
        /// <param name="spacing">Spacing of rows and columns</param>
        /// <param name="multiplier">Multiple factor</param>
        /// <returns>LBuisness layer triangle vertice model which contain vertex information</returns>
        public static IDLModel CalulateVerticeLowerRight(this string row, int column, double spacing, double multiplier)
        {
            return CalulateVerticeLowerRight((int)row.ToEnum<TriangleRowEnums>(true, false), column, spacing, multiplier);
     }

        /// <summary>
        /// String extension method that calculates triangle's diagonal vertex
        /// </summary>
        /// <param name="row">Row that a triangle is in</param>
        /// <param name="column">Column the a triangle is in</param>
        /// <param name="spacing">Spacing of rows and columns</param>
        /// <param name="multiplier">Multiple factor</param>
        /// <returns>LBuisness layer triangle vertice model which contain vertex information</returns>
        public static IDLModel CalulateVerticeDiagnol(this string row, int column, double spacing, double multiplier)
        {
            return CalulateVerticeDiagnol((int)row.ToEnum<TriangleRowEnums>(true, false), column, spacing, multiplier);

        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Integer extension method that calculates triangles upper left vertex
        /// </summary>
        /// <param name="row">Row that a triangle is in</param>
        /// <param name="column">Column the a triangle is in</param>
        /// <param name="spacing">Spacing of rows and columns</param>
        /// <param name="multiplier">Multiple factor</param>
        /// <returns>LBuisness layer triangle vertice model which contain vertex information</returns>
        private static IDLModel CalulateVerticeUpperLeft(this int row, int column, double spacing, double multiplier)
        {
            return new DLTriangleVerticeModel(
                (int)(Math.Floor((double)((column + 1) * multiplier)) * spacing)
                , row * spacing);



        }

        /// <summary>
        /// Integer extension method that calculates triangle's lower  right vertex
        /// </summary>
        /// <param name="row">Row that a triangle is in</param>
        /// <param name="column">Column the a triangle is in</param>
        /// <param name="spacing">Spacing of rows and columns</param>
        /// <param name="multiplier">Multiple factor</param>
        /// <returns>LBuisness layer triangle vertice model which contain vertex information</returns>
        private static IDLModel CalulateVerticeLowerRight(this int row, int column, double spacing, double multiplier)
        {
            return new DLTriangleVerticeModel(
                (int)(Math.Floor((double)((column - 1) * multiplier)) * spacing)
                , (row + 1) * spacing);


        }

        /// <summary>
        /// Integer extension method that calculates triangle's diagonal vertex
        /// </summary>
        /// <param name="row">Row that a triangle is in</param>
        /// <param name="column">Column the a triangle is in</param>
        /// <param name="spacing">Spacing of rows and columns</param>
        /// <param name="multiplier">Multiple factor</param>
        /// <returns>LBuisness layer triangle vertice model which contain vertex information</returns>
        private static IDLModel CalulateVerticeDiagnol(this int row, double column, double spacing, double multiplier)
        {
            return new DLTriangleVerticeModel(
                   (int)(Math.Floor((double)((column) * multiplier)) * spacing)
                ,  (int)(spacing * ((column - 1) % 2 + row)));

        }

        #endregion
    }
}
