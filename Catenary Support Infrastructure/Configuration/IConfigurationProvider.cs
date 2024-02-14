using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenarySupport
{
    internal interface IConfigurationProvider
    {
        public Configuration Configuration { get; }
        public bool SaveConfiguration(string configFile);
    }
}
