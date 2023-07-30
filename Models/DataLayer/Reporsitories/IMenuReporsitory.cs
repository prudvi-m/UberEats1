using Microsoft.EntityFrameworkCore;

namespace UberEats.Models.DataLayer.Reporsitories
{
    public interface IMenuReporsitory: IDisposable
    {

        IEnumerable<MenuItem> MenuItemsbycatgeoryID(int? PartnerId, int? categoryID);

        IEnumerable<MenuItem> MenuItems(int? PartnerId);

        MenuItem GetMenuItembyID(int? id);
        Partner GetPartnerbyID(int? id);


        IEnumerable<MenuCategory> MenuCategories();


        void DeleteMenuItem(int itemID);
        void UpdateMenuItem(MenuItem menuItem);

        void AddMenuItem(MenuItem menuItem);

        void Save();

    }

}
