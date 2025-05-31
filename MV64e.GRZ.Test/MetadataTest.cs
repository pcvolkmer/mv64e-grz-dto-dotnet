using System.Diagnostics;
using System.Reflection;
using MV64e.GRZ;

namespace MV64e.MTB.Test;

public class MetadataTest
{
    [Test]
    public void ShouldParseJsonData()
    {
        var assembly = Assembly.GetExecutingAssembly();
        const string resourceName = @"MV64e.GRZ.Test.TestData.example_metadata.json";

        using var stream = assembly.GetManifestResourceStream(resourceName);
        Debug.Assert(stream != null, "Cannot find test data file");
        using var reader = new StreamReader(stream);
        
        var json = reader.ReadToEnd();
        var mtb = Metadata.FromJson(json);
                
        Assert.IsNotNull(mtb);
    }
}