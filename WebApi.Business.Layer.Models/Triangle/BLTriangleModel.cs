using System.ComponentModel.DataAnnotations;
using WebApi.Business.Layer.Interfaces.Models.Triangle;

namespace WebApi.Business.Layer.Models.Triangle
{
    /// <summary>
    /// Business layer triangle model class <see cref="IBLTriangleModel"/>
    /// </summary>
    public class BLTriangleModel : BLModel
        , IBLTriangleModel
    {
        #region Accessor Properties
        /// <summary>
        /// Row information
        /// </summary>
        [Required (AllowEmptyStrings = false, ErrorMessage = "Row required")]
        [StringLength(1, MinimumLength = 1,ErrorMessage = "Character A through  F required")]
        [RegularExpression("^[A-F]*$",ErrorMessage = "Must be between A through F")]
        public string Row { get; }

        /// <summary>
        /// Column information
        /// </summary>
        [Required (ErrorMessage = "Column value required")]
        [Range(1,12, ErrorMessage = "The value must be betweeb 1 to 12")]
        public int Column { get; }
        #endregion
        public BLTriangleModel(string row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}


