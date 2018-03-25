using Common.Interfaces.Model;
using System.ComponentModel.DataAnnotations;
namespace Common.Models
{
    /// <summary>
    /// Row value class
    /// </summary>
    public class RowModel : IRowModel
    {
        /// <summary>
        /// A string row value
        /// </summary>
        [Required(AllowEmptyStrings = false,ErrorMessage = "Required") ]
        [RegularExpression("^[A-F]$",ErrorMessage = "Only letter A through F allowed")]
        [StringLength(1, MinimumLength = 1,ErrorMessage = "Only single character length allowed")]
        public string RowValue { get; set; }
    }
}
