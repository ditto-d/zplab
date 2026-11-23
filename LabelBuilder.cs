public static class LabelBuilder
{
    public static string Build(string assetId)
{
    if (string.IsNullOrWhiteSpace(assetId))
    {
        throw new ArgumentException("Asset ID cannot be empty.");
    }
    
    if (assetId.Any(c=>!char.IsAsciiLetterOrDigit(c)&& c != '-'))
    {
        throw new ArgumentException("Asset ID can only contain letters, digits, and hyphens.");
    }
    
   
    return $"""
            ^XA
            ^PW600
            ^LL300
            ^FO40,30^A0N,40,40^FDZPLAB^FS
            ^FO40,90^A0N,30,30^FD{assetId}^FS
            ^FO40,150^BY2,3,70
            ^BCN,70,Y,N,N
            ^FD{assetId}^FS
            ^XZ
            """;
    
    }
}