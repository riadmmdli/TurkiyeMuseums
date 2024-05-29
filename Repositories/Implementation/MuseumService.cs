
using System.Drawing.Text;
using TurkiyeMuseums.Models.Domain;
using TurkiyeMuseums.Models.DTO;
using TurkiyeMuseums.Repositories.Abstract;

namespace TurkiyeMuseums.Repositories.Implementation
{
    public class MuseumService : IMuseumService
    {
        private readonly DatabaseContext ctx;   
        public MuseumService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Museum model)
        {
            try
            {
                
                ctx.Museum.Add(model);
                ctx.SaveChanges();
                foreach (int locationId in model.Locations)
                {
                    var museumLocation = new MuseumLocation
                    {
                        MuseumId = model.Id,
                        LocationId = locationId
                    };
                    ctx.MuseumLocation.Add(museumLocation);
                }
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
                var museumLocations = ctx.MuseumLocation.Where(a => a.MuseumId == data.Id);  
                foreach(var museumLocation in museumLocations)
                {
                    ctx.MuseumLocation.Remove(museumLocation);
                }
                ctx.Museum.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Museum GetById(int id)
        {
            return ctx.Museum.Find(id);
        }

        public MuseumListVm List(string term="" , bool paging = false , int currentPage = 0)
        {
            var data = new MuseumListVm();
            
            
            var list = ctx.Museum.ToList();
            
            
            if (!string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                list = list.Where(a=>a.MuseumName.ToLower().StartsWith(term)).ToList();
            }
            if (paging)
            {


                int pageSize = 10;
                int count = list.Count;
                int TotalPages = (int)Math.Ceiling(count/(double)pageSize);
                list = list.Skip((currentPage-1)*pageSize).Take(pageSize).ToList();
                data.PageSize = pageSize;
                data.CurrentPage = currentPage;
                data.TotalPages = TotalPages;
            }
            foreach (var museum in list)
            {
                var locations = (from location in ctx.Location join ml in ctx.MuseumLocation 
                                 on location.Id  equals ml.LocationId where ml.MuseumId==museum.Id
                                 select location.LocationName).ToList();
                var locationNames = string.Join(",", locations);
                museum.LocationNames = locationNames;
            }
            data.MuseumList = list.AsQueryable();
            return data;
        }

        public bool Update(Museum model)
        {
            try
            {
                // these locationIds are not selected by users and still  present in museumLocation  table corresponding to 
                // this museumId. So these ids should be removed.
                var locationsToDeleted = ctx.MuseumLocation.Where(a => a.MuseumId == model.Id && !model.Locations.Contains(a.LocationId)).ToList();
                foreach (var mLocation in locationsToDeleted )
                {
                    
                    ctx.MuseumLocation.Remove(mLocation);
                }
                foreach (int locId in model.Locations)
                {
                    var museumLocation = ctx.MuseumLocation.FirstOrDefault(a => a.MuseumId == model.Id && a.LocationId == locId);
                    if (museumLocation == null)
                    {
                        museumLocation = new MuseumLocation { LocationId = locId, MuseumId = model.Id };
                        ctx.MuseumLocation.Add(museumLocation);
                    }
                }
                ctx.Museum.Update(model);
                
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<int> GetLocationByMuseumId(int museumId)
        {
            var locationIds = ctx.MuseumLocation.Where(a => a.MuseumId == museumId).Select(a=> a.LocationId).ToList();
            return locationIds;
        }
    }
}

