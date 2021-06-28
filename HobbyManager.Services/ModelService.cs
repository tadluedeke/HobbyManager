using HobbyManager.Data;
using HobbyManager.Models;
using HobbyManager.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Services
{
    public class ModelService
    {
        private readonly Guid _userId;

        public ModelService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateModel(ModelCreate model)
        {
            var entity =
                new Model()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Scale = model.Scale,
                    Brand = model.Brand
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Models.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ModelListItem> GetModels()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Models
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ModelListItem
                        {
                            ModelId = e.ModelId,
                            Name = e.Name,
                            Brand = e.Brand
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
