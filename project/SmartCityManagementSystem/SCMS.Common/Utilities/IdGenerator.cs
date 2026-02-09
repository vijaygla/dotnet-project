using System;

namespace SCMS.Common.Utilities
{
    public static class IdGenerator
    {
        private static int sequence = 1;

        public static string GenerateCitizenId()
        {
            string year = DateTime.Now.Year.ToString();
            string seq = sequence.ToString("D5");
            sequence++;
            return $"TC-{year}-{seq}";
        }
    }
}
