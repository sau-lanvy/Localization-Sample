using LocalizationSample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalizationSample.Localizers
{
    public class EFStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly LocalizationDBContext _db;
        private IList<ResourceString> _resourceStrings;

        public EFStringLocalizerFactory(LocalizationDBContext db)
        {
            _db = db;

            LoadResources();
        }

        public IStringLocalizer Create(Type resourceSource)
        {

            return new EFStringLocalizer(_db);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new EFStringLocalizer(_db);
        }

        private void LoadResources()
        {
            _resourceStrings = _db.Resources.Include(x => x.Culture).Select(x => new ResourceString
            {
                Culture = x.Culture.Name,
                Key = x.Key,
                Value = x.Value
            }).ToList();
        }
    }
}
