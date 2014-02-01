using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Samodiva.Common
{
    public class Configuration
    {
        private Configuration()
        {
        }

        private static Configuration instance;

        public static Configuration Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new Configuration();
                }

                return instance;
            }
        }

        public string PicturesDirectory
        {
            get
            {
                return GetSettingValue<string>("PicturesDirectory");
            }
        }

        public string PicturesDirectoryThumbnails
        {
            get
            {
                return GetSettingValue<string>("PicturesDirectoryThumbnails");
            }
        }

        private static T GetSettingValue<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value))
            {
                throw new ConfigurationErrorsException(string.Format("Application setting \"{0}\" was not found in the configuration file or the value is an empty string.", key));
            }

            T result;
            try
            {
                var obj = Convert.ChangeType(value, typeof(T));
                result = (T)obj;
            }
            catch (InvalidCastException ex)
            {
                throw new ConfigurationErrorsException(string.Format("Application setting \"{0}\" can not be cast to type {1}", key, typeof(T).Name), ex);
            }
            catch (FormatException ex)
            {
                throw new ConfigurationErrorsException(string.Format("Application setting \"{0}\" is in incorrect format.{1}Required type: {2}", key, Environment.NewLine, typeof(T).Name), ex);
            }

            return result;
        }
    }
}
