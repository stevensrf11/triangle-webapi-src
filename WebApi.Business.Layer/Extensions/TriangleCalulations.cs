using System;
using System.Collections.Generic;
using Infrastructure.Extension;
using WebApi.Business.Layer.Enums;
using WebApi.Business.Layer.Interfaces.Models;
using WebApi.Business.Layer.Models.Triangle;

namespace WebApi.Business.Layer.Extensions
{
    /// <summary>
    /// Triangle extension class to calculate a triangles vertex based on row, column, spacing, and multiplier
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
        public static IList<IBLModel> CalulateVertices(this string row, int column, double spacing,double multiplier)
        {
            return new List<IBLModel>
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
        public static IList<IBLModel> CalulateVertices(this int row, int column, double spacing, double multiplier)
        {
            return new List<IBLModel>
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
        public static IBLModel CalulateVerticeUpperLeft(this string row, int column, double spacing, double multiplier)
        {
            return CalulateVerticeUpperLeft((int)row.ToEnum<WebApiBLRowEnums>(true, false), column, spacing, multiplier);
        }

        /// <summary>
        /// String extension method that calculates triangle's lower  right vertex
        /// </summary>
        /// <param name="row">Row that a triangle is in</param>
        /// <param name="column">Column the a triangle is in</param>
        /// <param name="spacing">Spacing of rows and columns</param>
        /// <param name="multiplier">Multiple factor</param>
        /// <returns>LBuisness layer triangle vertice model which contain vertex information</returns>
        public static IBLModel CalulateVerticeLowerRight(this string row, int column, double spacing, double multiplier)
        {
            return CalulateVerticeLowerRight((int)row.ToEnum<WebApiBLRowEnums>(true, false), column, spacing, multiplier);
        }

        /// <summary>
        /// String extension method that calculates triangle's diagonal vertex
        /// </summary>
        /// <param name="row">Row that a triangle is in</param>
        /// <param name="column">Column the a triangle is in</param>
        /// <param name="spacing">Spacing of rows and columns</param>
        /// <param name="multiplier">Multiple factor</param>
        /// <returns>LBuisness layer triangle vertice model which contain vertex information</returns>
        public static IBLModel CalulateVerticeDiagnol(this string row, int column, double spacing, double multiplier)
        {
            return CalulateVerticeDiagnol((int)row.ToEnum<WebApiBLRowEnums>(true, false), column, spacing, multiplier);

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
        private static IBLModel CalulateVerticeUpperLeft(this int row, int column, double spacing, double multiplier)
        {
            return new BLTriangleVerticeModel(
                (int)(Math.Floor((column + 1) * multiplier) * spacing)
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
        private static IBLModel CalulateVerticeLowerRight(this int row, int column, double spacing, double multiplier)
        {
            return new BLTriangleVerticeModel(
                (int)(Math.Floor((column - 1) * multiplier) * spacing)
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
        private static IBLModel CalulateVerticeDiagnol(this int row, double column, double spacing, double multiplier)
        {
            return new BLTriangleVerticeModel(
                   (int)(Math.Floor((column) * multiplier) * spacing)
                ,  (int)(spacing * ((column - 1) % 2 + row)));

        }
        #endregion
    }
}
