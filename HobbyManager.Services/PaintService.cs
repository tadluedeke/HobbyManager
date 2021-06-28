using HobbyManager.Data;
using HobbyManager.Models.Paint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Services
{
    public class PaintService
    {
        private readonly Guid _userId;

        public PaintService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePaint(PaintCreate model)
        {
            var entity =
                new Paint()
                {
                    OwnerId = _userId,
                    Brand = model.Brand,
                    Name = model.Name,
                    Color = model.Color,
                    SKU = model.SKU
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Paints.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PaintListItem> GetPaints()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Paints
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new PaintListItem
                        {
                            PaintId = e.PaintId,
                            Brand = e.Brand,
                            Name = e.Name,
                            Color = e.Color
                        }
                        );
                return query.ToArray();
            }
        }

        public PaintDetail GetPaintById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Paints
                    .Single(e => e.PaintId == id && e.OwnerId == _userId);
                return
                    new PaintDetail
                    {
                        PaintId = entity.PaintId,
                        Brand = entity.Brand,
                        Name = entity.Name,
                        Color = entity.Color,
                        SKU = entity.SKU
                    };
            }
        }

        public bool UpdatePaint(PaintEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Paints
                    .Single(e => e.PaintId == model.PaintId && e.OwnerId == _userId);

                entity.Brand = model.Brand;
                entity.Name = model.Name;
                entity.Color = model.Color;
                entity.SKU = model.SKU;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePaint(int paintId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Paints
                    .Single(e => e.PaintId == paintId && e.OwnerId == _userId);

                ctx.Paints.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
