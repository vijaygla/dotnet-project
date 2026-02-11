using LogVaultApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogVaultTests;

[TestClass]
public class RecordTests
{
    [TestMethod]
    public void Create_Record_Test()
    {
        var r = new ActivityRecord
        {
            RecordId = "1",
            SourceModule = "Auth",
            Severity = SeverityLevel.Info,
            Message = "Login"
        };

        Assert.AreEqual("Auth", r.SourceModule);
    }
}
