namespace WebApi.Data.Layer.Interfaces.Models
{
    /// <summary>
    /// Date layer row model interface <see cref="IDLModel"/>
    /// </summary>

    public interface IDLRowModel : IDLModel
    {
        /// <summary>
        /// Row value
        /// </summary>

        string Row { get; }
    }
}
