using Microsoft.EntityFrameworkCore;

namespace UberEats.Models.DataLayer.Reporsitories
{
    
    public class MenuReporsitory : IMenuReporsitory, IDisposable
    {

        private UberContext context;
        public MenuReporsitory(UberContext context)
        {this.context = context;}

        public IEnumerable<MenuItem> MenuItems(int? id)
        {
            return context.MenuItems
                .Where(x => x.PartnerID == id)
                .ToList();
        }
        public IEnumerable<MenuItem> MenuItemsbycatgeoryID(int? id, int? categoryID)
        {
            return context.MenuItems
                .Where(x => x.PartnerID == id && x.MenuCategoryID == categoryID)
                .ToList();
        }


        public IEnumerable<MenuCategory> MenuCategories()
        {
            return context.MenuCategories
                .ToList();
        }

        public MenuItem GetMenuItembyID(int? id)
        {
            return context.MenuItems
                .Where(x => x.MenuItemID == id)
                .FirstOrDefault();
        }

        public void DeleteMenuItem(int id)
        {
            MenuItem MenuItem = context.MenuItems.Find(id);
            context.MenuItems
                .Remove(MenuItem);
        }

        public Partner GetPartnerbyID(int? id)
        {
            return context.Partners
                .Where(x => x.PartnerID == id)
                .FirstOrDefault();
        }

        public void AddMenuItem(MenuItem MenuItem)
        {
            context.MenuItems
                .Add(MenuItem);
        }
        public void UpdateMenuItem(MenuItem MenuItem)
        {
            context
                .Entry(MenuItem).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        
    }
}
