using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Enums;
using log4net;
using WebApi.Business.Layer.Interfaces;
using WebApi.Business.Layer.Interfaces.Models;
using WebApi.Business.Layer.Interfaces.Models.Triangle;
using WebApi.Business.Layer.Interfaces.Processing.Triangle;
using WebApi.Business.Layer.Models.Triangle;
using WebApi.Data.Layer.Interfaces;
using WebApi.Data.Layer.Models.Triangle;

namespace WebApi.Business.Layer.Processing.Triangle
{
    /// <summary>
    /// Business layer triangle processing operation class
    /// <see cref="IBLTriangleProcessing"/>
    /// </summary>
    public class BLTriangleProcessing : BLProcessing
        , IBLTriangleProcessing
    {
        #region Fields
        /// <summary>
        /// Logger for logging information interface
        /// </summary>
        private readonly ILog _logger;
        /// <summary>
        /// Maps one object to another interface
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Triangle data layer
        /// </summary>
        private readonly IDLTriangle _dLWebApiTriangle;
        /// <summary>
        /// Data annotation interface
        /// </summary>
        private readonly IDataAnnotationsValidator _dataAnnotationsValidator;
        #endregion

        #region Constructors
        /// <summary>
        /// Positional constructor
        /// </summary>
        /// <param name="logManager">Log manager interface</param>
        /// <param name="mapper">Autompper map interface</param>
        /// <param name="dLWebApiTriangle">Triangle data layer interface</param>
        /// <param name="dataAnnotationsValidator">Data annotation interface</param>
        public BLTriangleProcessing(ILogManager logManager
            ,IMapper mapper
            , IDLTriangle dLWebApiTriangle
            , IDataAnnotationsValidator dataAnnotationsValidator
        )
        {
            _logger = logManager.GetLog(typeof(BLTriangleProcessing)); ;
            _dLWebApiTriangle = dLWebApiTriangle;
            _mapper = mapper;
            _dataAnnotationsValidator= dataAnnotationsValidator; 

        }
        #endregion

        #region IBLTriangleProcessing Operations
        /// <summary>
        ///  Retrieves triangle's start up information
        /// </summary>
        /// <param name="taskId">Task identification</param>
        /// <param name="bLTriangleModel">Business layer triangle model that contains the beginning row and column information to obtain</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>Business layer result model that contains if the operation was successful
        /// and the triangle startup information</returns>
        public IBLResultBase TriangleStartUpInfo(long taskId
            , IBLTriangleModel bLTriangleModel
            , CancellationToken? cancellationToken = null)
        {

            IBLResultBase resultBase = new BLResultBase();
            resultBase.ResultOperation = ResultOperationEnums.TraingleStartUpInfo;

            var dlRow = _mapper.Map<DLRowModel>(bLTriangleModel);
            var dlColumn = _mapper.Map<DLColumnModel>(bLTriangleModel);

            var startUpInfo = _dLWebApiTriangle.TriangleStartUpInfo(dlRow, dlColumn);

            if (startUpInfo != null)
            {
                var startUpInfoTriangle = startUpInfo as DLTriangleStartUpInfoModel;
                ;
                  var blStartUpInfo= new BLTriangleStartupInfoModel(startUpInfoTriangle.Rows.Select(row => row.Row).ToList()
                      , startUpInfoTriangle.Columns.Select(col => col.Column).ToList());
              //  var blStartUpInfo = _mapper.Map<BLTriangleStartupInfoModel>(startUpInfoTriangle);
                
               resultBase.ResultContent = blStartUpInfo;
                resultBase.ResultSuccess = true;

            }
            else
            {

                resultBase.ResultSuccess = false;
                _logger.Error($"TriangleStartUpInfo Failed: Content null ");
                resultBase.Errors= new List<string> { $"TriangleStartUpInfo Failed" };
            }

            return resultBase;

        }

        /// <summary>
        ///  Asynchronously retrieves triangle's start up information
        /// </summary>
        /// <param name="taskId">Task identification</param>
        /// <param name="bLTriangleModel">Business layer triangle model that contains the beginning row and column information to obtain</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>Business layer result model that contains if the operation was successful
        /// and the triangle startup information</returns>
        public async  Task<IBLResultBase> TriangleStartUpInfoAsync(long taskId
            , IBLTriangleModel bLTriangleModel
            , CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Task.Run(() => TriangleStartUpInfo(taskId, bLTriangleModel), cancellationToken);

        }

        /// <summary>
        ///  Retrieves triangle vertice information
        /// </summary>
        /// <param name="taskId">Task identification</param>
        /// <param name="bLTriangleModel">Business layer triangle model that contains the  row and column information</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>Business layer result model that contains if the operation was successful
        /// and the triangle vertice information</returns>
        public IBLResultBase TriangleCalculateVerices(long taskId
            , IBLTriangleModel bLTriangleModel
            , CancellationToken? cancellationToken = null)
        {
            IBLResultBase resultBase = new BLResultBase();
            resultBase.ResultOperation = ResultOperationEnums.TriangleCalulateVertices;
            resultBase.Errors = new List<string>();

            // Verify
            var validateResults = new List<ValidationResult>();
            var res = _dataAnnotationsValidator.TryValidateObject(bLTriangleModel, validateResults);
            if (res)
            {
                var blModels = new List<IBLModel>(); 
                var dlRow = _mapper.Map<DLRowModel>(bLTriangleModel);
                var dlColumn = _mapper.Map<DLColumnModel>(bLTriangleModel);
                var vertices = _dLWebApiTriangle.TriangleVertices(dlRow, dlColumn);
                if (vertices != null)
                {
                    blModels.AddRange(vertices.Select(vertice => _mapper.Map<BLTriangleVerticeModel>(vertice as DLTriangleVerticeModel)));
                }
                resultBase.ResultContent = blModels;
                if(blModels.Any())
                    resultBase.ResultSuccess = true;
                else
                {
                    resultBase.ResultSuccess = false;
                    resultBase.Errors.Add($"No vertices found for row = {bLTriangleModel.Row}, column = {bLTriangleModel.Column}");
                }

            }
            else
            {
                resultBase.HasErrors = true;
                resultBase.ResultSuccess = false;

                resultBase.Errors.Add(validateResults[0].ErrorMessage);
            }
           return resultBase;
        }

        /// <summary>
        /// Asynchronously retrieves triangle vertice information
        /// </summary>
        /// <param name="taskId">Task identification</param>
        /// <param name="bLTriangleModel">Business layer triangle model that contains the  row and column information</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>Business layer result model that contains if the operation was successful
        /// and the triangle vertice information</returns>
        public async Task<IBLResultBase> TriangleCalculateVericesAsync(long taskId
            , IBLTriangleModel bLTriangleModel

            , CancellationToken cancellationToken = default(CancellationToken))
        {
              return await Task.Run(() => TriangleCalculateVerices(taskId, bLTriangleModel), cancellationToken);
          
        }
    #endregion
    }
}
