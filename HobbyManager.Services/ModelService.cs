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

        public ModelService()
        {

        }

        public IEnumerable<Model> GetModelsList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Models.ToList();
            }
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

        public ModelDetail GetModelById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Models
                    .Single(e => e.ModelId == id && e.OwnerId == _userId);
                return
                    new ModelDetail
                    {
                        ModelId = entity.ModelId,
                        Name = entity.Name,
                        Scale = entity.Scale,
                        Brand = entity.Brand
                    };
            }
        }

        public bool UpdateModel(ModelEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Models
                    .Single(e => e.ModelId == model.ModelId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Scale = model.Scale;
                entity.Brand = model.Brand;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteModel(int modelId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Models
                    .Single(e => e.ModelId == modelId && e.OwnerId == _userId);

                ctx.Models.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
