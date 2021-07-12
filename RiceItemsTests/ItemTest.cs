using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiceItems;

namespace RiceItemsTests
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void BasicConstructorTest()
        {
            string itemName = "testitem";
            string itemDisplayName = "Test Item";
            string itemDescription = "An Item for Testing";
            
            Item item = new Item(itemName, itemDisplayName, itemDescription);

            Assert.AreEqual(itemName, item.Name, "Item.Name and supplied name must be equal");
            Assert.AreEqual(itemDisplayName, item.DisplayName, "Item.Display and supplied displayName must be equal");
            Assert.AreEqual(itemDescription, item.Description, "Item.Description and supplied description must be equal");
        }
    }
}
