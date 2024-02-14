using CatenarySupport.Database.Tables;
using FluentValidation;
using LinqToDB;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace CatenarySupport
{
    internal class ConfigurationProviderJson: IConfigurationProvider
    {
        public Configuration Configuration { get; protected set; }

        public ConfigurationProviderJson(string configFile = "config.json")
        {
            try
            {
                var config_path = Path.Combine(Directory.GetCurrentDirectory(), configFile);
                var config_string = File.ReadAllText(config_path);

                Configuration = JsonConvert.DeserializeObject<Configuration>(config_string)!;

                var validator = new ConfigurationValidator();
                validator.ValidateAndThrow(Configuration);
            }
            catch (Exception ex)
            {
                throw new Exception($"Неудалось выполнить загрузку параметров из файла '{configFile}':\n\n{ex.Message}");
            }
        }

        public bool SaveConfiguration(string configFile = "config.json")
        {
            try
            {
                var asm_path = Directory.GetCurrentDirectory();
                File.WriteAllText(Path.Combine(asm_path, configFile), JsonConvert.SerializeObject(Configuration, Formatting.Indented));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Неудалось сохранить параметры в файл '{configFile}':\n\n{ex.Message}");
            }
        }
    }
}
