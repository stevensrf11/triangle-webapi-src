using System;
using System.Collections.Generic;
using Infrastructure;
using log4net;
using Infrastructure.Extension;
using WebApi.Data.Layer.Enums;
using WebApi.Data.Layer.Interfaces;
using WebApi.Data.Layer.Interfaces.Models;
using WebApi.Data.Layer.Extensions;
namespace WebApi.Data.Layer.Triangle
{
    /// <summary>
    /// Data layer triangle  processing operation  class <see cref="IDLTriangle"/>
    /// </summary>
    public class DLTriangle : IDLTriangle
    {
        #region Fields
        /// <summary>
        /// Logger for logging information interface
        /// </summary>
        private readonly ILog _logger;
        #endregion

        #region Constructors
        /// <summary>
        /// Positional Constructor
        /// </summary>
        /// <param name="logManager">Log manager interface</param>
        public DLTriangle(ILogManager logManager)
        {
            _logger = logManager.GetLog(typeof(DLTriangle)); ;
        }
        #endregion

        #region IDLTriangle Operations
        /// <summary>
        /// Obtains triangle startup information
        /// </summary>
        /// <param name="row">Beginning row value </param>
        /// <param name="column">Beginning column value</param>
        /// <returns>Data layer triangle start up information model with list of columns and rows</returns>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IDLModel TriangleStartUpInfo(IDLRowModel row
            , IDLColumnModel column)
             
        {
            try
            {

                var rowEnum = row.Row.ToEnum<TriangleRowEnums>();
                var columnEnum = column.Column.ToEnum<TriangleColumnEnums>();
                return rowEnum.StartUpInfo(columnEnum);
            }
            catch (Exception ex)
            {
                _logger.Fatal($"DLWebApiTriangle:TriangleStartUpInfo - Exception {ex.Message}",ex);
            }
            return null;
        }


        /// <summary>
        /// Obtains triangle vertice information
        /// </summary>
        /// <param name="row">Row value of triangle </param>
        /// <param name="column">Column value of triangle</param>
        /// <returns>Data layer model with list of vertice information if operation successful</returns>
        public IList<IDLModel> TriangleVertices(IDLRowModel row
            , IDLColumnModel column)
        {
            return TriangleVertices(row , column , 1.0, 0.50);
        }

        /// <summary>
        /// Obtains triangle vertice information
        /// </summary>
        /// <param name="row">Row value of triangle </param>
        /// <param name="column">Column value of triangle</param>
        /// <param name="spacing">Spacing interval</param>
        /// <param name="multiplier">Multiplier value</param>
        /// <returns>Data layer model with list of vertice information if operation successful</returns>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IList<IDLModel> TriangleVertices(IDLRowModel row
            , IDLColumnModel column
            ,double spacing
            , double multiplier)
        {
            try
            {
              return row.Row.CalulateVertices(column.Column, spacing, multiplier);

            }
            catch (Exception ex)
            {
                _logger.Fatal($"DLWebApiTriangle:TriangleVertices - Exception {ex.Message}", ex);
            }
            return null;
        }
        #endregion

    }
}
