using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiceItems;

namespace RiceItemsTests
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void CreateInventoryTest()
        {
            int inventorySize = 10;
            Inventory inventory = new Inventory(inventorySize);
            Assert.AreEqual(inventorySize, inventory.Size, "Inventory.Size must be equal to the size argument in the constructor");
        }

        public void CreateInventoryNegativeSizeTest()
        {
            int inventorySize = -2;
            try
            {
                new Inventory(inventorySize);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail("ArgumentOutOfRangeException must be thrown");
        }

        [TestMethod]
        public void SetItemTest()
        {
            int inventorySize = 10;
            Inventory inventory = new Inventory(inventorySize);
            
            Item testItem = new Item("testitem", "Test Item", "An Item for Testing");
            inventory.SetItem(0, testItem);
            Item resultItem = ((Item[]) typeof(Inventory).GetField("slots", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(inventory))[0];
            Assert.AreEqual(testItem, resultItem);

            Item secondTestItem = new Item("secondtestitem", "Second Test Item", "");
            inventory.SetItem(4, secondTestItem);
            Item secondResultItem = ((Item[])typeof(Inventory).GetField("slots", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(inventory))[4];
            Assert.AreEqual(secondTestItem, secondResultItem);
        }

        [TestMethod]
        public void SetItemNegativeTest()
        {
            int inventorySize = 10;
            Inventory inventory = new Inventory(inventorySize);
            Item testItem = new Item("testitem", "Test Item", "An Item for Testing");
            try
            {
                inventory.SetItem(-3, testItem);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void SetItemExceedingIndexTest()
        {
            int inventorySize = 10;
            Inventory inventory = new Inventory(inventorySize);
            Item testItem = new Item("testitem", "Test Item", "An Item for Testing");
            try
            {
                inventory.SetItem(24, testItem);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void GetItemTest()
        {
            int inventorySize = 10;
            Inventory inventory = new Inventory(inventorySize);

            Item testItem = new Item("testitem", "Test Item", "An Item for Testing");
            inventory.SetItem(0, testItem);
            Item resultItem = inventory.GetItem(0);
            Assert.AreEqual(testItem, resultItem);

            Item secondTestItem = new Item("secondtestitem", "Second Test Item", "");
            inventory.SetItem(4, secondTestItem);
            Item secondResultItem = inventory.GetItem(4);
            Assert.AreEqual(secondTestItem, secondResultItem);
        }

        [TestMethod]
        public void GetItemNegativeTest()
        {
            int inventorySize = 10;
            Inventory inventory = new Inventory(inventorySize);
            try
            {
                inventory.GetItem(-3);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void GetItemExceedingIndexTest()
        {
            int inventorySize = 10;
            Inventory inventory = new Inventory(inventorySize);
            try
            {
                inventory.GetItem(24);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
    }
}
