using Microsoft.Extensions.Localization;
using System.Reflection;

namespace HastaneWeb.Services
{
    public class SharedResource
    {
        public SharedResource() { }

    }

    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;

        // Dil sınıfı için methodlar
        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(LanguageService);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create(nameof(SharedResource), assemblyName.Name);
        }
        
        public LocalizedString GetKey(string key)
        {
            return _localizer[key];
        }
    }
}
