using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelableProject.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string SymptomsEndpoint = $"{Prefix}/Symptoms";
        public static readonly string SeveritysEndpoint = $"{Prefix}/Severitys";
    }
}
