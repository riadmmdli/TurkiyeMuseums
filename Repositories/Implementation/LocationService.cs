
using System.Drawing.Text;
using turkey_museum.Models.Domain;
using turkey_museum.Repositories.Abstract;

namespace turkey_museum.Repositories.Implementation
{
    public class LocationService : ILocationService
    {
        private readonly DatabaseContext ctx;
        public LocationService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Location model)
        {
            try
            {
                ctx.Location.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                ctx.Location.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Location GetById(int id)
        {
            return ctx.Location.Find(id);
        }

        public IQueryable<Location> List()
        {
            var data = ctx.Location.AsQueryable();
            return data;
        }

        public bool Update(Location model)
        {
            try
            {
                ctx.Location.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

