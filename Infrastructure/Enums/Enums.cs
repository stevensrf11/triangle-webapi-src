using System.ComponentModel;

namespace Infrastructure.Enums
{
    /// <summary>
    /// Operation enumeration
    /// Used to indicate what operation is occuring
    /// </summary>
    public enum ResultOperationEnums
    {
        [Description("No Operation")]
        None = 0,

        [Description("Triangle Startup Information Operation")]
        TraingleStartUpInfo,

        [Description("Triangle Calculate Vertices Operation")]
        TriangleCalulateVertices,


        [Description("Null")]
        Null,

        [Description("Result Base was Null")]
        ResultBaseNull,
    }

}
