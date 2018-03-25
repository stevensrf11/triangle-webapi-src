namespace Common.Interfaces.Model 
{
    public interface ILinkModel : ICommonModel
    {
         string Rel { get; set; }
         string Href { get; set; }
         string Method { get; set; }
    }
}
